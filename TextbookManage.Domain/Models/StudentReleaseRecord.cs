using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// ѧ�����ż�¼
    /// </summary>
    public class StudentReleaseRecord : ReleaseRecord
    {
        public StudentReleaseRecord()
        {
            this.RecipientType = RecipientType.Student;
        }
        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// �༶ID
        /// </summary>
        public System.Guid Class_ID { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// ѧ��ID
        /// </summary>
        public System.Guid Student_ID { get; set; }
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
        //public virtual ReleaseRecord ReleaseRecord { get; set; }
    }
}
