namespace TextbookManage.Repositories.Mapping
{

    using System.Data.Entity.ModelConfiguration;
    using TextbookManage.Domain.Models;

    public class TeachingTaskMap : EntityTypeConfiguration<TeachingTask>
    {
        public TeachingTaskMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TeachingTaskNum });

            // Properties
            this.Property(t => t.TeachingTaskNum)
                .IsRequired()
                .HasMaxLength(20);

            //this.Property(t => t.Term)
            //    .IsRequired()
            //    .HasMaxLength(200);

            this.Property(t => t.CourseNum)
                .HasMaxLength(20);

            this.Property(t => t.CourseName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.DataSign)
                .HasMaxLength(200);

            //this.Property(t => t.SchoolNum)
            //    .HasMaxLength(20);

            this.Property(t => t.SchoolName)
                .HasMaxLength(200);

            //this.Property(t => t.DepartmentNum)
            //    .HasMaxLength(20);

            this.Property(t => t.DepartmentName)
                .HasMaxLength(200);

            //this.Property(t => t.ResponsibleTeacher)
            //    .HasMaxLength(200);

            //this.Property(t => t.TeacherName)
            //    .HasMaxLength(200);

            //this.Property(t => t.ClassName)
            //    .HasMaxLength(200);

            
            Ignore(t => t.Term);

            // Table & Column Mappings
            this.ToTable("V_KK_JXRWS","dbo");
            //this.Property(t => t.TeachingTaskID).HasColumnName("TeachingTaskID");
            this.Property(t => t.TeachingTaskNum).HasColumnName("JXBBH");
            this.Property(t => t.XN).HasColumnName("XN");
            this.Property(t => t.XQ).HasColumnName("XQ");
            this.Property(t => t.Course_ID).HasColumnName("KCID");
            this.Property(t => t.CourseNum).HasColumnName("KCH");
            this.Property(t => t.CourseName).HasColumnName("KCMC");
            this.Property(t => t.DataSign).HasColumnName("SJBS");
            this.Property(t => t.SchoolID).HasColumnName("YXSID");
            //this.Property(t => t.SchoolNum).HasColumnName("SchoolNum");
            this.Property(t => t.SchoolName).HasColumnName("YXSMC");
            this.Property(t => t.Department_ID).HasColumnName("KSID");
            //this.Property(t => t.DepartmentNum).HasColumnName("KSMC");
            this.Property(t => t.DepartmentName).HasColumnName("KSMC");
            this.Property(t => t.ResponsibleTeacher).HasColumnName("ZRJS");
            this.Property(t => t.Teacher_ID).HasColumnName("LLJSID");
            this.Property(t => t.TeacherName).HasColumnName("LLJSXM");
            this.Property(t => t.Class_ID).HasColumnName("BJID");
            this.Property(t => t.ClassName).HasColumnName("BJMC");
            this.Property(t => t.StudentCount).HasColumnName("ZRS");
        }
    }
}
