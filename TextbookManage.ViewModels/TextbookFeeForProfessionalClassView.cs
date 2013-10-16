namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TextbookFeeForProfessionalClassView  :BaseViewModel
    {     
        /// <summary>
        /// 学生ID
        /// </summary>
        [DataMember]
        public string StudentId { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        [DataMember]
        public string StudentNum { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [DataMember]
        public string StudentName { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        [DataMember]
        public string TotalCount { get; set; }

        /// <summary>
        /// 码洋
        /// </summary>
        [DataMember]
        public string TotalRetailPrice { get; set; }

        /// <summary>
        /// 实洋
        /// </summary>
        [DataMember]
        public string DiscountTotalPrice { get; set; }
    }
}
