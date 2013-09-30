namespace TextbookManage.Repositories.Mapping
{

    using System.Data.Entity.ModelConfiguration;
    using TextbookManage.Domain.Models;

    public class SchoolMap : EntityTypeConfiguration<School>
    {
        public SchoolMap()
        {
            // Primary Key
            this.HasKey(t => t.SchoolID);

            // Properties
            this.Property(t => t.Num)
                .HasMaxLength(20);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("V_JCSJ_YXSJBXX","dbo");
            this.Property(t => t.SchoolID).HasColumnName("YXSID");
            this.Property(t => t.Num).HasColumnName("YXSH");
            this.Property(t => t.Name).HasColumnName("YXSMC");
        }
    }
}
