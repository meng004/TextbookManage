namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class DepartmentView:ViewModelBase 
    {
        /// <summary>
        /// ϵ������ID
        /// </summary>
        [DataMember]
        public string DepartmentID { get; set; }
        /// <summary>
        /// ϵ�����ұ��
        /// </summary>
        [DataMember]
        public string Num { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// ����ѧԺID
        /// </summary>
        [DataMember]
        public string School_ID { get; set; }
        /// <summary>
        /// ѧԺ���
        /// </summary>
        [DataMember]
        public string SchoolNum { get; set; }
        /// <summary>
        /// ѧԺ����
        /// </summary>
        [DataMember]
        public string SchoolName { get; set; }
    }
}
