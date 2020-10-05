using WPFCaliburnNTierSample.DomainLayer.Common.Dto;
using WPFCaliburnNTierSample.DomainLayer.Entities;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace WPFCaliburnNTierSample.DomainLayer.Persistence.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetAsync(int id, CancellationToken ct = default);
        Task<Customer> UpdateAsync(Customer entity, CancellationToken ct = default);
        Task<Paginated<Customer>> GetPageAsync<TOrder>(Expression<Func<Customer, TOrder>> order, int pageNumber, int pageSize, CancellationToken ct = default);
    }
}