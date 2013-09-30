using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class DeclarationMap : EntityTypeConfiguration<Declaration>
    {
        public DeclarationMap()
        {
            // Primary Key
            this.HasKey(t => t.DeclarationID);

            // Properties
            this.Property(t => t.TeachingTask_Num)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Term)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Mobile)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Telephone)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Declaration", "Textbook");
            this.Property(t => t.DeclarationID).HasColumnName("DeclarationID");
            this.Property(t => t.Textbook_ID).HasColumnName("Textbook_ID");
            this.Property(t => t.TeachingTask_Num).HasColumnName("TeachingTask_Num");
            this.Property(t => t.Teacher_ID).HasColumnName("Teacher_ID");
            this.Property(t => t.Term).HasColumnName("Term");
            //this.Property(t => t.RecipientType).HasColumnName("RecipientType");
            this.Property(t => t.DeclarationCount).HasColumnName("DeclarationCount");
            this.Property(t => t.DeclarationDate).HasColumnName("DeclarationDate");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.ApprovalState).HasColumnName("ApprovalState");
            this.Property(t => t.HadViewFeedback).HasColumnName("HadViewFeedback");

            //��ʶ��������ԣ���ӳ��
            this.Ignore(t => t.RecipientType);

            //����ӳ�� 
            //Map<Declaration>(m => 
            //{ 
            //    m.ToTable("Declaration", "Textbook"); 
            //    m.Requires("RecipientType").HasValue(0); 
            //})
            Map<StudentDeclaration>(m =>
                m.Requires("RecipientType").HasValue((int)RecipientType.Student));
            Map<TeacherDeclaration>(m =>
                m.Requires("RecipientType").HasValue((int)RecipientType.Teacher));

            // ��Զ��ϵ
            this.HasMany(t => t.Subscriptions)
                .WithMany(t => t.Declarations)
                .Map(m =>
                    {
                        m.ToTable("SubscriptionDeclaration", "Textbook");
                        m.MapLeftKey("Declaration_ID");
                        m.MapRightKey("Subscription_ID");
                    });

            //���1��ϵ
            this.HasRequired(t => t.Textbook)
                .WithMany(t => t.Declarations)
                .HasForeignKey(d => d.Textbook_ID);

        }
    }
}
