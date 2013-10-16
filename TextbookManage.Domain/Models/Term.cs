using System;
using System.Collections.Generic;
using TextbookManage.Infrastructure;


namespace TextbookManage.Domain.Models
{
    public class Term : AggregateRoot
    {

        #region ����

        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        public string YearTerm { get; set; }
        /// <summary>
        /// ��ǰѧ��ѧ�ڱ�־
        /// 1Ϊ��ǰ��0Ϊ�ǵ�ǰ
        /// </summary>
        public string dqxnxqbz { get; set; }
        /// <summary>
        /// �Ƿ�ǰѧ��ѧ��
        /// ���ַ������͵ĵ�ǰѧ��ѧ�ڱ�־ת��Ϊbool
        /// �ɽ����ַ�Ϊtrue\yes\y\1\ok\��
        /// </summary>
        public bool IsCurrent
        {
            get
            {
                return dqxnxqbz.ConvertToBool();
            }
            set
            {
                dqxnxqbz = value ? "1" : "0";
            }
        }
        #endregion

        #region ҵ�񷽷�

        /// <summary>
        /// �������ѧ��ѧ�ڷ���
        /// ��ʽ��2011-2012-2����2011-2012��2
        /// </summary>
        public XNXQ SplitTerm
        {
            get
            {
                XNXQ result = new XNXQ
                {
                    XN = YearTerm.Substring(0, 9),
                    XQ = YearTerm.Substring(10, 1)
                };
                return result;
            }
        }
        #endregion

    }
}
