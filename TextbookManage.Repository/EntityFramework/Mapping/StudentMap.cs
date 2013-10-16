using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            // Primary Key
            this.HasKey(t => t.StudentId);

            // Properties
            this.Property(t => t.Num)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Sex)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("V_JCSJ_BJXSB", "dbo");
            this.Property(t => t.StudentId).HasColumnName("XJID");
            this.Property(t => t.Num).HasColumnName("XH");
            this.Property(t => t.Name).HasColumnName("XM");
            this.Property(t => t.Sex).HasColumnName("XB");
            this.Property(t => t.ProfessionalClass_Id).HasColumnName("BJID");

            // Relationships
            this.HasRequired(t => t.ProfessionalClass)
                .WithMany(t => t.Students)
                .HasForeignKey(d => d.ProfessionalClass_Id);

        }
    }
}
