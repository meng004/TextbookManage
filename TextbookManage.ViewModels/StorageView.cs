namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [DataContract]
    public class StorageView : ViewModelBase
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        [DataMember]
        public string StorageID { get; set; }
        /// <summary>
        /// 书商ID
        /// </summary>
        [DataMember]
        public string Bookseller_ID { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 仓库地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }
        /// <summary>
        /// 所属书商
        /// </summary>
        [DataMember]
        public string BooksellerName { get; set; }

    }
}
