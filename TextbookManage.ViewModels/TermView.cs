namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TermView : ViewModelBase
    {
        //public int TermID { get; set; }
        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// �Ƿ�ǰѧ��ѧ��
        /// </summary>
        [DataMember]
        public string IsValid { get; set; }
    }
}
