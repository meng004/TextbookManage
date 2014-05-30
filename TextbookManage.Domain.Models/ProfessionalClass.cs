using System;
using System.Collections.Generic;
using System.Linq;

namespace TextbookManage.Domain.Models
{
    public class ProfessionalClass : AggregateRoot
    {
        public ProfessionalClass()
        {
            this.Students = new List<Student>();
            this.TeachingTasks = new List<TeachingTask>();
            this.DeclarationClasses = new List<DeclarationClass>();
        }

        #region 属性

        /// <summary>
        /// 班级ID
        /// </summary>
        public System.Guid ProfessionalClassId { get; set; }
        /// <summary>
        /// 班号
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// 学院ID
        /// </summary>
        public System.Guid School_Id { get; set; }
        /// <summary>
        /// 班级计划人数
        /// </summary>
        public int XYRS { get; set; }
        /// <summary>
        /// 学生集合
        /// </summary>
        public virtual ICollection<Student> Students { get; set; }
        /// <summary>
        /// 学院
        /// </summary>
        public virtual School School { get; set; }
        /// <summary>
        /// 教学任务
        /// </summary>
        public virtual ICollection<TeachingTask> TeachingTasks { get; set; }
        /// <summary>
        /// 用书申报集合
        /// </summary>
        public virtual ICollection<DeclarationClass> DeclarationClasses { get; set; }
        #endregion

        #region 业务规则

        /// <summary>
        /// 班级学生人数
        /// 如果实有人数为0，则取班级计划人数
        /// </summary>
        /// <returns></returns>
        public int StudentCount
        {
            get
            {
                return RealStudentCount == 0 ? XYRS : RealStudentCount;
            }
        }

        public int RealStudentCount
        {
            get
            {
                return Students.Count;
            }
        }

        /// <summary>
        /// 已领教材学生人数
        /// </summary>
        /// <param name="textbook">教材</param>
        /// <returns></returns>
        public int StudentCountOfTextbook(Guid textbookId)
        {
            return Students.Count(t => t.HasTextbook(textbookId));
        }

        /// <summary>
        /// 已领取教材的数量
        /// </summary>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        public int ReleaseCount(Guid textbookId)
        {
            var count = Students.Sum(t => t.ReleaseCount(textbookId));
            return count;
        }

        /// <summary>
        /// 班级是否已申报过该教材
        /// </summary>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        internal bool IsSameDeclaration(Guid textbookId)
        {
            var result = DeclarationClasses.FirstOrDefault(t =>
                t.Declaration.Textbook_Id == textbookId
                );
            return result == null ? false : true;
        }

        /// <summary>
        /// 是否已领用过该教材
        /// 已领教材学生人数是否超过总人数30%
        /// </summary>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        internal bool IsReleased(Guid textbookId)
        {
            //如果学生人数为0，则该规则失效，返回false
            if (StudentCount == 0)
            {
                return false;
            }
            else
            {
                return StudentCountOfTextbook(textbookId) >= (StudentCount * 0.3);
            }
        }

        #endregion
        
    }
}
