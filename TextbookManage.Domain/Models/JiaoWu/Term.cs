using System;
using System.Collections.Generic;
using TextbookManage.Infrastructure;


namespace TextbookManage.Domain.Models.JiaoWu
{
    /// <summary>
    /// ʵ����ѧ��ѧ��
    /// ���ڴ����ݿ�ӳ��
    /// </summary>
    public class Term : AggregateRoot
    {

        #region ����

        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        public string YearTerm { get; set; }
        /// <summary>
        /// ˵��
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// ��ǰѧ��ѧ�ڱ�־
        /// 1Ϊ��ǰ��0Ϊ�ǵ�ǰ
        /// </summary>
        public string DqXnXqBz { get; set; }
        /// <summary>
        /// �Ƿ�ǰѧ��ѧ��
        /// ���ַ������͵ĵ�ǰѧ��ѧ�ڱ�־ת��Ϊbool
        /// �ɽ����ַ�Ϊtrue\yes\y\1\ok\��
        /// </summary>
        public bool IsCurrent
        {
            get
            {
                return DqXnXqBz.ConvertToBool();
            }
        }
        #endregion

        #region ҵ�񷽷�

        /// <summary>
        /// �������ѧ��ѧ�ڷ���
        /// ��ʽ��2011-2012-2����2011-2012��2
        /// </summary>
        public SchoolYearTerm SchoolYearTerm
        {
            get
            {
                if (object.ReferenceEquals(schoolYearTerm, null))
                {
                    var yearTerm = new SchoolYearTerm(YearTerm);
                    schoolYearTerm = yearTerm;
                    return yearTerm;
                }
                else
                    return schoolYearTerm;
            }
        }

        private SchoolYearTerm schoolYearTerm;
        #endregion

    }
}
