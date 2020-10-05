using WPFCaliburnNTierSample.DomainLayer.Common.Interfaces;
using WPFCaliburnNTierSample.DomainLayer.Common.Models;
using WPFCaliburnNTierSample.DomainLayer.Entities;
using System.Collections.Generic;

namespace WPFCaliburnNTierSample.DomainLayer.Common.Validators
{
    /// <summary>
    /// Customer validator facotry implementation
    /// </summary>
    public class CustomerValidatorFactory : ICustomerValidatorFactory
    {
        CustomerValidator _validator;

        public CustomerValidatorFactory()
        {
            _validator = new CustomerValidator();
        }

        public bool IsValid(Customer customer)
        {
            return _validator.Validate(customer).IsValid;
        }

        public List<ErrorModel> ValidationErrors(Customer customer)
        {
            List<ErrorModel> result = new List<ErrorModel>();
            foreach (var item in _validator.Validate(customer).Errors)
            {
                result.Add(new ErrorModel
                {
                    PropertyName = item.PropertyName,
                    ErrorMessage = item.ErrorMessage
                });
            }
            return result;
        }
    }
}
