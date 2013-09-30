namespace TextbookManage.Repositories.Mapping
{

    using System.Data.Entity.ModelConfiguration;
    using TextbookManage.Domain.Models;

    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            // Primary Key
            this.HasKey(t => t.StudentID);

            // Properties
            this.Property(t => t.StudentNum)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.StudentName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ClassNum)
                .HasMaxLength(20);

            this.Property(t => t.ClassName)
                .HasMaxLength(200);

            this.Property(t => t.Grade)
                .HasMaxLength(20);

            this.Property(t => t.SchoolNum)
                .HasMaxLength(20);

            this.Property(t => t.SchoolName)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("V_JCSJ_YXSXSB","dbo");
            this.Property(t => t.StudentID).HasColumnName("XJID");
            this.Property(t => t.StudentNum).HasColumnName("XH");
            this.Property(t => t.StudentName).HasColumnName("XM");
            this.Property(t => t.Gender).HasColumnName("XB");
            this.Property(t => t.Class_ID).HasColumnName("BJID");
            this.Property(t => t.ClassNum).HasColumnName("BH");
            this.Property(t => t.ClassName).HasColumnName("BJMC");
            this.Property(t => t.Grade).HasColumnName("NJ");
            this.Property(t => t.School_ID).HasColumnName("YXSID");
            this.Property(t => t.SchoolNum).HasColumnName("YXSH");
            this.Property(t => t.SchoolName).HasColumnName("YXSMC");
        }
    }
}
