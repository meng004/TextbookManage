using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;


namespace TextbookManage.Repositories.Mapping
{
    public class DeclarationApprovalMap : EntityTypeConfiguration<DeclarationApproval>
    {
        public DeclarationApprovalMap()
        {
            //映射表
            ToTable("Approval_Declaration", "Textbook");   
            //属性            
            Property(t => t.Declaration_Id).HasColumnName("Declaration_ID");
            //审核记录与申报的 多对1关系
            //HasRequired(t => t.Declaration)
            //    .WithMany(d => d.Approvals)
            //    .HasForeignKey(f => f.Declaration_Id);
        }
    }
}
