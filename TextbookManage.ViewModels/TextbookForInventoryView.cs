using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    [DataContract]
    public class TextbookForInventoryView : TextbookView
    {
        /// <summary>
        /// 计划数
        /// </summary>
        [DataMember]
        public string DeclarationCount { get; set; }

        /// <summary>
        /// 库存数
        /// </summary>
        [DataMember]
        public string InventoryCount { get; set; }
    }
}
