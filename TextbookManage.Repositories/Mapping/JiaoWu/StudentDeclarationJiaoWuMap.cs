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
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.DataSign_Id)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.Sfgd)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("V_TextBook_StudentTextBook", "dbo");
            this.Property(t => t.ID).HasColumnName("XSYSID");
            this.Property(t => t.Textbook_Id).HasColumnName("JCID");
            this.Property(t => t.Course_Id).HasColumnName("KCID");
            this.Property(t => t.School_Id).HasColumnName("YXSID");
            this.Property(t => t.Department_Id).HasColumnName("KSID");
            this.Property(t => t.SchoolYearTerm.Year).HasColumnName("XN");
            this.Property(t => t.SchoolYearTerm.Term).HasColumnName("XQ");
            this.Property(t => t.DeclarationCount).HasColumnName("ZDSL");
            this.Property(t => t.DataSign_Id).HasColumnName("SJBS");
            this.Property(t => t.Sfgd).HasColumnName("SFGD");

            //教材：学生用书申报教务，1:N
            this.HasRequired(t => t.Textbook)
                .WithMany(t => t.StudentDeclarationJiaoWus)
                .HasForeignKey(t => t.Textbook_Id);
            //部门：教务学生用书申报，1：N
            this.HasRequired(t => t.Department)
                .WithMany(t => t.StudentDeclarationJiaoWus)
                .HasForeignKey(t => t.Department_Id);
            //课程：教务学生用书申报，1：N
            this.HasRequired(t => t.Course)
                .WithMany(t => t.StudentDeclarationJiaoWus)
                .HasForeignKey(d => d.Course_Id);
            //学院：教务学生用书申报，1：N
            this.HasRequired(t => t.School)
                .WithMany(t => t.StudentDeclarationJiaoWus)
                .HasForeignKey(d => d.School_Id);
            //数据标识:教务学生用书申报，1：N
            this.HasRequired(t => t.DataSign)
                .WithMany(t => t.StudentDeclarationJiaoWus)
                .HasForeignKey(t => t.DataSign_Id);
        }
    }
}
