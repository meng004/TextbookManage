using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class Course 
    {
        public Course()
        {
            TeachingTasks = new List<TeachingTask>();
            Departments = new List<Department>();
            StudentDeclarationJiaoWus = new List<StudentDeclarationJiaoWu>();
            TeacherDeclarationJiaoWus = new List<TeacherDeclarationJiaoWu>();
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
        /// <summary>
        /// ����ѧ�������걨
        /// </summary>
        public virtual ICollection<StudentDeclarationJiaoWu> StudentDeclarationJiaoWus { get; set; }
        /// <summary>
        /// �����ʦ�����걨
        /// </summary>
        public virtual ICollection<TeacherDeclarationJiaoWu> TeacherDeclarationJiaoWus { get; set; }
    }
}
