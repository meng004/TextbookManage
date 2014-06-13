using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextbookManage.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class TeachingTaskTeacherMap : EntityTypeConfiguration<TeachingTaskTeacher>
    {
        public TeachingTaskTeacherMap()
        {
            this.HasKey(t => t.ID);

            this.ToTable("V_KK_JXBJSB", "dbo");
            this.Property(t => t.ID).HasColumnName("JXBJSBID");
            this.Property(t => t.TeachingTaskNum).HasColumnName("JXBBH");
            this.Property(t => t.TeacherId).HasColumnName("ZGID");
            this.Property(t => t.Name).HasColumnName("XM");
            this.Property(t => t.Gender).HasColumnName("XB");
            this.Property(t => t.TeachingMode).HasColumnName("JXFS");
            
            //教学任务：教师，1：N
            this.HasRequired(t => t.TeachingTask)
                .WithMany(t => t.TeachingTaskTeachers)
                .HasForeignKey(d => d.TeachingTaskNum);
        }
    }
}
