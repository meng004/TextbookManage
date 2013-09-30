namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;
    
    [DataContract]
    public class DeclarationView:ViewModelBase
    {
        /// <summary>
        /// 申报ID
        /// </summary>
        [DataMember]
        public string DeclarationID { get; set; }
        /// <summary>
        /// 教材ID
        /// </summary>
        [DataMember]
        public string Textbook_ID { get; set; }
        /// <summary>
        /// 教学班编号
        /// </summary>
        [DataMember]
        public string TeachingTask_Num { get; set; }
        /// <summary>
        /// 申报人
        /// </summary>
        [DataMember]
        public string Teacher_ID { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        [DataMember]
        public string Term { get; set; }
        /// <summary>
        /// 领用人类型，学生或教师
        /// </summary>
        [DataMember]
        public string RecipientType { get; set; }
        /// <summary>
        /// 申报数量
        /// </summary>
        [DataMember]
        public string DeclarationCount { get; set; }
        /// <summary>
        /// 申报日期
        /// </summary>
        [DataMember]
        public string DeclarationDate { get; set; }
        /// <summary>
        /// 移动电话
        /// </summary>
        [DataMember]
        public string Mobile { get; set; }
        /// <summary>
        /// 固定电话
        /// </summary>
        [DataMember]
        public string Telephone { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        [DataMember]
        public string ApprovalState { get; set; }
        /// <summary>
        /// 是否已查看回告
        /// </summary>
        [DataMember]
        public string HadViewFeedback { get; set; }
        /// <summary>
        /// 回告状态
        /// </summary>
        [DataMember]
        public string FeedbackState { get; set; }
    }
}
