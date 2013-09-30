namespace TextbookManage.Domain.Models
{
    public class TextbookApproval : Approval
    {
        public TextbookApproval()
        {
            ApprovalTarget = ApprovalTarget.Textbook;
        }


        /// <summary>
        /// 教材ID
        /// </summary>
        public int Textbook_ID { get; set; }
        /// <summary>
        /// 教材
        /// </summary>
        public virtual Textbook Textbook { get; set; }
    }
}
