namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    /// <summary>
    /// 查询申报View
    /// </summary>
    [DataContract]
    public class DeclarationForQueryView : DeclarationBaseView
    {

        #region 申报信息
         
        /// <summary>
        /// 审核状态
        /// </summary>
        [DataMember]
        public string ApprovalState { get; set; }
        /// <summary>
        /// 回告状态
        /// </summary>
        [DataMember]
        public string FeedbackState { get; set; }
        #endregion


    }
}
