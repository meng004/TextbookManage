namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class BooksellerView : ViewModelBase
    {

        /// <summary>
        /// ����ID
        /// </summary>
        [DataMember]
        public string BooksellerID { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        [DataMember]
        public string Contact { get; set; }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        [DataMember]
        public string Telephone { get; set; }

    }
}
