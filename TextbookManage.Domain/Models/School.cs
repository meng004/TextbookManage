using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class School : AggregateRoot
    {
        public School()
        {
            this.Departments = new List<Department>();
            this.ProfessionalClasses = new List<ProfessionalClass>();
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
        #endregion

    }
}
