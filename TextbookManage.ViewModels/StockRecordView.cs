namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class StockRecordView:ViewModelBase
    {
        /// <summary>
        /// �������¼ID
        /// </summary>
        [DataMember]
        public string StockRecordID { get; set; }
        /// <summary>
        /// ���ID
        /// </summary>
        [DataMember]
        public string Inventory_ID { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        [DataMember]
        public string StockCount { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        [DataMember]
        public string StockDate { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        [DataMember]
        public string Operator { get; set; }
        /// <summary>
        /// ������ͣ�����false �� ���true
        /// </summary>
        [DataMember]
        public string StockType { get; set; }
        /// <summary>
        /// �ֿ�����
        /// </summary>
        [DataMember]
        public string StorageName { get; set; }
        /// <summary>
        /// �̲�����
        /// </summary>
        [DataMember]
        public string TextbookName { get; set; }
    }
}
