using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// ���ݱ�ʶ
    /// </summary>
    public class DataSign : IAggregateRoot
    {
        //public int DataSignID { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }
    }
}
