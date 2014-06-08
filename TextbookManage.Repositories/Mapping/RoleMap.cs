using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(256);

            this.ToTable("aspnet_Roles", "dbo");
            this.Property(t => t.ID).HasColumnName("RoleId");
            this.Property(t => t.Name).HasColumnName("RoleName");
        }
    }
}
