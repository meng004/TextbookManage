using System;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 审核状态
    /// </summary>
    public enum ApprovalState
    {
        /// <summary>
        /// 未提交
        /// </summary>
        ReadyToSubmit,
        /// <summary>
        /// 教研室审核中
        /// </summary>
        DepartmentApproving,
        /// <summary>
        /// 教研室审核未通过
        /// </summary>
        DepartmentNotPass,
        /// <summary>
        /// 学院审核中
        /// </summary>
        SchoolApproving,
        /// <summary>
        /// 学院审核未通过
        /// </summary>
        SchoolNotPass,
        /// <summary>
        /// 教材科审核中
        /// </summary>
        TextbookDivisionApproving,
        /// <summary>
        /// 教材科审核未通过
        /// </summary>
        TextbookDivisionNotPass,
        /// <summary>
        /// 教务处审核中
        /// </summary>
        DeanApproving,
        /// <summary>
        /// 教务处审核未通过
        /// </summary>
        DeanNotPass,
        /// <summary>
        /// 终审通过
        /// </summary>
        Passed,
        /// <summary>
        /// 未知状态
        /// </summary>
        Unknown

    }
}
