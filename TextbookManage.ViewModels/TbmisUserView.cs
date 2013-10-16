namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    [DataContract]
    public class TbmisUserView : BaseViewModel
    {
        /// <summary>
        /// 系统用户Id
        /// Membership
        /// </summary>
        [DataMember]
        public string UserId { get; set; }
        /// <summary>
        /// 登录用户名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
        /// <summary>
        /// 业务用户ID
        /// 如：学籍ID，教师ID，书商员工ID
        /// </summary>
        [DataMember]
        public string TbmisUserId { get; set; }
        /// <summary>
        /// 业务用户姓名
        /// 如：教师姓名，学生姓名，书商员工姓名
        /// </summary>
        [DataMember]
        public string TbmisUserName { get; set; }
        /// <summary>
        /// 所属院系所ID
        /// 如：学院ID，书商ID
        /// </summary>
        [DataMember]
        public string SchoolId { get; set; }
        /// <summary>
        /// 所属院系所名称
        /// 如：学院名称，书商名称
        /// </summary>
        [DataMember]
        public string SchoolName { get; set; }
        /// <summary>
        /// 用户类型（教务）
        /// 区分用户类型，如教师、学生、书商、科室、部门
        /// </summary>
        [DataMember]
        public string UserType { get; set; }


    }
}
