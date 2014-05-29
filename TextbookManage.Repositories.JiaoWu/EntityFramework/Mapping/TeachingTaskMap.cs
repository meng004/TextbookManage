using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
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
                .HasMaxLength(9);

            this.Property(t => t.DataSign_Id)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("V_KK_JXBXXB", "dbo");
            this.Property(t => t.TeachingTaskNum).HasColumnName("JXBBH");
            this.Property(t => t.SchoolYear).HasColumnName("XN");
            this.Property(t => t.SchoolTerm).HasColumnName("XQ");
            this.Property(t => t.Course_Id).HasColumnName("KCID");
            this.Property(t => t.School_Id).HasColumnName("YXSID");
            this.Property(t => t.Department_Id).HasColumnName("KSID");
            this.Property(t => t.Teacher_Id).HasColumnName("ZRJS");
            this.Property(t => t.DataSign_Id).HasColumnName("SJBS");
            this.Property(t => t.HeadCount).HasColumnName("ZRS"); 

            // Relationships
            //教学任务教师多对多映射
            //这里只取理论教师
            //未处理实验教师、上机教师
            this.HasMany(t => t.Teachers)
                .WithMany(t => t.TeachingTasks)
                .Map(m =>
                    {
                        m.ToTable("KK_JXBJSB", "dbo");
                        m.MapLeftKey("JXBBH");
                        m.MapRightKey("ZGID");
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
