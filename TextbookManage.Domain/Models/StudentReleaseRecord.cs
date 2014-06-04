using System;
using System.Collections.Generic;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.Models
{
    /// <summary>
    /// 学生发放记录
    /// </summary>
    public class StudentReleaseRecord : ReleaseRecord
    {

        #region 属性

        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// 班级ID
        /// </summary>
        public System.Guid Class_Id { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 学生ID
        /// </summary>
        public System.Guid Student_Id { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public string StudentNum { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 领用人1姓名
        /// </summary>
        public string Recipient1Name { get; set; }
        /// <summary>
        /// 领用人1电话
        /// </summary>
        public string Recipient1Phone { get; set; }
        /// <summary>
        /// 领用人2姓名
        /// </summary>
        public string Recipient2Name { get; set; }
        /// <summary>
        /// 领用人2电话
        /// </summary>
        public string Recipient2Phone { get; set; }
        /// <summary>
        /// 学生
        /// </summary>
        public virtual Student Student { get; set; }
        
        #endregion
    }
}
