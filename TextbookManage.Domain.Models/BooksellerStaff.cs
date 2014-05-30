using System;
using System.Collections.Generic;
using System.Linq;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 书商员工
    /// </summary>
    public class BooksellerStaff
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        public Guid BooksellerStaffId { get; set; }
        /// <summary>
        /// 书商ID
        /// </summary>
        public Guid Bookseller_Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string StaffName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// 书商
        /// </summary>
        public virtual Bookseller Bookseller { get; set; }
    }
}
