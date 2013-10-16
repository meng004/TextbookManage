using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class CasMapperMap : EntityTypeConfiguration<CasMapper>
    {
        public CasMapperMap()
        {
            // Primary Key
            this.HasKey(t => t.IdCard);

            // Properties
            this.Property(t => t.CasNetId)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.IdCard)
                .HasMaxLength(20);

            this.ToTable("CasMapper", "Cas");
            this.Property(t => t.UserId).HasColumnName("UserID");
            this.Property(t => t.IdCard).HasColumnName("IdCard");
            this.Property(t => t.CasNetId).HasColumnName("CasNetID");

        }
    }
}

