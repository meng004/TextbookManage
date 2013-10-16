namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [DataContract]
    public class StorageView : BaseViewModel
    {
        /// <summary>
        /// �ֿ�ID
        /// </summary>
        [DataMember]
        public string StorageId { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        [DataMember]
        public string BooksellerId { get; set; }
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
