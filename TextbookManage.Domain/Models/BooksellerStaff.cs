using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class BooksellerStaff
    {
        /// <summary>
        /// Ա��ID
        /// </summary>
        public int BooksellerStaffID { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        public int Bookseller_ID { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string StaffName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual Bookseller Bookseller { get; set; }
    }
}
