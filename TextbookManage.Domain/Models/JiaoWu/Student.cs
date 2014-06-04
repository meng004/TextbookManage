using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.Infrastructure;

namespace TextbookManage.Domain.Models.JiaoWu
{
    public class Student : AggregateRoot
    {
        public Student()
        {
            ReleaseRecords = new List<StudentReleaseRecord>();
        }

        #region ����

        /// <summary>
        /// ѧ��ID
        /// </summary>
        public System.Guid StudentId { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// ��У��
        /// </summary>
        public string Zxf { get; set; }
        /// <summary>
        /// �༶ID
        /// </summary>
        public System.Guid ProfessionalClass_Id { get; set; }
        /// <summary>
        /// �༶
        /// </summary>
        public virtual ProfessionalClass ProfessionalClass { get; set; }
        /// <summary>
        /// �̲ķ��ż���
        /// </summary>
        public virtual ICollection<StudentReleaseRecord> ReleaseRecords { get; set; }

        #endregion

        #region ҵ�����

        /// <summary>
        /// ��У
        /// </summary>
        public bool IsInCampus
        {
            get
            {
                return Zxf.ConvertToBool();
            }

        }

        /// <summary>
        /// �Ƿ�����̲�
        /// </summary>
        /// <param name="textbook"></param>
        /// <returns></returns>
        public bool HasTextbook(Guid textbookId)
        {
            var result = ReleaseRecords.FirstOrDefault(t => t.Textbook_Id == textbookId);
            return result == null ? false : true;
        }

        /// <summary>
        /// ��ȡ�̲ĵ�����
        /// </summary>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        public int ReleaseCount(Guid textbookId)
        {
            var records = ReleaseRecords.Where(t => t.Textbook_Id == textbookId);
            if (records == null || records.Count() == 0)
            {
                return 0;
            }
            else
            {
                var count = records.Sum(t => t.ReleaseCount);
                return count;
            }            
        }
        #endregion

    }
}
