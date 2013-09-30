using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class School : IAggregateRoot
    {
        /// <summary>
        /// ѧԺID
        /// </summary>
        public System.Guid SchoolID { get; set; }
        /// <summary>
        /// ѧԺ���
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// ѧԺ����
        /// </summary>
        public string Name { get; set; }
    }
}
