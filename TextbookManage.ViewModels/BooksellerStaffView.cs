namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class BooksellerStaffView : ViewModelBase
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        [DataMember]
        public string BooksellerStaffID { get; set; }
        /// <summary>
        /// 书商ID
        /// </summary>
        [DataMember]
        public string Bookseller_ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string StaffName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public string Sex { get; set; }
        /// <summary>
        /// 书商名称
        /// </summary>
        [DataMember]
        public string BooksellerName { get; set; }
    }
}
