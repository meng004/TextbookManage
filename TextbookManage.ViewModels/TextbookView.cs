namespace TextbookManage.ViewModels
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class TextbookView : BaseViewModel
    {

        /// <summary>
        /// 教材ID
        /// </summary>
        [DataMember]
        public string TextbookId { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        public string Num { get; set; }
        /// <summary>
        /// 教材名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
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
        /// 出版社ID
        /// </summary>
        [DataMember]
        public string PressId { get; set; }
        /// <summary>
        /// 出版社
        /// </summary>
        [DataMember]
        public string Press { get; set; }
        /// <summary>
        /// 出版社地址
        /// </summary>
        [DataMember]
        public string PressAddress { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        [DataMember]
        public string Edition { get; set; }
        /// <summary>
        /// 版次
        /// </summary>
        [DataMember]
        public string PrintCount { get; set; }
        /// <summary>
        /// 出版日期
        /// </summary>
        [DataMember]
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 定价
        /// </summary>
        [DataMember]
        public decimal Price { get; set; }
        /// <summary>
        /// 教材类型
        /// </summary>
        [DataMember]
        public string TextbookType { get; set; }
        /// <summary>
        /// 是否自编教材
        /// </summary>
        [DataMember]
        public string IsSelfCompile { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        [DataMember]
        public string PageCount { get; set; }


    }
}
