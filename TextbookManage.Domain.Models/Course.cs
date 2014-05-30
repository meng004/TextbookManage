using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class Course 
    {
        public Course()
        {
            TeachingTasks = new List<TeachingTask>();
            Departments = new List<Department>();
        }
        /// <summary>
        /// �γ�ID
        /// </summary>
        public Guid CourseId { get; set; }
        /// <summary>
        /// �γ̱��
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// �γ�����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ��ѧ���񼯺�
        /// </summary>
        public virtual ICollection<TeachingTask> TeachingTasks { get; set; }
        /// <summary>
        /// �����Ҽ���
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }
    }
}
