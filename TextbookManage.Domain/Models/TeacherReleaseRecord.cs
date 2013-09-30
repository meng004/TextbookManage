using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class TeacherReleaseRecord : ReleaseRecord
    {
        public TeacherReleaseRecord()
        {
            this.RecipientType = RecipientType.Teacher;
        }
        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// 系教研室ID
        /// </summary>
        public System.Guid Department_ID { get; set; }
        /// <summary>
        /// 系教研室名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 教师ID
        /// </summary>
        public System.Guid Teacher_ID { get; set; }
        /// <summary>
        /// 教师姓名
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 领书证件类型
        /// </summary>
        public Nullable<int> IDCardType { get; set; }
        /// <summary>
        /// 证件编号
        /// </summary>
        public string IDCardNum { get; set; }
        /// <summary>
        /// 条形码
        /// </summary>
        public string Barcode { get; set; }
        //public virtual ReleaseRecord ReleaseRecord { get; set; }
    }
}
