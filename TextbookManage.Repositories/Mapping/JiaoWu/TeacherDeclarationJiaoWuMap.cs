using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class TeacherDeclarationJiaoWuMap : EntityTypeConfiguration<TeacherDeclarationJiaoWu>
    {
        public TeacherDeclarationJiaoWuMap()
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
            this.ToTable("V_TextBook_TeacherTextBook", "dbo");
            this.Property(t => t.ID).HasColumnName("JSKCYSID");
            this.Property(t => t.Textbook_Id).HasColumnName("JCID");
            this.Property(t => t.Course_Id).HasColumnName("KCID");            
            this.Property(t => t.School_Id).HasColumnName("YXSID");
            this.Property(t => t.Department_Id).HasColumnName("KSID");
            this.Property(t => t.SchoolYearTerm.Year).HasColumnName("XN");
            this.Property(t => t.SchoolYearTerm.Term).HasColumnName("XQ");
            this.Property(t => t.DeclarationCount).HasColumnName("HDSL");
            this.Property(t => t.DataSign_Id).HasColumnName("SJBS");
            this.Property(t => t.Sfgd).HasColumnName("SFGD");

            //�̲ģ���ʦ�����걨����1:N
            this.HasRequired(t => t.Textbook)
                .WithMany(t => t.TeacherDeclarationJiaoWus)
                .HasForeignKey(t => t.Textbook_Id);
            //���ţ������ʦ�����걨��1��N
            this.HasRequired(t => t.Department)
                .WithMany(t => t.TeacherDeclarationJiaoWus)
                .HasForeignKey(t => t.Department_Id);
            //�γ̣������ʦ�����걨��1��N
            this.HasRequired(t => t.Course)
                .WithMany(t => t.TeacherDeclarationJiaoWus)
                .HasForeignKey(d => d.Course_Id);
            //ѧԺ�������ʦ�����걨��1��N
            this.HasRequired(t => t.School)
                .WithMany(t => t.TeacherDeclarationJiaoWus)
                .HasForeignKey(d => d.School_Id);
            //���ݱ�ʶ�������ʦ�����걨��1��N
            this.HasRequired(t => t.DataSign)
                .WithMany(t => t.TeacherDeclarationJiaoWus)
                .HasForeignKey(d => d.DataSign_Id);
        }
    }
}
