namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    
    /// <summary>
    /// ¿â´æ
    /// </summary>
    [DataContract]
    public class InventoryView:ViewModelBase
    {

        /// <summary>
        /// ¿â´æID
        /// </summary>
        [DataMember]
        public string InventoryID { get; set; }
        /// <summary>
        /// ²Ö¿âID
        /// </summary>
        [DataMember]
        public string Storage_ID { get; set; }
        /// <summary>
        /// ½Ì²ÄID
        /// </summary>
        [DataMember]
        public string Textbook_ID { get; set; }
        /// <summary>
        /// ¼ÜÎ»ºÅ
        /// </summary>
        [DataMember]
        public string ShelfNumber { get; set; }
        /// <summary>
        /// ¿â´æÊýÁ¿
        /// </summary>
        [DataMember]
        public string InventoryCount { get; set; }

        /// <summary>
        /// ²Ö¿â
        /// </summary>
        [DataMember]
        public virtual string StorageName { get; set; }
        /// <summary>
        /// ½Ì²Ä
        /// </summary>
        [DataMember]
        public virtual string TextbookName { get; set; }
    }
}
