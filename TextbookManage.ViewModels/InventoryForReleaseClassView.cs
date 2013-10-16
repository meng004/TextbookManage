using System.Runtime.Serialization;
using System.Collections.Generic;


namespace TextbookManage.ViewModels
{
    /// <summary>
    /// 用于班级发放 
    /// </summary>
    [DataContract]
    public class InventoryForReleaseClassView : InventoryView
    {
        /// <summary>
        /// 折扣
        /// </summary>
        [DataMember]
        public decimal Discount { get; set; }
        /// <summary>
        /// 折后价
        /// </summary>
        [DataMember]
        public decimal DiscountPrice { get; set; }
        /// <summary>
        /// 申报数量
        /// </summary>
        [DataMember]
        public int DeclarationCount { get; set; }
        /// <summary>
        /// 发放数量
        /// </summary>
        [DataMember]
        public int ReleaseCount { get; set; }
        /// <summary>
        /// 人均数量
        /// </summary>
        [DataMember]
        public int AverageCount { get; set; }
        /// <summary>
        /// 领用人名单
        /// </summary>
        [DataMember]
        public IEnumerable<StudentView> Students { get; set; }
    }
}
