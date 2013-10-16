namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    /// <summary>
    /// 学生实发教材
    /// </summary>
    [DataContract]
    public class StudentReleaseDetailView :BaseViewModel
    {
        /// <summary>
        /// 教材ID
        /// </summary>
        [DataMember]
        public string TextbookId { get; set; }

        /// <summary>
        /// 教材名称
        /// </summary>
        [DataMember]
        public string TextbookName { get; set; }

        /// <summary>
        /// 零售价
        /// </summary>
        [DataMember]
        public string RetailPrice { get; set; }

        /// <summary>
        /// 折后价
        /// </summary>
        [DataMember]
        public string DiscountPrice { get; set; }

        /// <summary>
        /// 学年学期
        /// </summary>
        [DataMember]
        public string Term { get; set; }

        /// <summary>
        /// 学院
        /// </summary>
        [DataMember]
        public string SchoolName { get; set; }

        /// <summary>
        /// 班级
        /// </summary>
        [DataMember]
        public string ClassName { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        [DataMember]
        public string StudentNum { get; set; }

        /// <summary>
        /// 发放数量
        /// </summary>
        [DataMember]
        public string ReleaseCount { get; set; }

        /// <summary>
        /// 领用人
        /// </summary>
        [DataMember]
        public string Recipient { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember]
        public string Telephone { get; set; }

        /// <summary>
        /// 领用时间
        /// </summary>
        [DataMember]
        public string RecipientDate { get; set; }
    }
}
