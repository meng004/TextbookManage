using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Infrastructure;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class Student : AggregateRoot
    {
        public Student()
        {
            ReleaseRecords = new List<StudentReleaseRecord>();
        }

        #region 属性

        /// <summary>
        /// 学籍ID
        /// </summary>
        public System.Guid StudentId { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 在校否
        /// </summary>
        public string Zxf { get; set; }
        /// <summary>
        /// 班级ID
        /// </summary>
        public System.Guid ProfessionalClass_Id { get; set; }
        /// <summary>
        /// 班级
        /// </summary>
        public virtual ProfessionalClass ProfessionalClass { get; set; }
        /// <summary>
        /// 教材发放集合
        /// </summary>
        public virtual ICollection<StudentReleaseRecord> ReleaseRecords { get; set; }

        #endregion

        #region 业务规则

        /// <summary>
        /// 在校
        /// </summary>
        public bool IsInCampus
        {
            get
            {
                return Zxf.ConvertToBool();
            }

        }

        /// <summary>
        /// 是否领过教材
        /// </summary>
        /// <param name="textbook"></param>
        /// <returns></returns>
        public bool HasTextbook(Guid textbookId)
        {
            var result = ReleaseRecords.FirstOrDefault(t => t.Textbook_Id == textbookId);
            return result == null ? false : true;
        }

        /// <summary>
        /// 领取教材的数量
        /// </summary>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        public int ReleaseCount(Guid textbookId)
        {
            var records = ReleaseRecords.Where(t => t.Textbook_Id == textbookId);
            if (records == null || records.Count() == 0)
            {
                return 0;
            }
            else
            {
                var count = records.Sum(t => t.ReleaseCount);
                return count;
            }            
        }
        #endregion

    }
}
