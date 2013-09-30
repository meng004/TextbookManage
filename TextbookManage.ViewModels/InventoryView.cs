namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    
    /// <summary>
    /// ���
    /// </summary>
    [DataContract]
    public class InventoryView:ViewModelBase
    {

        /// <summary>
        /// ���ID
        /// </summary>
        [DataMember]
        public string InventoryID { get; set; }
        /// <summary>
        /// �ֿ�ID
        /// </summary>
        [DataMember]
        public string Storage_ID { get; set; }
        /// <summary>
        /// �̲�ID
        /// </summary>
        [DataMember]
        public string Textbook_ID { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        [DataMember]
        public string ShelfNumber { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        [DataMember]
        public string InventoryCount { get; set; }

        /// <summary>
        /// �ֿ�
        /// </summary>
        [DataMember]
        public virtual string StorageName { get; set; }
        /// <summary>
        /// �̲�
        /// </summary>
        [DataMember]
        public virtual string TextbookName { get; set; }
    }
}
