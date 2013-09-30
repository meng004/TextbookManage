namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class StockRecordView:ViewModelBase
    {
        /// <summary>
        /// 库存变更记录ID
        /// </summary>
        [DataMember]
        public string StockRecordID { get; set; }
        /// <summary>
        /// 库存ID
        /// </summary>
        [DataMember]
        public string Inventory_ID { get; set; }
        /// <summary>
        /// 变更数量
        /// </summary>
        [DataMember]
        public string StockCount { get; set; }
        /// <summary>
        /// 变更日期
        /// </summary>
        [DataMember]
        public string StockDate { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DataMember]
        public string Operator { get; set; }
        /// <summary>
        /// 变更类型，出库false 或 入库true
        /// </summary>
        [DataMember]
        public string StockType { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public string StorageName { get; set; }
        /// <summary>
        /// 教材名称
        /// </summary>
        [DataMember]
        public string TextbookName { get; set; }
    }
}
