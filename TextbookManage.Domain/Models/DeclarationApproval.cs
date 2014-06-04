using TextbookManage.Domain.Models.JiaoWu;
namespace TextbookManage.Domain.Models
{
    public class DeclarationApproval : Approval
    {
        public DeclarationApproval()
        {
            this.ApprovalTarget = ApprovalTarget.Declaration;
        }

        /// <summary>
        /// 用书申报ID
        /// </summary>
        public System.Guid Declaration_Id { get; set; }
        /// <summary>
        /// 用书申报
        /// </summary>
        public virtual Declaration Declaration { get; set; }
    }
}
