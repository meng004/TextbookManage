using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class FeedbackApprovalMap:EntityTypeConfiguration<FeedbackApproval>
    {
        public FeedbackApprovalMap()
        {
            //表
            ToTable("Approval_Feedback", "Textbook");
            //属性
            Property(t => t.Feedback_Id).HasColumnName("Feedback_ID");
            //审核记录与回告 多对1关系
            HasRequired(t => t.Feedback)
                .WithMany(t => t.Approvals)
                .HasForeignKey(t => t.Feedback_Id);
        }
    }
}
