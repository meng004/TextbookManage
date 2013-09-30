using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class TeacherReleaseRecord : ReleaseRecord
    {
        public TeacherReleaseRecord()
        {
            this.RecipientType = RecipientType.Teacher;
        }
        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// ϵ������ID
        /// </summary>
        public System.Guid Department_ID { get; set; }
        /// <summary>
        /// ϵ����������
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// ��ʦID
        /// </summary>
        public System.Guid Teacher_ID { get; set; }
        /// <summary>
        /// ��ʦ����
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// ����֤������
        /// </summary>
        public Nullable<int> IDCardType { get; set; }
        /// <summary>
        /// ֤�����
        /// </summary>
        public string IDCardNum { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string Barcode { get; set; }
        //public virtual ReleaseRecord ReleaseRecord { get; set; }
    }
}
