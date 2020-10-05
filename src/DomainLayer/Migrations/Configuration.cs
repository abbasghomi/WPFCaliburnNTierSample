using System.Data.Entity.Migrations;

namespace WPFCaliburnNTierSample.DomainLayer.Migrations
{
    /// <summary>
    /// Migration configuration for entity framework
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<WPFCaliburnNTierSample.DomainLayer.Persistence.WPFCaliburnNTierSampleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WPFCaliburnNTierSample.DomainLayer.Persistence.WPFCaliburnNTierSampleDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
