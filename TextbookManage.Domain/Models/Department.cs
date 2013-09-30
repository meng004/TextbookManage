using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Department : IAggregateRoot
    {
        /// <summary>
        /// ϵ������ID
        /// </summary>
        public System.Guid DepartmentID { get; set; }
        /// <summary>
        /// ϵ�����ұ��
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ����ѧԺID
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
