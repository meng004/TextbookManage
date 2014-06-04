using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Num)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(60);

            // Table & Column Mappings
            this.ToTable("V_JCSJ_KSJBXX", "dbo");
            this.Property(t => t.ID).HasColumnName("KSID");
            this.Property(t => t.Num).HasColumnName("KSH");
            this.Property(t => t.Name).HasColumnName("KSMC");
            this.Property(t => t.School_Id).HasColumnName("SSYXSID");

            // Relationships
            //教研室教师映射，多对多
            this.HasMany(t => t.Teachers)
                .WithMany(t => t.Departments)
                .Map(m =>
                    {
                        m.ToTable("GL_YXSJSB", "dbo");
                        m.MapLeftKey("YXSID");
                        m.MapRightKey("ZGID");
                    });

            //学院：部门，1：N
            this.HasRequired(t => t.School)
                .WithMany(t => t.Departments)
                .HasForeignKey(d => d.School_Id);

        }
    }
}
