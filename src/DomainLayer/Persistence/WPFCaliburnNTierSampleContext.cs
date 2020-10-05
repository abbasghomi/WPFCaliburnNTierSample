using WPFCaliburnNTierSample.DomainLayer.Persistence.Interfaces;
using WPFCaliburnNTierSample.DomainLayer.Persistence.Repositories.Interfaces;

namespace WPFCaliburnNTierSample.DomainLayer.Persistence
{
    /// <summary>
    /// repositories orchestrator to have access to all Repositories from single poing
    /// </summary>
    public class WPFCaliburnNTierSampleContext : IWPFCaliburnNTierSampleContext
    {
        public WPFCaliburnNTierSampleContext(ICustomerRepository customerRepository)
        {

            Customers = customerRepository;
        }

        public ICustomerRepository Customers { get; }
    }
}
