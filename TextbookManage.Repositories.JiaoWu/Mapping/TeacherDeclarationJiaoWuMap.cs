using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class TeacherDeclarationJiaoWuMap : EntityTypeConfiguration<TeacherDeclarationJiaoWu>
    {
        public TeacherDeclarationJiaoWuMap()
        {
            // Primary Key
            this.HasKey(t => t.DeclarationId);

            // Properties
            this.Property(t => t.SchoolYear)
                .IsRequired()
                .HasMaxLength(9);

            this.Property(t => t.SchoolTerm)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.DataSign_Id)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.Sfgd)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("V_TextBook_TeacherTextBook", "dbo");
            this.Property(t => t.DeclarationId).HasColumnName("JSKCYSID");
            this.Property(t => t.Textbook_Id).HasColumnName("JCID");
            this.Property(t => t.Course_Id).HasColumnName("KCID");            
            this.Property(t => t.School_Id).HasColumnName("YXSID");
            this.Property(t => t.Department_Id).HasColumnName("KSID");
            this.Property(t => t.SchoolYear).HasColumnName("XN");
            this.Property(t => t.SchoolTerm).HasColumnName("XQ");
            this.Property(t => t.DeclarationCount).HasColumnName("HDSL");
            this.Property(t => t.DataSign_Id).HasColumnName("SJBS");
            this.Property(t => t.Sfgd).HasColumnName("SFGD");

        }
    }
}
