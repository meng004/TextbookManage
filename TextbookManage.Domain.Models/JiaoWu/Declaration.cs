using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Domain.Models;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class Declaration : AggregateRoot
    {

        #region ����

        /// <summary>
        /// �걨ID
        /// </summary>
        public Guid DeclarationId { get; set; }
        /// <summary>
        /// �̲�ID
        /// </summary>
        public Guid? Textbook_Id { get; set; }
        /// <summary>
        /// �γ�ID
        /// </summary>
        public Guid Course_Id { get; set; }
        /// <summary>
        /// ����ѧԺID
        /// </summary>
        public Guid School_Id { get; set; }
        /// <summary>
        /// ����ϵ������ID
        /// </summary>
        public Guid Department_Id { get; set; }
        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        public SchoolYearTerm SchoolYearTerm  { get; set; }
        /// <summary>
        /// �걨����
        /// </summary>
        public int DeclarationCount { get; set; }
        /// <summary>
        /// ���ݱ�ʶ
        /// AΪ������BΪ��ɽ
        /// </summary>
        public string DataSign_Id { get; set; }
        /// <summary>
        /// �Ƿ�鵵
        /// ������ǰ��¼�����״̬
        /// </summary>
        public string Sfgd { get; set; }
        /// <summary>
        /// �̲�
        /// </summary>
        public virtual Textbook Textbook { get; set; }
        /// <summary>
        /// �γ�
        /// </summary>
        public virtual Course Course { get; set; }
        /// <summary>
        /// ����ѧԺ
        /// </summary>
        public virtual School School { get; set; }
        /// <summary>
        /// ����ϵ������
        /// </summary>
        public virtual Department Department { get; set; }
        /// <summary>
        /// ���ݱ�ʶ
        /// </summary>
        public virtual DataSign DataSign { get; set; }
        #endregion

    }
}
