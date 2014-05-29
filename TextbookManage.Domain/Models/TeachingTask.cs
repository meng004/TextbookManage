using System;
using System.Collections.Generic;
using System.Linq;

namespace TextbookManage.Domain.Models
{
    public class TeachingTask : AggregateRoot
    {
        public TeachingTask()
        {
            Declarations = new List<Declaration>();
            ProfessionalClasses = new List<ProfessionalClass>();
            Teachers = new List<Teacher>();
        }

        #region ����

        /// <summary>
        /// ��ѧ����
        /// </summary>
        public string TeachingTaskNum { get; set; }
        /// <summary>
        /// �γ�ID
        /// </summary>
        public Guid Course_Id { get; set; }
        /// <summary>
        /// ���ν�����ID
        /// </summary>
        public Guid Department_Id { get; set; }
        /// <summary>
        /// ת�������ѧ��ѧ�ڣ���ʽ"2010-2011-1"
        /// ���򷵻�string.empty
        /// </summary>
        public string Term
        {
            get
            {
                if (string.IsNullOrWhiteSpace(XNXQ.Year) || string.IsNullOrWhiteSpace(XNXQ.Term))
                {
                    return string.Empty;
                }
                else
                {
                    return string.Format("{0}-{1}", XNXQ.Year, XNXQ.Term);
                }
            }
        }
        /// <summary>
        /// ����������ѧ��ѧ��ƥ��
        /// </summary>
        public SchoolYearTerm XNXQ { get; set; }
        /// <summary>
        /// ���ݱ�ʶID
        /// </summary>
        public string DataSign_Id { get; set; }
        /// <summary>
        /// ������
        /// �ƻ�����+��������
        /// </summary>
        public int? ZRS { get; set; }
        /// <summary>
        /// �������������ν�ʦƥ��
        /// </summary>
        public ResponsibilityTeacher ResponsibilityTeacher { get; set; }
        /// <summary>
        /// �γ�
        /// </summary>
        public virtual Course Course { get; set; }
        /// <summary>
        /// �����걨����
        /// </summary>
        public virtual ICollection<Declaration> Declarations { get; set; }
        /// <summary>
        /// �����༯��
        /// </summary>
        public virtual ICollection<ProfessionalClass> ProfessionalClasses { get; set; }
        /// <summary>
        /// �ڿν�ʦ����
        /// ���ۡ�ʵ�顢ʵ����ʦ
        /// </summary>
        public virtual ICollection<Teacher> Teachers { get; set; }
        /// <summary>
        /// ���ν�����
        /// </summary>
        public virtual Department Department { get; set; }
        /// <summary>
        /// ���ݱ�ʶ
        /// ���ֱ�������ɽ���ɽ̡�����ѧԺ
        /// </summary>
        public virtual DataSign DataSign { get; set; }
        #endregion

        #region ҵ�����

        /// <summary>
        /// ��ѧ��������
        /// </summary>
        public int StudentCount
        {
            get
            {
               return ZRS != null ? (int)ZRS : RealStudentCount;
             }
        }

        /// <summary>
        /// ѧ�������걨״̬
        /// </summary>
        public DeclarationState DeclarationState
        {
            get
            {
                foreach (var item in Declarations)
                {
                    if (item.RecipientType == RecipientType.ѧ��)
                    {
                        return DeclarationState.���걨ѧ������;
                    }
                }
                return DeclarationState.δ�걨ѧ������;
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
        /// �Ƿ������ͬ�걨
        /// �̲���ͬ������������Ϊѧ��
        /// </summary>
        /// <param name="textbook"></param>
        /// <returns></returns>
        public bool IsSameDeclaration(Guid textbookId)
        {
            var result = Declarations.FirstOrDefault(t =>
                t.Textbook_Id == textbookId &&
                t.RecipientType == RecipientType.ѧ��
                );
            return result == null ? false : true;
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
