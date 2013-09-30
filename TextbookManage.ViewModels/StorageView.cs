namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [DataContract]
    public class StorageView : ViewModelBase
    {
        /// <summary>
        /// �ֿ�ID
        /// </summary>
        [DataMember]
        public string StorageID { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        [DataMember]
        public string Bookseller_ID { get; set; }
        /// <summary>
        /// �ֿ�����
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// �ֿ��ַ
        /// </summary>
        [DataMember]
        public string Address { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string BooksellerName { get; set; }

    }
}
