using System;
using System.Collections.Generic;
using System.Linq;

namespace TextbookManage.Domain.Models
{
    public class ProfessionalClass : AggregateRoot
    {
        public ProfessionalClass()
        {
            this.Students = new List<Student>();
            this.TeachingTasks = new List<TeachingTask>();
            this.DeclarationClasses = new List<DeclarationClass>();
        }

        #region ����

        /// <summary>
        /// �༶ID
        /// </summary>
        public System.Guid ProfessionalClassId { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// �꼶
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// ѧԺID
        /// </summary>
        public System.Guid School_Id { get; set; }
        /// <summary>
        /// �༶�ƻ�����
        /// </summary>
        public int XYRS { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        public virtual ICollection<Student> Students { get; set; }
        /// <summary>
        /// ѧԺ
        /// </summary>
        public virtual School School { get; set; }
        /// <summary>
        /// ��ѧ����
        /// </summary>
        public virtual ICollection<TeachingTask> TeachingTasks { get; set; }
        /// <summary>
        /// �����걨����
        /// </summary>
        public virtual ICollection<DeclarationClass> DeclarationClasses { get; set; }
        #endregion

        #region ҵ�����

        /// <summary>
        /// �༶ѧ������
        /// ���ʵ������Ϊ0����ȡ�༶�ƻ�����
        /// </summary>
        /// <returns></returns>
        public int StudentCount
        {
            get
            {
                return RealStudentCount == 0 ? XYRS : RealStudentCount;
            }
        }

        public int RealStudentCount
        {
            get
            {
                return Students.Count;
            }
        }

        /// <summary>
        /// ����̲�ѧ������
        /// </summary>
        /// <param name="textbook">�̲�</param>
        /// <returns></returns>
        public int StudentCountOfTextbook(Guid textbookId)
        {
            return Students.Count(t => t.HasTextbook(textbookId));
        }

        /// <summary>
        /// ����ȡ�̲ĵ�����
        /// </summary>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        public int ReleaseCount(Guid textbookId)
        {
            var count = Students.Sum(t => t.ReleaseCount(textbookId));
            return count;
        }

        /// <summary>
        /// �༶�Ƿ����걨���ý̲�
        /// </summary>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        internal bool IsSameDeclaration(Guid textbookId)
        {
            var result = DeclarationClasses.FirstOrDefault(t =>
                t.Declaration.Textbook_Id == textbookId
                );
            return result == null ? false : true;
        }

        /// <summary>
        /// �Ƿ������ù��ý̲�
        /// ����̲�ѧ�������Ƿ񳬹�������30%
        /// </summary>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        internal bool IsReleased(Guid textbookId)
        {
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
