
using WPFCaliburnNTierSample.DomainLayer.Persistence.Repositories.Interfaces;

namespace WPFCaliburnNTierSample.DomainLayer.Persistence.Interfaces
{
    /// <summary>
    /// repositories orchestrator to have access to all Repositories from single poing
    /// </summary>
    public interface IWPFCaliburnNTierSampleContext
    {
        ICustomerRepository Customers { get;  }
    }
}
