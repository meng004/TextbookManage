namespace TextbookManage.ViewModels
{     
    using System.Runtime.Serialization;
    
    [DataContract]
    public class TextbookFeeForStudentView :BaseViewModel
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
        /// ISBN
        /// </summary>
        [DataMember]
        public string Isbn { get; set; }
                    
        /// <summary>
        /// 作者
        /// </summary>
        [DataMember]
        public string Author { get; set; }

        /// <summary>
        /// 出版社
        /// </summary>
        [DataMember]
        public string Press { get; set; }

        /// <summary>
        /// 零售价
        /// </summary>
        [DataMember]
        public string RetailPrice { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        [DataMember]
        public string Discount { get; set; }

        /// <summary>
        /// 发放数量
        /// </summary>
        [DataMember]
        public string ReleaseCount { get; set; }

        /// <summary>
        /// 折后价
        /// </summary>
        [DataMember]
        public string DiscountPrice { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        [DataMember]
        public string CourseName { get; set; }

    }
}
