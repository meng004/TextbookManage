namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [DataContract]
    public class StorageView : BaseViewModel
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        [DataMember]
        public string StorageId { get; set; }
        /// <summary>
        /// 书商ID
        /// </summary>
        [DataMember]
        public string BooksellerId { get; set; }
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
