using System;
using System.Collections.Generic;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// ѧ�����ż�¼
    /// </summary>
    public class StudentReleaseRecord : ReleaseRecord
    {

        #region ����

        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// �༶ID
        /// </summary>
        public System.Guid Class_Id { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// ѧ��ID
        /// </summary>
        public System.Guid Student_Id { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        public string StudentNum { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// ������1����
        /// </summary>
        public string Recipient1Name { get; set; }
        /// <summary>
        /// ������1�绰
        /// </summary>
        public string Recipient1Phone { get; set; }
        /// <summary>
        /// ������2����
        /// </summary>
        public string Recipient2Name { get; set; }
        /// <summary>
        /// ������2�绰
        /// </summary>
        public string Recipient2Phone { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        public virtual Student Student { get; set; }
        
        #endregion
    }
}
