using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class TeacherDeclarationMap : EntityTypeConfiguration<TeacherDeclaration>
    {
        public TeacherDeclarationMap()
        {
            this.HasKey(t => t.DeclarationId);

            this.ToTable("TeacherDeclaration", "Textbook");

            this.Property(t => t.DeclarationId).HasColumnName("DeclarationID");
            this.Property(t => t.Subscription_Id).HasColumnName("Subscription_ID");
            this.Property(t => t.HadViewFeedback).HasColumnName("HadViewFeedback");
            this.Property(t => t.ViewFeedbackDate).HasColumnName("ViewFeedbackDate");

            // 1对多关系

            //订单：学生用书申报
            this.HasRequired(t => t.Subscription)
                .WithMany(t => t.TeacherDeclarations)
                .HasForeignKey(d => d.Subscription_Id);

            //教材：申报
            this.HasRequired(t => t.Textbook)
                .WithMany(t => t.TeacherDeclarations)
                .HasForeignKey(d => d.Textbook_Id);
        }
    }
}