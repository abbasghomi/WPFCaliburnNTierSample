using WPFCaliburnNTierSample.DomainLayer.Common.Dto;
using WPFCaliburnNTierSample.DomainLayer.Entities;
using WPFCaliburnNTierSample.DomainLayer.Persistence.Interfaces;
using WPFCaliburnNTierSample.DomainLayer.Services.Interfaces;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace WPFCaliburnNTierSample.DomainLayer.Services
{
    /// <summary>
    /// service layer for Customer entity
    /// </summary>

    public class CustomerService : ICustomerService
    {
        private readonly IWPFCaliburnNTierSampleContext _context;

        public CustomerService(IWPFCaliburnNTierSampleContext context)
        {
            _context = context;
        }


        public async Task<Customer> UpdateCustomer(Customer customer, CancellationToken ct = default)
        {
            return await _context.Customers.UpdateAsync(customer);
        }

        public async Task<Paginated<Customer>> GetPaginatedCustomersList<TOrder>(Expression<Func<Customer, TOrder>> order, int pageNumber, int pageSize, CancellationToken ct = default)
        {
            return await _context.Customers.GetPageAsync(order, pageNumber, pageSize, ct);
        }
    }
}
