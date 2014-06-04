using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Infrastructure;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class TeachingTask : AggregateRoot
    {
        public TeachingTask()
        {
            TeachingTaskTeachers = new List<TeachingTaskTeacher>();
            ProfessionalClasses = new List<ProfessionalClass>();
        }

        #region 属性

        /// <summary>
        /// 教学班编号
        /// </summary>
        public string TeachingTaskNum { get; set; }
        /// <summary>
        /// 学年学期
        /// </summary>
        public SchoolYearTerm SchoolYearTerm { get; set; }
        /// <summary>
        /// 总人数
        /// </summary>
        public int? HeadCount { get; set; }
        /// <summary>
        /// 课程ID
        /// </summary>
        public Guid Course_Id { get; set; }
        /// <summary>
        /// 开课学院ID
        /// </summary>
        public Guid School_Id { get; set; }
        /// <summary>
        /// 开课教研室ID
        /// </summary>
        public Guid Department_Id { get; set; }
        /// <summary>
        /// 责任教师ID
        /// </summary>
        public Guid? Teacher_Id { get; set; }
        /// <summary>
        /// 数据标识ID
        /// </summary>
        public string DataSign_Id { get; set; }
        /// <summary>
        /// 课程
        /// </summary>
        public virtual Course Course { get; set; }
        /// <summary>
        /// 开课学院
        /// </summary>
        public virtual School School { get; set; }
        /// <summary>
        /// 开课教研室
        /// </summary>
        public virtual Department Department { get; set; }
        /// <summary>
        /// 责任教师
        /// </summary>
        public virtual Teacher Teacher { get; set; }
        /// <summary>
        /// 数据标识
        /// 区分本部、船山、成教、国际学院
        /// </summary>
        public virtual DataSign DataSign { get; set; }
        /// <summary>
        /// 授课教师集合
        /// 理论教师、实验教师等
        /// </summary>
        public virtual ICollection<TeachingTaskTeacher> TeachingTaskTeachers { get; set; }
        /// <summary>
        /// 行政班集合
        /// </summary>
        public virtual ICollection<ProfessionalClass> ProfessionalClasses { get; set; }


        #endregion

        #region 业务规则

        /// <summary>
        /// 教学班总人数
        /// </summary>
        public int StudentCount
        {
            get
            {
                return HeadCount.HasValue ? (int)HeadCount : RealStudentCount;
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
