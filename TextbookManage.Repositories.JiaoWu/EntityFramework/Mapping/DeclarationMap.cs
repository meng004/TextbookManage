using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping
{
    public class DeclarationMap : EntityTypeConfiguration<Declaration>
    {
        public DeclarationMap()
        {
            // Primary Key
            this.HasKey(t => t.DeclarationId);

            // Properties
            this.Property(t => t.TeachingTask_Num)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.SchoolYear)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Mobile)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Telephone)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.NotNeedTextbook)
                .IsRequired();

            // Table & Column Mappings
            //this.ToTable("Declaration", "Textbook");
            this.Property(t => t.DeclarationId).HasColumnName("DeclarationID");
            this.Property(t => t.Textbook_Id).HasColumnName("Textbook_ID");
            this.Property(t => t.TeachingTask_Num).HasColumnName("TeachingTask_Num");
            //this.Property(t => t.ProfessionalClass_Id).HasColumnName("ProfessionalClass_ID");
            this.Property(t => t.Teacher_Id).HasColumnName("Teacher_ID");
            this.Property(t => t.Term).HasColumnName("Term");
            //this.Property(t => t.RecipientType).HasColumnName("RecipientType");
            this.Property(t => t.DeclarationCount).HasColumnName("DeclarationCount");
            this.Property(t => t.DeclarationDate).HasColumnName("DeclarationDate");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.ApprovalState).HasColumnName("ApprovalState");
            this.Property(t => t.HadViewFeedback).HasColumnName("HadViewFeedback");
            this.Property(t => t.Subscription_Id).HasColumnName("Subscription_ID");
            this.Property(t => t.NotNeedTextbook).HasColumnName("NotNeedTextbook");
            

            //标识子类的属性，不映射
            this.Ignore(t => t.RecipientType);

            //子类映射 
            Map<Declaration>(m =>
            {
                m.ToTable("Declaration", "Textbook");
                m.Requires("RecipientType").HasValue((int)RecipientType.全部);
            });
            Map<StudentDeclaration>(m =>
                m.Requires("RecipientType").HasValue((int)RecipientType.学生));
            Map<TeacherDeclaration>(m =>
                m.Requires("RecipientType").HasValue((int)RecipientType.教师));

            // 1对多关系
            //教学任务：申报
            this.HasRequired(t => t.TeachingTask)
                .WithMany(t => t.Declarations)
                .HasForeignKey(d => d.TeachingTask_Num);
            //教师：申报
            this.HasRequired(t => t.Declarant)
                .WithMany(t => t.Declarations)
                .HasForeignKey(t => t.Teacher_Id);
            //订单：申报
            this.HasRequired(t => t.Subscription)
                .WithMany(t => t.Declarations)
                .HasForeignKey(d => d.Subscription_Id);

            //教材：申报
            this.HasRequired(t => t.Textbook)
                .WithMany(t => t.Declarations)
                .HasForeignKey(d => d.Textbook_Id);



        }
    }
}
