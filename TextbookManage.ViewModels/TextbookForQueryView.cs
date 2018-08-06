using System;

namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [Serializable]
    public class TextbookForQueryView : TextbookView
    {
        /// <summary>
        /// 申报人
        /// </summary>
  
        public string Declarant { get; set; }
        /// <summary>
        /// 申报日期
        /// </summary>

        public string DeclarationDate { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
 
        public string ApprovalState { get; set; }
    }
}
