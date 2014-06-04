using System;
using System.Collections.Generic;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.Models
{
    public class TeacherReleaseRecord : ReleaseRecord
    {
        public TeacherReleaseRecord()
        {
            RecipientType = RecipientType.教师;
            IdCardType = IDCardType.IdentityCard;
        }

        #region 属性

        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// 系教研室ID
        /// </summary>
        public System.Guid Department_Id { get; set; }
        /// <summary>
        /// 系教研室名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 教师ID
        /// </summary>
        public System.Guid Teacher_Id { get; set; }
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
        public IDCardType IdCardType { get; set; }
        /// <summary>
        /// 证件编号
        /// </summary>
        public string IdCardNum { get; set; }
        /// <summary>
        /// 条形码
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// 领用人姓名
        /// </summary>
        public string RecipientName { get; set; }
        /// <summary>
        /// 领用人电话
        /// </summary>
        public string RecipientPhone { get; set; }
        //public virtual ReleaseRecord ReleaseRecord { get; set; }
        /// <summary>
        /// 教师
        /// </summary>
        public virtual Teacher Teacher { get; set; }
        #endregion

    }
}
