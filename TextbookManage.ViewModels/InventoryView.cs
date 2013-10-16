using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    [DataContract]
    public class InventoryView : TextbookView
    {
        /// <summary>
        /// 库存Id
        /// </summary>
        [DataMember]
        public string InventoryId { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        [DataMember]
        public string StorageId { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        [DataMember]
        public int InventoryCount { get; set; }
        /// <summary>
        /// 架位号
        /// </summary>
        [DataMember]
        public string ShelfNumber { get; set; }
    }
}
