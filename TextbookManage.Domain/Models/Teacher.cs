using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Teacher : AggregateRoot
    {
        public Teacher()
        {
            this.Declarations = new List<Declaration>();
            this.Departments = new List<Department>();
            this.TeachingTasks = new List<TeachingTask>();
            this.Textbooks = new List<Textbook>();
            ReleaseRecords = new List<TeacherReleaseRecord>();
        }

        #region ����

        /// <summary>
        /// ��ʦID
        /// </summary>
        public System.Guid TeacherId { get; set; }
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
        /// �����걨����
        /// </summary>
        public virtual ICollection<Declaration> Declarations { get; set; }
        /// <summary>
        /// ���ż���
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }
        /// <summary>
        /// ��ѧ���񼯺�
        /// </summary>
        public virtual ICollection<TeachingTask> TeachingTasks { get; set; }
        /// <summary>
        /// �걨�Ľ̲ļ���
        /// </summary>
        public virtual ICollection<Textbook> Textbooks { get; set; }
        /// <summary>
        /// �̲����ü���
        /// </summary>
        public virtual ICollection<TeacherReleaseRecord> ReleaseRecords { get; set; }
        #endregion

    }
}
