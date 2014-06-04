using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class ProfessionalClassMap : EntityTypeConfiguration<ProfessionalClass>
    {
        public ProfessionalClassMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Num)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Grade)
                .IsRequired()
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("V_JCSJ_YXSBJB", "dbo");
            this.Property(t => t.ID).HasColumnName("BJID");
            this.Property(t => t.Num).HasColumnName("BH");
            this.Property(t => t.Name).HasColumnName("BJMC");
            this.Property(t => t.Grade).HasColumnName("NJ");
            this.Property(t => t.School_Id).HasColumnName("YXSID");
            this.Property(t => t.Xyrs).HasColumnName("XYRS");

            // Relationships
            // 教学任务班级多对多关系
            this.HasMany(t => t.TeachingTasks)
                .WithMany(t => t.ProfessionalClasses)
                .Map(m =>
                    {
                        m.ToTable("KK_JXBBJB", "dbo");
                        m.MapLeftKey("BJID");
                        m.MapRightKey("JXBBH");
                    });
            //学院:班级，1：N
            this.HasRequired(t => t.School)
                .WithMany(t => t.ProfessionalClasses)
                .HasForeignKey(d => d.School_Id);

        }
    }
}
