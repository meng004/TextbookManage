using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class DataSignMap : EntityTypeConfiguration<DataSign>
    {
        public DataSignMap()
        {
            this.HasKey(t => t.DataSignId);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(20);

            this.ToTable("XT_SJBS", "dbo");
            this.Property(t => t.DataSignId).HasColumnName("SJBSID");
            this.Property(t => t.Name).HasColumnName("SJBSMC");

        }
    }
}
