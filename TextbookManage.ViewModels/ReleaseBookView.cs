using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    /// <summary>
    /// 教材发放提交BaseView
    /// </summary>
    [DataContract]
    public class ReleaseBookView : BaseViewModel
    {
        /// <summary>
        /// 操作人（书商员工登录名）
        /// </summary>
        [DataMember]
        public string Operator { get; set; }
        /// <summary>
        /// 领用人姓名
        /// </summary>
        [DataMember]
        public string RecipientName { get; set; }
        /// <summary>
        /// 领用人联系方式
        /// </summary>
        [DataMember]
        public string RecipientTelephone { get; set; }
    }
}
