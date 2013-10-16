using System;
using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    /// <summary>
    /// cas映射
    /// </summary>
    [DataContract]
    public class CasMapperView : BaseViewModel
    {
        /// <summary>
        /// 系统用户Id
        /// Membership
        /// </summary>
        [DataMember]
        public string UserId { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [DataMember]
        public string IdCard { get; set; }
        /// <summary>
        /// 数字身份证号
        /// </summary>
        [DataMember]
        public string CasNetId { get; set; }

    }
}
