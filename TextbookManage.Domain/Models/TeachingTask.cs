using System;
using System.Collections.Generic;
using System.Linq;

namespace TextbookManage.Domain.Models
{
    public class TeachingTask : AggregateRoot
    {
        public TeachingTask()
        {
            Declarations = new List<Declaration>();
            ProfessionalClasses = new List<ProfessionalClass>();
            Teachers = new List<Teacher>();
        }

        #region 属性

        /// <summary>
        /// 教学班编号
        /// </summary>
        public string TeachingTaskNum { get; set; }
        /// <summary>
        /// 课程ID
        /// </summary>
        public Guid Course_Id { get; set; }
        /// <summary>
        /// 开课教研室ID
        /// </summary>
        public Guid Department_Id { get; set; }
        /// <summary>
        /// 转换教务的学年学期，格式"2010-2011-1"
        /// 空则返回string.empty
        /// </summary>
        public string Term
        {
            get
            {
                if (string.IsNullOrWhiteSpace(XNXQ.Year) || string.IsNullOrWhiteSpace(XNXQ.Term))
                {
                    return string.Empty;
                }
                else
                {
                    return string.Format("{0}-{1}", XNXQ.Year, XNXQ.Term);
                }
            }
        }
        /// <summary>
        /// 用于与教务的学年学期匹配
        /// </summary>
        public SchoolYearTerm XNXQ { get; set; }
        /// <summary>
        /// 数据标识ID
        /// </summary>
        public string DataSign_Id { get; set; }
        /// <summary>
        /// 总人数
        /// 计划人数+上抛人数
        /// </summary>
        public int? ZRS { get; set; }
        /// <summary>
        /// 用于与教务的责任教师匹配
        /// </summary>
        public ResponsibilityTeacher ResponsibilityTeacher { get; set; }
        /// <summary>
        /// 课程
        /// </summary>
        public virtual Course Course { get; set; }
        /// <summary>
        /// 用书申报集合
        /// </summary>
        public virtual ICollection<Declaration> Declarations { get; set; }
        /// <summary>
        /// 行政班集合
        /// </summary>
        public virtual ICollection<ProfessionalClass> ProfessionalClasses { get; set; }
        /// <summary>
        /// 授课教师集合
        /// 理论、实验、实践教师
        /// </summary>
        public virtual ICollection<Teacher> Teachers { get; set; }
        /// <summary>
        /// 开课教研室
        /// </summary>
        public virtual Department Department { get; set; }
        /// <summary>
        /// 数据标识
        /// 区分本部、船山、成教、国际学院
        /// </summary>
        public virtual DataSign DataSign { get; set; }
        #endregion

        #region 业务规则

        /// <summary>
        /// 教学班总人数
        /// </summary>
        public int StudentCount
        {
            get
            {
               return ZRS != null ? (int)ZRS : RealStudentCount;
             }
        }

        /// <summary>
        /// 学生用书申报状态
        /// </summary>
        public DeclarationState DeclarationState
        {
            get
            {
                foreach (var item in Declarations)
                {
                    if (item.RecipientType == RecipientType.学生)
                    {
                        return DeclarationState.已申报学生用书;
                    }
                }
                return DeclarationState.未申报学生用书;
            }
        }

        /// <summary>
        /// 教学班实有人数
        /// </summary>
        /// <param name="teachingClass"></param>
        /// <returns></returns>
        public int RealStudentCount
        {
            get
            {
                return ProfessionalClasses.Sum(t => t.StudentCount);
            }
        }

        /// <summary>
        /// 已领书学生人数
        /// </summary>
        /// <returns></returns>
        public int StudentCountOfTextbook(Guid textbookId)
        {
            return ProfessionalClasses.Sum(t => t.StudentCountOfTextbook(textbookId));
        }

        /// <summary>
        /// 是否存在相同申报
        /// 教材相同，领用人类型为学生
        /// </summary>
        /// <param name="textbook"></param>
        /// <returns></returns>
        public bool IsSameDeclaration(Guid textbookId)
        {
            var result = Declarations.FirstOrDefault(t =>
                t.Textbook_Id == textbookId &&
                t.RecipientType == RecipientType.学生
                );
            return result == null ? false : true;
        }

        /// <summary>
        /// 是否已发放
        /// 已领教材学生人数大于总人数的30%
        /// </summary>
        /// <param name="teachingTask">教学任务</param>
        /// <param name="textbook">教材</param>
        /// <returns></returns>
        public bool IsReleased(Guid textbookId)
        {
            //是否存在相同教材的申报
            //已领教材学生人数是否超过总人数30%
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
