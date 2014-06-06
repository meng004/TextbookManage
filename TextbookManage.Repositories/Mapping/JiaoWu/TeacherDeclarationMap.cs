using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class TeacherDeclarationMap : EntityTypeConfiguration<TeacherDeclaration>
    {
        public TeacherDeclarationMap()
        {
            this.HasKey(t => t.ID);

            this.ToTable("TeacherDeclaration", "Textbook");

            //this.Property(t => t.ID).HasColumnName("JSKCYSID");
            this.Property(t => t.Subscription_Id).HasColumnName("Subscription_ID");
            this.Property(t => t.HadViewFeedback).HasColumnName("HadViewFeedback");
            this.Property(t => t.ViewFeedbackDate).HasColumnName("ViewFeedbackDate");

            // 1对多关系

            //书商订单：教师用书申报
            this.HasRequired(t => t.Subscription)
                .WithMany(t => t.TeacherDeclarations)
                .HasForeignKey(d => d.Subscription_Id);

            //教材：申报
            //this.HasRequired(t => t.Textbook)
            //    .WithMany(t => t.TeacherDeclarations)
            //    .HasForeignKey(d => d.Textbook_Id);

            //部门：教师用书申报，1:N
            //this.HasRequired(t => t.Department)
            //    .WithMany(t => t.TeacherDeclarations)
            //    .HasForeignKey(d => d.Department_Id);
        }
    }
}