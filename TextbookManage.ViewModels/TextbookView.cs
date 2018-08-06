namespace TextbookManage.ViewModels
{
    using System;
    using System.Runtime.Serialization;
    [Serializable]
    public class TextbookView : BaseViewModel
    {

        /// <summary>
        /// 教材ID
        /// </summary>

        public string TextbookId { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
   
        public string Num { get; set; }
        /// <summary>
        /// 教材名称
        /// </summary>
        
        public string Name { get; set; }
        /// <summary>
        /// ISBN
        /// </summary>
        
        public string Isbn { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        
        public string Author { get; set; }
        /// <summary>
        /// 出版社ID
        /// </summary>
        
        public string PressId { get; set; }
        /// <summary>
        /// 出版社
        /// </summary>
        
        public string Press { get; set; }
        /// <summary>
        /// 出版社地址
        /// </summary>
        
        public string PressAddress { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        
        public string Edition { get; set; }
        /// <summary>
        /// 版次
        /// </summary>
        
        public string PrintCount { get; set; }
        /// <summary>
        /// 出版日期
        /// </summary>
        
        public string PublishDate { get; set; }
        /// <summary>
        /// 定价
        /// </summary>
        
        public string Price { get; set; }
        /// <summary>
        /// 教材类型
        /// </summary>
        
        public string TextbookType { get; set; }
        /// <summary>
        /// 是否自编教材
        /// </summary>
        
        public bool IsSelfCompile { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        
        public string PageCount { get; set; }


    }
}
