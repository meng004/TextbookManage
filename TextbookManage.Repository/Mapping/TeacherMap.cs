namespace TextbookManage.Repositories.Mapping
{

    using System.Data.Entity.ModelConfiguration;
    using TextbookManage.Domain.Models;

    public class TeacherMap : EntityTypeConfiguration<Teacher>
    {
        public TeacherMap()
        {
            // Primary Key
            this.HasKey(t => t.TeacherID);

            // Properties
            this.Property(t => t.TeacherNum)
                .HasMaxLength(20);

            this.Property(t => t.TeacherName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.SchoolNum)
                .HasMaxLength(20);

            this.Property(t => t.SchoolName)
                .HasMaxLength(200);

            //this.Property(t => t.DepartmentNum)
            //    .HasMaxLength(20);

            this.Property(t => t.DepartmentName)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("V_JCSJ_JSYXSB","dbo");
            this.Property(t => t.TeacherID).HasColumnName("ZGID");
            this.Property(t => t.TeacherNum).HasColumnName("JSZGH");
            this.Property(t => t.TeacherName).HasColumnName("XM");
            this.Property(t => t.Gender).HasColumnName("XB");
            this.Property(t => t.School_ID).HasColumnName("SSYXSID");
            this.Property(t => t.SchoolNum).HasColumnName("SSYXSH");
            this.Property(t => t.SchoolName).HasColumnName("SSYXSMC");
            this.Property(t => t.Department_ID).HasColumnName("KSID");
            //this.Property(t => t.DepartmentNum).HasColumnName("DepartmentNum");
            this.Property(t => t.DepartmentName).HasColumnName("KSMC");
        }
    }
}
