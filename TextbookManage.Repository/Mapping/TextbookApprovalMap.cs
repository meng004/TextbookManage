using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class TextbookApprovalMap : EntityTypeConfiguration<TextbookApproval>
    {
        public TextbookApprovalMap()
        {
            //映射表
            ToTable("Approval_Textbook", "Textbook");
            //属性
            Property(t => t.Textbook_ID).HasColumnName("Textbook_ID");
            //审核记录与教材的 多对1关系
            HasRequired(t => t.Textbook)
                .WithMany(d => d.TextbookApprovals)
                .HasForeignKey(f => f.Textbook_ID);
        }
    }
}
