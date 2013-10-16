namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    /// <summary>
    /// 书商View 
    /// </summary>
    [DataContract]
    public class BooksellerView : BaseViewModel
    {

        /// <summary>
        /// 书商ID
        /// </summary>
        [DataMember]
        public string BooksellerId { get; set; }

        /// <summary>
        /// 书商名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

    }
}
