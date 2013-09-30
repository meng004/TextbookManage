using System;
using System.Collections.Generic;

namespace TextbookManage.Domain.Models
{
    public class TeachingTask : IAggregateRoot
    {
        //public int TeachingTaskID { get; set; }
        /// <summary>
        /// ��ѧ����
        /// </summary>
        public string TeachingTaskNum { get; set; }
        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        public string Term 
        {
            get
            {
                return string.Format("{0}-{1}", XN, XQ);
            }
        }
        /// <summary>
        /// ѧ��
        /// </summary>
        public string XN { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        public string XQ { get; set; }
        /// <summary>
        /// �γ�ID
        /// </summary>
        public System.Guid Course_ID { get; set; }
        /// <summary>
        /// �γ̱��
        /// </summary>
        public string CourseNum { get; set; }
        /// <summary>
        /// �γ�����
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// ���ݱ�ʶ
        /// </summary>
        public string DataSign { get; set; }
        /// <summary>
        /// ����ѧԺID
        /// </summary>
        public Nullable<System.Guid> SchoolID { get; set; }
        //public string SchoolNum { get; set; }
        /// <summary>
        /// ����ѧԺ����
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// ����ϵ������ID
        /// </summary>
        public Nullable<System.Guid> Department_ID { get; set; }
        //public string DepartmentNum { get; set; }
        /// <summary>
        /// ����ϵ����������
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// ���ν�ʦ����
        /// </summary>
        public string ResponsibleTeacher { get; set; }
        /// <summary>
        /// ���۽�ʦID
        /// </summary>
        public Nullable<System.Guid> Teacher_ID { get; set; }
        /// <summary>
        /// ���۽�ʦ����
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// ѧ���༶ID
        /// </summary>
        public Nullable<System.Guid> Class_ID { get; set; }
        /// <summary>
        /// ѧ���༶����
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        public int StudentCount { get; set; }
    }
}
