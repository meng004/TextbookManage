using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            // Primary Key
            this.HasKey(t => t.DepartmentId);

            // Properties
            this.Property(t => t.Num)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("V_JCSJ_KSJBXX", "dbo");
            this.Property(t => t.DepartmentId).HasColumnName("KSID");
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


            this.HasRequired(t => t.School)
                .WithMany(t => t.Departments)
                .HasForeignKey(d => d.School_Id);

        }
    }
}
