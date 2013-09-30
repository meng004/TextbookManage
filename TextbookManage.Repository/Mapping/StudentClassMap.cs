namespace TextbookManage.Repositories.Mapping
{

    using System.Data.Entity.ModelConfiguration;
    using TextbookManage.Domain.Models;

    public class StudentClassMap : EntityTypeConfiguration<StudentClass>
    {
        public StudentClassMap()
        {
            // Primary Key
            this.HasKey(t => t.ClassID);

            // Properties
            this.Property(t => t.ClassNum)
                .HasMaxLength(20);

            this.Property(t => t.ClassName)
                .HasMaxLength(200);

            this.Property(t => t.Grade)
                .HasMaxLength(20);

            this.Property(t => t.SchoolNum)
                .HasMaxLength(20);

            this.Property(t => t.SchoolName)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("V_JCSJ_YXSBJB", "dbo");
            this.Property(t => t.ClassID).HasColumnName("BJID");
            this.Property(t => t.ClassNum).HasColumnName("BH");
            this.Property(t => t.ClassName).HasColumnName("BJMC");
            this.Property(t => t.Grade).HasColumnName("NJ");
            this.Property(t => t.School_ID).HasColumnName("YXSID");
            this.Property(t => t.SchoolNum).HasColumnName("YXSH");
            this.Property(t => t.SchoolName).HasColumnName("YXSMC");

            Ignore(t => t.StudentCount);
        }
    }
}
