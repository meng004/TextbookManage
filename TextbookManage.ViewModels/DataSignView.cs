namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class DataSignView : BaseViewModel
    {
        /// <summary>
        /// 数据标识Id
        /// </summary>
        [DataMember]
        public string DataSignId { get; set; }
        /// <summary>
        /// 数据标识名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
