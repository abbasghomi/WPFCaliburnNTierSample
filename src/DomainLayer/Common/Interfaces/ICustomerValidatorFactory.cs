using WPFCaliburnNTierSample.DomainLayer.Common.Models;
using WPFCaliburnNTierSample.DomainLayer.Entities;
using System.Collections.Generic;

namespace WPFCaliburnNTierSample.DomainLayer.Common.Interfaces
{
    /// <summary>
    /// Customer validator facotry interface
    /// </summary>
    public interface ICustomerValidatorFactory 
    {
        bool IsValid(Customer customer);

        List<ErrorModel> ValidationErrors(Customer customer);
    }
}
