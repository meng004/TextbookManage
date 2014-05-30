using System;
using System.Collections.Generic;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain.Models
{
    public class TeacherReleaseRecord : ReleaseRecord
    {
        public TeacherReleaseRecord()
        {
            RecipientType = RecipientType.��ʦ;
            IdCardType = IDCardType.IdentityCard;
        }

        #region ����

        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// ϵ������ID
        /// </summary>
        public System.Guid Department_Id { get; set; }
        /// <summary>
        /// ϵ����������
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// ��ʦID
        /// </summary>
        public System.Guid Teacher_Id { get; set; }
        /// <summary>
        /// ��ʦ����
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// ����֤������
        /// </summary>
        public IDCardType IdCardType { get; set; }
        /// <summary>
        /// ֤�����
        /// </summary>
        public string IdCardNum { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        public string RecipientName { get; set; }
        /// <summary>
        /// �����˵绰
        /// </summary>
        public string RecipientPhone { get; set; }
        //public virtual ReleaseRecord ReleaseRecord { get; set; }
        /// <summary>
        /// ��ʦ
        /// </summary>
        public virtual Teacher Teacher { get; set; }
        #endregion

    }
}
