namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class BooksellerView : ViewModelBase
    {

        /// <summary>
        /// 书商ID
        /// </summary>
        [DataMember]
        public string BooksellerID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public string Contact { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember]
        public string Telephone { get; set; }

    }
}
