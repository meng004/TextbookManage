using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class DeclarationClassMap : EntityTypeConfiguration<DeclarationClass>
    {
        public DeclarationClassMap()
        {
            this.HasKey(t => new { t.DeclarationId, t.ProfessionalClass_Id });

            this.Property(t => t.DeclarationId)
                .IsRequired();

            this.Property(t => t.ProfessionalClass_Id)
                .IsRequired();

            this.Property(t => t.DeclarationCount)
                .IsRequired();

            this.ToTable("DeclarationClass", "Textbook");
            this.Property(t => t.DeclarationId).HasColumnName("DeclarationID");
            this.Property(t => t.ProfessionalClass_Id).HasColumnName("ProfessionalClass_ID");
            this.Property(t => t.DeclarationCount).HasColumnName("DeclarationCount");

            //学生班级
            this.HasRequired(t => t.ProfessionalClass)
                .WithMany(t => t.DeclarationClasses)
                .HasForeignKey(t => t.ProfessionalClass_Id);

            //学生用书申报
            this.HasRequired(t => t.Declaration)
                .WithMany(t => t.DeclarationClasses)
                .HasForeignKey(t => t.DeclarationId);
        }
    }
}
