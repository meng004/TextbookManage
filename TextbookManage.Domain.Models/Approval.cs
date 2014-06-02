using System;
namespace TextbookManage.Domain.Models
{
    public class Approval 
    {
        /// <summary>
        /// ��˼�¼ID
        /// </summary>
        public Guid ApprovalId { get; set; }
        /// <summary>
        /// ��˲���
        /// </summary>
        public string Division { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        public string Auditor { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public System.DateTime ApprovalDate { get; set; }
        /// <summary>
        /// ��������ͬ���ͬ��
        /// </summary>
        public bool Suggestion { get; set; }
        /// <summary>
        /// ˵������ע
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// ��˶����������걨���ظ�
        /// </summary>
        public ApprovalTarget ApprovalTarget { get; set; }
        //public virtual Declaration Declaration { get; set; }
    }
}
