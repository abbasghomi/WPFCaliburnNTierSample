using WPFCaliburnNTierSample.DomainLayer.Common.Dto;
using WPFCaliburnNTierSample.DomainLayer.Entities;
using WPFCaliburnNTierSample.DomainLayer.Persistence.Interfaces;
using WPFCaliburnNTierSample.DomainLayer.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace WPFCaliburnNTierSample.DomainLayer.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Customer> _dbSet;

        public CustomerRepository(IWPFCaliburnNTierSampleContextFactory contextFactory)
        {
            _context = contextFactory.GetContext();
            _dbSet = _context.Set<Customer>();
        }

        public async Task<Customer> GetAsync(int id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(ct, id);
        }

        public async Task<Customer> UpdateAsync(Customer entity, CancellationToken ct = default)
        {
            entity.UpdatedTime = DateTime.Now;
            _dbSet.AddOrUpdate(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Paginated<Customer>> GetPageAsync<TOrder>(Expression<Func<Customer, TOrder>> order,
             int pageNumber, int pageSize, CancellationToken ct = default)
        {
            var itemCount = await _dbSet.CountAsync();

            int pagesCount = 0;
            ICollection<Customer> pageItems = null;

            if (itemCount != 0 && pageSize > 0)
            {
                pagesCount = (itemCount / pageSize) +
                                 ((itemCount % pageSize == 0) ? 0 : 1);

                pageItems = await GetLimitAsync(order,
                                              pageSize,
                                              ((pageNumber - 1) < 0 ? 0 : (pageNumber - 1)) *
                                                                    pageSize,
                                                                    ct);
            }

            Paginated<Customer> paginatedResult = new Paginated<Customer>
            {
                ItemsCount = itemCount,
                PagesCount = pagesCount,
                PageNumber = pageNumber,
                PageItems = pageItems
            };

            return paginatedResult;
        }

        public virtual async Task<ICollection<Customer>> GetLimitAsync<TOrder>(Expression<Func<Customer, TOrder>> order, int take, int skip, CancellationToken ct = default)
        {
            return await _dbSet.OrderBy(order).Skip(skip).Take(take).ToListAsync(ct);
        }
    }
}
