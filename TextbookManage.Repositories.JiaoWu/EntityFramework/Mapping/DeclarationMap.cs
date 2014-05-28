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
            

            //��ʶ��������ԣ���ӳ��
            this.Ignore(t => t.RecipientType);

            //����ӳ�� 
            Map<Declaration>(m =>
            {
                m.ToTable("Declaration", "Textbook");
                m.Requires("RecipientType").HasValue((int)RecipientType.ȫ��);
            });
            Map<StudentDeclaration>(m =>
                m.Requires("RecipientType").HasValue((int)RecipientType.ѧ��));
            Map<TeacherDeclaration>(m =>
                m.Requires("RecipientType").HasValue((int)RecipientType.��ʦ));

            // 1�Զ��ϵ
            //��ѧ�����걨
            this.HasRequired(t => t.TeachingTask)
                .WithMany(t => t.Declarations)
                .HasForeignKey(d => d.TeachingTask_Num);
            //��ʦ���걨
            this.HasRequired(t => t.Declarant)
                .WithMany(t => t.Declarations)
                .HasForeignKey(t => t.Teacher_Id);
            //�������걨
            this.HasRequired(t => t.Subscription)
                .WithMany(t => t.Declarations)
                .HasForeignKey(d => d.Subscription_Id);

            //�̲ģ��걨
            this.HasRequired(t => t.Textbook)
                .WithMany(t => t.Declarations)
                .HasForeignKey(d => d.Textbook_Id);



        }
    }
}
