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
            this.Property(t => t.SchoolYearTerm.Year).HasColumnName("XN");
            this.Property(t => t.SchoolYearTerm.Term).HasColumnName("XQ");
            this.Property(t => t.Course_Id).HasColumnName("KCID");
            this.Property(t => t.School_Id).HasColumnName("YXSID");
            this.Property(t => t.Department_Id).HasColumnName("KSID");
            this.Property(t => t.Teacher_Id).HasColumnName("ZRJS");
            this.Property(t => t.DataSign_Id).HasColumnName("SJBS");
            this.Property(t => t.HeadCount).HasColumnName("ZRS");

            this.Ignore(t => t.ID);

            // Relationships
            //��ѧ�����ʦ��Զ�ӳ��
            //����ֻȡ���۽�ʦ
            //δ����ʵ���ʦ���ϻ���ʦ
            //this.HasMany(t => t.TeachingTaskTeachers)
            //    .WithMany(t => t.TeachingTasks)
            //    .Map(m =>
            //        {
            //            m.ToTable("KK_JXBJSB", "dbo");
            //            m.MapLeftKey("JXBBH");
            //            m.MapRightKey("ZGID");
            //        });
            
            //���ν�ʦ����ѧ����1��N
            this.HasOptional(t => t.Teacher)
                .WithMany(t => t.TeachingTasks)
                .HasForeignKey(d => d.Teacher_Id);

            //�༶����ѧ����M��N
            this.HasMany(t => t.ProfessionalClasses)
                .WithMany(t => t.TeachingTasks)
                .Map(m =>
                {
                    m.ToTable("KK_JXBBJB", "dbo");
                    m.MapLeftKey("JXBBH");
                    m.MapRightKey("BJID");
                });

            //�γ����ѧ����1�Զ�
            this.HasRequired(t => t.Course)
                .WithMany(t => t.TeachingTasks)
                .HasForeignKey(d => d.Course_Id);

            //�������ѧ����1�Զ�
            this.HasRequired(t => t.Department)
                .WithMany(t => t.TeachingTasks)
                .HasForeignKey(d => d.Department_Id);

            //ѧԺ:��ѧ����1��N
            this.HasRequired(t => t.School)
                .WithMany(t => t.TeachingTasks)
                .HasForeignKey(d => d.School_Id);

            //���ݱ�ʶ����ѧ����,1��N
            this.HasRequired(t => t.DataSign)
                .WithMany(d => d.TeachingTasks)
                .HasForeignKey(f => f.DataSign_Id);


        }
    }
}
