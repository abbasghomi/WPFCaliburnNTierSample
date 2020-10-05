using WPFCaliburnNTierSample.DomainLayer.Persistence.Interfaces;
using System.Data.Entity;

namespace WPFCaliburnNTierSample.DomainLayer.Persistence
{
    /// <summary>
    /// used for IOC dependency injection
    /// </summary>

    public class WPFCaliburnNTierSampleContextFactory: IWPFCaliburnNTierSampleContextFactory
    {
        private WPFCaliburnNTierSampleDbContext _context;

        public DbContext GetContext()
        {
            return _context ?? (_context = new WPFCaliburnNTierSampleDbContext());
        }
    }
}
