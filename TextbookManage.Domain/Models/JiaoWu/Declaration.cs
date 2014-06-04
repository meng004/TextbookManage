using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.Models;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class Declaration : AggregateRoot
    {

        #region 属性

        /// <summary>
        /// 申报ID
        /// </summary>
        public Guid DeclarationId { get; set; }
        /// <summary>
        /// 教材ID
        /// </summary>
        public Guid? Textbook_Id { get; set; }
        /// <summary>
        /// 课程ID
        /// </summary>
        public Guid Course_Id { get; set; }
        /// <summary>
        /// 开课学院ID
        /// </summary>
        public Guid School_Id { get; set; }
        /// <summary>
        /// 开课系教研室ID
        /// </summary>
        public Guid Department_Id { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        public SchoolYearTerm SchoolYearTerm  { get; set; }
        /// <summary>
        /// 申报数量
        /// </summary>
        public int DeclarationCount { get; set; }
        /// <summary>
        /// 数据标识
        /// A为本部，B为船山
        /// </summary>
        public string DataSign_Id { get; set; }
        /// <summary>
        /// 是否归档
        /// 表明当前记录的审核状态
        /// </summary>
        public string Sfgd { get; set; }
        /// <summary>
        /// 教材
        /// </summary>
        public virtual Textbook Textbook { get; set; }
        /// <summary>
        /// 课程
        /// </summary>
        public virtual Course Course { get; set; }
        /// <summary>
        /// 开课学院
        /// </summary>
        public virtual School School { get; set; }
        /// <summary>
        /// 开课系教研室
        /// </summary>
        public virtual Department Department { get; set; }
        /// <summary>
        /// 数据标识
        /// </summary>
        public virtual DataSign DataSign { get; set; }
        #endregion

    }
}
