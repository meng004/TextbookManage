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

        #region ����

        /// <summary>
        /// ��ѧ����
        /// </summary>
        public string TeachingTaskNum { get; set; }
        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        public SchoolYearTerm SchoolYearTerm { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public int? HeadCount { get; set; }
        /// <summary>
        /// �γ�ID
        /// </summary>
        public Guid Course_Id { get; set; }
        /// <summary>
        /// ����ѧԺID
        /// </summary>
        public Guid School_Id { get; set; }
        /// <summary>
        /// ���ν�����ID
        /// </summary>
        public Guid Department_Id { get; set; }
        /// <summary>
        /// ���ν�ʦID
        /// </summary>
        public Guid? Teacher_Id { get; set; }
        /// <summary>
        /// ���ݱ�ʶID
        /// </summary>
        public string DataSign_Id { get; set; }
        /// <summary>
        /// �γ�
        /// </summary>
        public virtual Course Course { get; set; }
        /// <summary>
        /// ����ѧԺ
        /// </summary>
        public virtual School School { get; set; }
        /// <summary>
        /// ���ν�����
        /// </summary>
        public virtual Department Department { get; set; }
        /// <summary>
        /// ���ν�ʦ
        /// </summary>
        public virtual Teacher Teacher { get; set; }
        /// <summary>
        /// ���ݱ�ʶ
        /// ���ֱ�������ɽ���ɽ̡�����ѧԺ
        /// </summary>
        public virtual DataSign DataSign { get; set; }
        /// <summary>
        /// �ڿν�ʦ����
        /// ���۽�ʦ��ʵ���ʦ��
        /// </summary>
        public virtual ICollection<TeachingTaskTeacher> TeachingTaskTeachers { get; set; }
        /// <summary>
        /// �����༯��
        /// </summary>
        public virtual ICollection<ProfessionalClass> ProfessionalClasses { get; set; }


        #endregion

        #region ҵ�����

        /// <summary>
        /// ��ѧ��������
        /// </summary>
        public int StudentCount
        {
            get
            {
                return HeadCount.HasValue ? (int)HeadCount : RealStudentCount;
            }
        }


        /// <summary>
        /// ��ѧ��ʵ������
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
        /// ������ѧ������
        /// </summary>
        /// <returns></returns>
        public int StudentCountOfTextbook(Guid textbookId)
        {
            return ProfessionalClasses.Sum(t => t.StudentCountOfTextbook(textbookId));
        }

        /// <summary>
        /// �Ƿ��ѷ���
        /// ����̲�ѧ������������������30%
        /// </summary>
        /// <param name="teachingTask">��ѧ����</param>
        /// <param name="textbook">�̲�</param>
        /// <returns></returns>
        public bool IsReleased(Guid textbookId)
        {
            //�Ƿ������ͬ�̲ĵ��걨
            //����̲�ѧ�������Ƿ񳬹�������30%
            //���ѧ������Ϊ0����ù���ʧЧ������false
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
