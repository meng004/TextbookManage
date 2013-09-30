namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class BooksellerStaffView : ViewModelBase
    {
        /// <summary>
        /// Ա��ID
        /// </summary>
        [DataMember]
        public string BooksellerStaffID { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        [DataMember]
        public string Bookseller_ID { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [DataMember]
        public string StaffName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        [DataMember]
        public string Sex { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string BooksellerName { get; set; }
    }
}
