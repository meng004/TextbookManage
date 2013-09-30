using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Student : IAggregateRoot
    {
        /// <summary>
        /// ѧ��ID
        /// </summary>
        public System.Guid StudentID { get; set; }
        /// <summary>
        /// ѧ�����
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
        /// �༶ID
        /// </summary>
        public Nullable<System.Guid> Class_ID { get; set; }
        /// <summary>
        /// �༶���
        /// </summary>
        public string ClassNum { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// �꼶
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// ѧԺID
        /// </summary>
        public Nullable<System.Guid> School_ID { get; set; }
        /// <summary>
        /// ѧԺ���
        /// </summary>
        public string SchoolNum { get; set; }
        /// <summary>
        /// ѧԺ����
        /// </summary>
        public string SchoolName { get; set; }
    }
}
