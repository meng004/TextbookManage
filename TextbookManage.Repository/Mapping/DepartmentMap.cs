namespace TextbookManage.Repositories.Mapping
{

    using System.Data.Entity.ModelConfiguration;
    using TextbookManage.Domain.Models;

    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            // Primary Key
            this.HasKey(t => t.DepartmentID);

            // Properties
            this.Property(t => t.Num)
                .HasMaxLength(20);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.SchoolNum)
                .HasMaxLength(20);

            this.Property(t => t.SchoolName)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("V_JCSJ_KSJBXX","dbo");
            this.Property(t => t.DepartmentID).HasColumnName("KSID");
            this.Property(t => t.Num).HasColumnName("KSH");
            this.Property(t => t.Name).HasColumnName("KSMC");
            this.Property(t => t.School_ID).HasColumnName("SSYXSID");
            this.Property(t => t.SchoolNum).HasColumnName("SSYXSH");
            this.Property(t => t.SchoolName).HasColumnName("SSYXSMC");
        }
    }
}
