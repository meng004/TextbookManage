using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class SchoolMap : EntityTypeConfiguration<School>
    {
        public SchoolMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Num)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(60);

            // Table & Column Mappings
            this.ToTable("V_JCSJ_YXSJBXX", "dbo");
            this.Property(t => t.ID).HasColumnName("YXSID");
            this.Property(t => t.Num).HasColumnName("YXSH");
            this.Property(t => t.Name).HasColumnName("YXSMC");
        }
    }
}
