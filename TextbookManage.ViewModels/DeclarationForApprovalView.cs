namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [DataContract]
    public class DeclarationForApprovalView : DeclarationBaseView
    {

        /// <summary>
        /// 数据标识
        /// </summary>
        [DataMember]
        public string DataSignName { get; set; }
        /// <summary>
        /// 课程编号
        /// </summary>
        [DataMember]
        public string CourseNum { set; get; }
        /// <summary>
        /// 课程名称
        /// </summary>
        [DataMember]
        public string CourseName { set; get; }
        /// <summary>
        /// 领用人类型
        /// </summary>
        [DataMember]
        public string RecipientType { get; set; }

    }
}
