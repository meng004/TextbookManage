namespace TextbookManage.Domain.Models
{

    using System.Collections.Generic;

    public class TbmisUser : AggregateRoot
    {

        public TbmisUser()
        {
            Roles = new List<Role>();
        }
        /// <summary>
        /// 系统用户Id
        /// Membership
        /// </summary>
        public System.Guid UserId { get; set; }
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 业务用户ID
        /// 如：学籍ID，教师ID，书商员工ID
        /// </summary>
        public System.Guid TbmisUserId { get; set; }
        /// <summary>
        /// 业务用户姓名
        /// 如：教师姓名，学生姓名，书商员工姓名
        /// </summary>
        public string TbmisUserName { get; set; }
        /// <summary>
        /// 所属院系所ID
        /// 如：学院ID，书商ID
        /// </summary>
        public System.Guid? SchoolId { get; set; }
        /// <summary>
        /// 所属院系所名称
        /// 如：学院名称，书商名称
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 用户类型码（教务）
        /// 区分用户类型，如教师、学生、书商、科室、部门
        /// </summary>
        public string YHLXM { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public TbmisUserType UserType
        {
            get
            {
                TbmisUserType type = TbmisUserType.Student;
                switch (YHLXM)
                {
                    case "00":
                        type = TbmisUserType.Student;
                        break;
                    case "01":
                        type = TbmisUserType.Teacher;
                        break;
                    case "02":
                        type = TbmisUserType.Department;
                        break;
                    case "03":
                        type = TbmisUserType.School;
                        break;
                    case "04":
                        type = TbmisUserType.Bookseller;
                        break;
                    default:
                        break;
                }
                return type;
            }
        }
        /// <summary>
        /// 角色集合
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }
        /// <summary>
        /// 是否拥有该角色
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public bool IsInRole(string roleName)
        {
            //是否存在角色
            foreach (var item in Roles)
            {
                if (item.Name == roleName)
                {
                    return true;
                }
            }

            //不存在，返回false
            return false;
        }
    }
}
