using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class TeacherMap : EntityTypeConfiguration<Teacher>
    {
        public TeacherMap()
        {
            // Primary Key
            this.HasKey(t => t.TeacherId);

            // Properties
            this.Property(t => t.Num)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.Gender)
                .IsRequired()
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("V_JCSJ_JSB", "dbo");
            this.Property(t => t.TeacherId).HasColumnName("ZGID");
            this.Property(t => t.Num).HasColumnName("JSZGH");
            this.Property(t => t.Name).HasColumnName("XM");
            this.Property(t => t.Gender).HasColumnName("XB");
        }
    }
}
