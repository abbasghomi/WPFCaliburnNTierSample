using System.Data.Entity.ModelConfiguration;
using WPFCaliburnNTierSample.DomainLayer.Entities;

namespace WPFCaliburnNTierSample.DomainLayer.Persistence.Configurations
{
    /// <summary>
    /// Customer table configuration for Entityframework
    /// </summary>
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            SetColumnProperties();
            SetPrimaryKey();
        }

        private void SetPrimaryKey()
        {
            HasKey(r => r.CustomerId);
        }

        private void SetColumnProperties()
        {
            ToTable("Customer", "dbo");
            
            Property(r => r.CustomerId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(r => r.FirstName).HasMaxLength(30).IsRequired();
            Property(r => r.LastName).HasMaxLength(30).IsRequired();
            Property(r => r.Address1).HasMaxLength(40).IsRequired();
            Property(r => r.Address2).HasMaxLength(40).IsOptional();
            Property(r => r.City).HasMaxLength(50).IsRequired();
            Property(r => r.State).HasMaxLength(2).IsRequired();
            Property(r => r.Zip).HasMaxLength(10).IsRequired();
            Property(r => r.Phone).HasMaxLength(20).IsOptional();
            Property(r => r.Age).IsOptional();
            Property(r => r.Sales).IsOptional();
            Property(r => r.CreatedTime).IsRequired();
            Property(r => r.UpdatedTime).IsRequired();

        }
    }
}
