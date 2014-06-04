using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Num)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.Gender)
                .IsRequired()
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("V_JCSJ_BJXSB", "dbo");
            this.Property(t => t.ID).HasColumnName("XJID");
            this.Property(t => t.Num).HasColumnName("XH");
            this.Property(t => t.Name).HasColumnName("XM");
            this.Property(t => t.Gender).HasColumnName("XB");
            this.Property(t => t.ProfessionalClass_Id).HasColumnName("BJID");
            this.Property(t => t.Zxf).HasColumnName("ZXF");

            // �༶��ѧ����1��N
            this.HasRequired(t => t.ProfessionalClass)
                .WithMany(t => t.Students)
                .HasForeignKey(d => d.ProfessionalClass_Id);

        }
    }
}
