namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class SchoolView : ViewModelBase
    {
        /// <summary>
        /// ѧԺID
        /// </summary>
       [DataMember]
        public string SchoolID { get; set; }
        /// <summary>
        /// ѧԺ���
        /// </summary>
        [DataMember]
        public string Num { get; set; }
        /// <summary>
        /// ѧԺ����
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
