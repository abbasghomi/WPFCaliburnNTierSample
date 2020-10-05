using System.Data.Entity;
using WPFCaliburnNTierSample.DomainLayer.Persistence.Interfaces;

namespace WPFCaliburnNTierSample.DomainLayer.Persistence
{
    /// <summary>
    /// DbContext factory implementation, used to inject with IOC without creating dependency
    /// </summary>
    public class DbContextFactory: IDbContextFactory
    {
        private WPFCaliburnNTierSampleDbContext _context;

        public DbContext GetContext()
        {
            return _context ?? (_context = new WPFCaliburnNTierSampleDbContext());
        }
    }
}
