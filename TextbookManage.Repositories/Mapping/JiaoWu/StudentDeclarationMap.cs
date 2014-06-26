using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class StudentDeclarationMap : EntityTypeConfiguration<StudentDeclaration>
    {
        public StudentDeclarationMap()
        {
            this.HasKey(t => t.ID);

            this.ToTable("StudentDeclaration", "Textbook");

            this.Property(t => t.ID).HasColumnName("XSYSID");
            this.Property(t => t.Subscription_Id).HasColumnName("Subscription_ID");
            this.Property(t => t.HadViewFeedback).HasColumnName("HadViewFeedback");
            this.Property(t => t.ViewFeedbackDate).HasColumnName("ViewFeedbackDate");

            // 1对多关系
            //书商订单：学生用书申报
            this.HasRequired(t => t.Subscription)
                .WithMany(t=>t.StudentDeclarations)
                .HasForeignKey(d => d.Subscription_Id)
                .WillCascadeOnDelete(true);

            //学生用书申报：教务学生用书申报，1：1
            this.HasRequired(t => t.DeclarationJiaoWu)
                .WithOptional(t => t.DeclarationTextbook);


            //教材：学生用书申报
            //this.HasRequired(t => t.Textbook)
            //    .WithMany(t => t.StudentDeclarations)
            //    .HasForeignKey(d => d.Textbook_Id);

            //部门：学生用书申报
            //this.HasRequired(t => t.Department)
            //    .WithMany(t => t.StudentDeclarations)
            //    .HasForeignKey(d => d.Department_Id);
        }
    }
}
