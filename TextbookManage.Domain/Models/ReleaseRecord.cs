using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 发放记录
    /// </summary>
    public abstract class ReleaseRecord : AggregateRoot
    {
        /// <summary>
        /// 发放记录ID
        /// </summary>
        //public System.Guid ReleaseRecordId { get; set; }
        /// <summary>
        /// 库存变更记录ID
        /// </summary>
        public System.Guid? StockRecord_Id { get; set; }
        /// <summary>
        /// 教材ID
        /// </summary>
        public Guid Textbook_Id { get; set; }
        /// <summary>
        /// 教材编号
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 教材名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ISBN
        /// </summary>
        public string Isbn { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 出版社
        /// </summary>
        public string Press { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public int Edition { get; set; }
        /// <summary>
        /// 版次
        /// </summary>
        public int PrintCount { get; set; }
        /// <summary>
        /// 出版日期
        /// </summary>
        public System.DateTime PublishDate { get; set; }
        /// <summary>
        /// 定价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 折扣率
        /// </summary>
        public Nullable<decimal> Discount { get; set; }
        /// <summary>
        /// 折后价
        /// </summary>
        public Nullable<decimal> DiscountPrice { get; set; }
        /// <summary>
        /// 教材类型
        /// </summary>
        public string TextbookType { get; set; }
        /// <summary>
        /// 学院ID
        /// </summary>
        public System.Guid School_Id { get; set; }
        /// <summary>
        /// 学院名称
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        public SchoolYearTerm SchoolYearTerm { get; set; }
        /// <summary>
        /// 发放日期
        /// </summary>
        public System.DateTime? ReleaseDate { get; set; }
        /// <summary>
        /// 发放数量
        /// </summary>
        public int ReleaseCount { get; set; }
        /// <summary>
        /// 书商ID
        /// </summary>
        public Guid Bookseller_Id { get; set; }
        /// <summary>
        /// 书商名称
        /// </summary>
        public string BooksellerName { get; set; }
        /// <summary>
        /// 出库记录
        /// </summary>
        public virtual OutStockRecord OutStockRecord { get; set; }
    }
}
