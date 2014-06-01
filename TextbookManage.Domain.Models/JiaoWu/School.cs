using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class School : AggregateRoot
    {
        public School()
        {
            this.Departments = new List<Department>();
            this.ProfessionalClasses = new List<ProfessionalClass>();
            StudentDeclarationJiaoWus = new List<StudentDeclarationJiaoWu>();
            TeacherDeclarationJiaoWus = new List<TeacherDeclarationJiaoWu>();
            TeachingTasks = new List<TeachingTask>();
        }

        #region ����

        /// <summary>
        /// Ժϵ��ID
        /// </summary>
        public System.Guid SchoolId { get; set; }
        /// <summary>
        /// Ժϵ�����
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// Ժϵ������
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ���ż���
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        public virtual ICollection<ProfessionalClass> ProfessionalClasses { get; set; }
        /// <summary>
        /// ����ѧ�������걨
        /// </summary>
        public virtual ICollection<StudentDeclarationJiaoWu> StudentDeclarationJiaoWus { get; set; }
        /// <summary>
        /// �����ʦ�����걨
        /// </summary>
        public virtual ICollection<TeacherDeclarationJiaoWu> TeacherDeclarationJiaoWus { get; set; }
        /// <summary>
        /// ��ѧ����
        /// </summary>
        public virtual ICollection<TeachingTask> TeachingTasks { get; set; }
        #endregion

    }
}
