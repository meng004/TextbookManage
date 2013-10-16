namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [DataContract]
    public class DeclarationBaseView : BaseViewModel
    {
        /// <summary>
        /// 教学班编号
        /// </summary>
        [DataMember]
        public string TeachingTaskNum { get; set; }
        /// <summary>
        /// 申报ID
        /// </summary>
        [DataMember]
        public string DeclarationId { get; set; }
        /// <summary>
        /// 学生班级
        /// </summary>
        [DataMember]
        public string ProfessionalClassName { get; set; }
        /// <summary>
        /// 教材ID
        /// </summary>
        [DataMember]
        public string TextbookId { get; set; }
        /// <summary>
        /// 教材编号
        /// </summary>
        [DataMember]
        public string TextbookNum { get; set; }
        /// <summary>
        /// 教材名称
        /// </summary>
        [DataMember]
        public string TextbookName { get; set; }
        /// <summary>
        /// 申报人
        /// </summary>
        [DataMember]
        public string Declarant { get; set; }
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
        /// 手机
        /// </summary>
        [DataMember]
        public string Mobile { get; set; }
        /// <summary>
        /// 固定电话
        /// </summary>
        [DataMember]
        public string Telephone { get; set; }

    }
}
