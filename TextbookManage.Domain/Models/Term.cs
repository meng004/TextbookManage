using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Term : IAggregateRoot
    {
        //public int TermID { get; set; }
        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// �Ƿ�ǰѧ��ѧ��
        /// </summary>
        public string IsValid { get; set; }
    }
}
