using System;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 用户类型
    /// 区分用户类型，如教师、学生、书商、科室、部门
    /// </summary>
    public enum TbmisUserType
    {
        /// <summary>
        /// 学生
        /// </summary>
        Student,
        /// <summary>
        /// 教师
        /// </summary>
        Teacher,
        /// <summary>
        /// 书商
        /// </summary>
        Bookseller,
        /// <summary>
        /// 科室
        /// </summary>
        Department,
        /// <summary>
        /// 部门
        /// </summary>
        School
    }
}
