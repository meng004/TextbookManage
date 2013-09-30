using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class BooksellerStaff
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        public int BooksellerStaffID { get; set; }
        /// <summary>
        /// 书商ID
        /// </summary>
        public int Bookseller_ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string StaffName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 书商
        /// </summary>
        public virtual Bookseller Bookseller { get; set; }
    }
}
