using System;
using System.Data.Entity;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using WPFCaliburnNTierSample.DomainLayer.Persistence.Interfaces;

namespace WPFCaliburnNTierSample.DomainLayer.Persistence
{
    /// <summary>
    /// Entityframework db context interface
    /// </summary>
    /// 
    public class WPFCaliburnNTierSampleDbContext : DbContext, IWPFCaliburnNTierSampleDbContext
    {
        public WPFCaliburnNTierSampleDbContext() : base("name=DefaultConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


        public override int SaveChanges()
        {
            UpdateFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateFields()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["CreatedTime"] = DateTime.Now;
                        entry.CurrentValues["UpdatedTime"] = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues["UpdatedTime"] = DateTime.Now;
                        break;
                }
            }
        }
    }
}
