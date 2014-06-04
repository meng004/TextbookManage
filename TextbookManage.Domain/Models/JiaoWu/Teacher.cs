using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class Teacher : AggregateRoot
    {
        public Teacher()
        {
            this.Departments = new List<Department>();
            this.TeachingTasks = new List<TeachingTask>();
            ReleaseRecords = new List<TeacherReleaseRecord>();
        }

        #region ����

        /// <summary>
        /// ��ʦID
        /// </summary>
        //public System.Guid TeacherId { get; set; }
        /// <summary>
        /// ��ʦ���
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// ��ʦ����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// ���ż���
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }
        /// <summary>
        /// ��ѧ���񼯺�
        /// </summary>
        public virtual ICollection<TeachingTask> TeachingTasks { get; set; }
        /// <summary>
        /// �̲ķ��ż���
        /// </summary>
        public virtual ICollection<TeacherReleaseRecord> ReleaseRecords { get; set; }
        #endregion

    }
}
