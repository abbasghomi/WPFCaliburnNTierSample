using System.Data.Entity;

namespace WPFCaliburnNTierSample.DomainLayer.Persistence.Interfaces
{
    /// <summary>
    /// DbContext factory interface, used to inject with IOC without creating dependency
    /// </summary>
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}
