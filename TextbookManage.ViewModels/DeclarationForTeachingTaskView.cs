namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [DataContract]
    public class DeclarationForTeachingTaskView : DeclarationBaseView
    {

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
        /// 定价
        /// </summary>
        [DataMember]
        public string Price { get; set; }

    }
}
