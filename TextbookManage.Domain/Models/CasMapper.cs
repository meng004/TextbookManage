using System;


namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// cas映射
    /// </summary>
    public class CasMapper : AggregateRoot
    {
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// 数字身份证号
        /// </summary>
        public string CasNetId { get; set; }
        /// <summary>
        /// 系统用户Id
        /// Membership
        /// </summary>
        public System.Guid? UserId { get; set; }
        /// <summary>
        /// 系统用户
        /// </summary>
        public virtual TbmisUser User { get; set; }
    }
}
