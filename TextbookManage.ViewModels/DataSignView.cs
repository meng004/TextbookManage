namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    /// <summary>
    /// 数据标识
    /// </summary>
    [DataContract]
    public class DataSignView:ViewModelBase 
    {
        //public int DataSignID { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        public string Num { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
