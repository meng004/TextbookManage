using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class TeachingTaskMap : EntityTypeConfiguration<TeachingTask>
    {
        public TeachingTaskMap()
        {
            // Primary Key
            this.HasKey(t => t.TeachingTaskNum);

            // Properties
            this.Property(t => t.TeachingTaskNum)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.DataSign_Id)
                .IsRequired()
                .HasMaxLength(1);
            //this.Property(t => t.Term)
            //    .IsRequired()
            //    .HasMaxLength(20);

            Ignore(t => t.DeclarationState);

            // Table & Column Mappings
            this.ToTable("V_KK_JXBXXB", "dbo");
            this.Property(t => t.TeachingTaskNum).HasColumnName("JXBBH");
            this.Property(t => t.Course_Id).HasColumnName("KCID");
            this.Property(t => t.Department_Id).HasColumnName("KSID");
            this.Property(t => t.DataSign_Id).HasColumnName("SJBS");
            this.Property(t => t.ZRS).HasColumnName("ZRS");

            
            //学年学期
            this.Property(t => t.XNXQ.XN).HasColumnName("XN");
            this.Property(t => t.XNXQ.XQ).HasColumnName("XQ");
            this.Ignore(t => t.Term);
            //责任教师
            this.Property(t => t.ResponsibilityTeacher.Name).HasColumnName("XM");
            this.Property(t => t.ResponsibilityTeacher.Gender).HasColumnName("XB");

            // Relationships
            //教学任务教师多对多映射
            //这里只取理论教师
            //未处理实验教师、上机教师
            this.HasMany(t => t.Teachers)
                .WithMany(t => t.TeachingTasks)
                .Map(m =>
                    {
                        m.ToTable("V_KK_LLJS", "dbo");
                        m.MapLeftKey("JXBBH");
                        m.MapRightKey("LLJSID");
                    });

            //课程与教学任务，1对多
            this.HasRequired(t => t.Course)
                .WithMany(t => t.TeachingTasks)
                .HasForeignKey(d => d.Course_Id);

            //教研室与教学任务，1对多
            this.HasRequired(t => t.Department)
                .WithMany(t => t.TeachingTasks)
                .HasForeignKey(d => d.Department_Id);

            //教学任务与数据标识,多对1
            this.HasRequired(t => t.DataSign)
                .WithMany(d => d.TeachingTasks)
                .HasForeignKey(f => f.DataSign_Id);

        }
    }
}
