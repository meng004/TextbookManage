namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class DepartmentView:ViewModelBase 
    {
        /// <summary>
        /// 系教研室ID
        /// </summary>
        [DataMember]
        public string DepartmentID { get; set; }
        /// <summary>
        /// 系教研室编号
        /// </summary>
        [DataMember]
        public string Num { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 所属学院ID
        /// </summary>
        [DataMember]
        public string School_ID { get; set; }
        /// <summary>
        /// 学院编号
        /// </summary>
        [DataMember]
        public string SchoolNum { get; set; }
        /// <summary>
        /// 学院名称
        /// </summary>
        [DataMember]
        public string SchoolName { get; set; }
    }
}
