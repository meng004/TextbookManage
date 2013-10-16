using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    /// <summary>
    /// 发放班级教材提交View
    /// </summary>
    [DataContract]
    public class ReleaseBookForClassView : ReleaseBookView
    {
        /// <summary>
        /// 领用人2姓名
        /// </summary>
        [DataMember]
        public string Recipient2Name { get; set; }
        /// <summary>
        /// 领用人联系方式2
        /// </summary>
        [DataMember]
        public string Recipient2Telephone { get; set; }
    }
}
