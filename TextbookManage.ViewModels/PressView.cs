namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [DataContract]
    public class PressView : BaseViewModel
    {
        /// <summary>
        /// 出版社ID
        /// </summary>
        [DataMember]
        public string PressId { get; set; }
        /// <summary>
        /// 出版社名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 出版社地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }

    }
}
