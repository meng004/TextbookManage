using System;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 审核状态
    /// </summary>
    public enum ApprovalState : int
    {
        /// <summary>
        /// 未提交
        /// </summary>
        //ReadyToSubmit,
        未提交,
        /// <summary>
        /// 教研室审核中
        /// </summary>
        //DepartmentApproving,
        教研室审核中,
        /// <summary>
        /// 教研室审核未通过
        /// </summary>
        //DepartmentNotPass,
        教研室审核未通过,
        /// <summary>
        /// 学院审核中
        /// </summary>
        //SchoolApproving,
        学院审核中,
        /// <summary>
        /// 学院审核未通过
        /// </summary>
        //SchoolNotPass,
        学院审核未通过,
        /// <summary>
        /// 教材科审核中
        /// </summary>
        //TextbookDivisionApproving,
        教材科审核中,
        /// <summary>
        /// 教材科审核未通过
        /// </summary>
        //TextbookDivisionNotPass,
        教材科审核未通过,
        /// <summary>
        /// 教务处审核中
        /// </summary>
        //DeanApproving,
        教务处审核中,
        /// <summary>
        /// 教务处审核未通过
        /// </summary>
        //DeanNotPass,
        教务处审核未通过,
        /// <summary>
        /// 终审通过
        /// </summary>
        //Passed,
        终审通过,
        /// <summary>
        /// 未知状态
        /// </summary>
        //Unknown
        未知状态

    }
}
