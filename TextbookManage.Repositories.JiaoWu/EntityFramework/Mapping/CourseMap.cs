using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap()
        {
            // Primary Key
            this.HasKey(t => t.CourseId);

            // Properties
            this.Property(t => t.Num)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("JCSJ_KCXX", "dbo");
            this.Property(t => t.CourseId).HasColumnName("KCID");
            this.Property(t => t.Num).HasColumnName("KCH");
            this.Property(t => t.Name).HasColumnName("KCMC");

            // Relationships
            //教研室课程多对多关系
            this.HasMany(t => t.Departments)
                .WithMany(t => t.Courses)
                .Map(m =>
                    {
                        m.ToTable("KK_JXBXXB", "dbo");
                        m.MapLeftKey("KCID");
                        m.MapRightKey("KSID");
                    });


        }
    }
}
