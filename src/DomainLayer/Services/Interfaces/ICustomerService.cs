using WPFCaliburnNTierSample.DomainLayer.Common.Dto;
using WPFCaliburnNTierSample.DomainLayer.Entities;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace WPFCaliburnNTierSample.DomainLayer.Services.Interfaces
{
    /// <summary>
    /// service layer for Customer entity
    /// </summary>
    public interface ICustomerService
    {
        Task<Customer> UpdateCustomer(Customer customer, CancellationToken ct = default);
        Task<Paginated<Customer>> GetPaginatedCustomersList<TOrder>(Expression<Func<Customer, TOrder>> order, int pageNumber, int pageSize, CancellationToken ct = default);
    }
}