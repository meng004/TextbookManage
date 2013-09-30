using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Teacher : IAggregateRoot
    {
        /// <summary>
        /// ��ʦID
        /// </summary>
        public System.Guid TeacherID { get; set; }
        /// <summary>
        /// ��ʦ���
        /// </summary>
        public string TeacherNum { get; set; }
        /// <summary>
        /// ��ʦ����
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        public string Gender { get; set; }
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
        /// <summary>
        /// ϵ������ID
        /// </summary>
        public Nullable<System.Guid> Department_ID { get; set; }
        //public string DepartmentNum { get; set; }
        /// <summary>
        /// ϵ����������
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
