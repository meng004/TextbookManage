using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class StudentDeclarationJiaoWuMap : EntityTypeConfiguration<StudentDeclarationJiaoWu>
    {
        public StudentDeclarationJiaoWuMap()
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
            this.ToTable("V_TextBook_StudentTextBook", "dbo");
            this.Property(t => t.DeclarationId).HasColumnName("XSYSID");
            this.Property(t => t.Textbook_Id).HasColumnName("JCID");
            this.Property(t => t.Course_Id).HasColumnName("KCID");
            this.Property(t => t.School_Id).HasColumnName("YXSID");
            this.Property(t => t.Department_Id).HasColumnName("KSID");
            this.Property(t => t.SchoolYear).HasColumnName("XN");
            this.Property(t => t.SchoolTerm).HasColumnName("XQ");
            this.Property(t => t.DeclarationCount).HasColumnName("ZDSL");
            this.Property(t => t.DataSign_Id).HasColumnName("SJBS");
            this.Property(t => t.Sfgd).HasColumnName("SFGD");

        }
    }
}
