using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class Department : AggregateRoot
    {
        public Department()
        {
            this.Courses = new List<Course>();
            this.Teachers = new List<Teacher>();
            this.TeachingTasks = new List<TeachingTask>();
            StudentDeclarationJiaoWus = new List<StudentDeclarationJiaoWu>();
            StudentDeclarations = new List<StudentDeclaration>();
            TeacherDeclarationJiaoWus = new List<TeacherDeclarationJiaoWu>();
            TeacherDeclarations = new List<TeacherDeclaration>();
        }

        #region ����

        /// <summary>
        /// ����ID
        /// </summary>
        //public System.Guid DepartmentId { get; set; }
        /// <summary>
        /// ���ű��
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Ժϵ��ID
        /// </summary>
        public System.Guid School_Id { get; set; }
        /// <summary>
        /// Ժϵ��
        /// </summary>
        public virtual School School { get; set; }
        /// <summary>
        /// �γ̼���
        /// </summary>
        public virtual ICollection<Course> Courses { get; set; }
        /// <summary>
        /// ��ʦ����
        /// </summary>
        public virtual ICollection<Teacher> Teachers { get; set; }
        /// <summary>
        /// ��ѧ���񼯺�
        /// </summary>
        public virtual ICollection<TeachingTask> TeachingTasks { get; set; }
        /// <summary>
        /// ����ѧ�������걨
        /// </summary>
        public virtual ICollection<StudentDeclarationJiaoWu> StudentDeclarationJiaoWus { get; set; }
        /// <summary>
        /// �����ʦ�����걨
        /// </summary>
        public virtual ICollection<TeacherDeclarationJiaoWu> TeacherDeclarationJiaoWus { get; set; }
        /// <summary>
        /// ѧ�������걨
        /// </summary>
        public virtual ICollection<StudentDeclaration> StudentDeclarations { get; set; }
        /// <summary>
        /// ��ʦ�����걨
        /// </summary>
        public virtual ICollection<TeacherDeclaration> TeacherDeclarations { get; set; }
        #endregion
    }
}
