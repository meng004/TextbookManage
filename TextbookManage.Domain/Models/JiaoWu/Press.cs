using System.Collections.Generic;


namespace TextbookManage.Domain.Models.JiaoWu
{
    /// <summary>
    /// 出版社
    /// </summary>
    public class Press : AggregateRoot
    {

        public Press()
        {
            Textbooks = new List<Textbook>();
        }

        #region 属性

        /// <summary>
        /// 出版社ID
        /// </summary>
        public string PressId { get; set; }
        /// <summary>
        /// Isbn前缀
        /// </summary>
        public string PreIsbn { get; set; }
        /// <summary>
        /// 出版社名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 出版社地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// 教材
        /// </summary>
        public virtual ICollection<Textbook> Textbooks { get; set; }
        #endregion
    }
}
