using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Term : IAggregateRoot
    {
        //public int TermID { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否当前学年学期
        /// </summary>
        public string IsValid { get; set; }
    }
}
