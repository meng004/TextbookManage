namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    /// <summary>
    /// ���ݱ�ʶ
    /// </summary>
    [DataContract]
    public class DataSignView:ViewModelBase 
    {
        //public int DataSignID { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        [DataMember]
        public string Num { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
