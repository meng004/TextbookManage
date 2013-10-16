using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    [DataContract]
    public class StockRecordView : TextbookView
    {
        /// <summary>
        /// 入库ID
        /// </summary>
        [DataMember]
        public string StockRecordId { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        [DataMember]
        public string StockCount { get; set; }
        /// <summary>
        /// 入库日期
        /// </summary>
        [DataMember]
        public string StockDate { get; set; }
        /// <summary>
        /// 入库人
        /// </summary>
        [DataMember]
        public string Operator { get; set; }
        /// <summary>
        /// 架位号
        /// </summary>
        [DataMember]
        public string ShelfNumber { get; set; }

    }
}
