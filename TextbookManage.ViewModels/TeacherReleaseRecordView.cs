namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TeacherReleaseRecordView : ViewModelBase
    {

        //public System.Guid ReleaseRecordID { get; set; }
        /// <summary>
        /// 系教研室ID
        /// </summary>
        [DataMember]
        public string Department_ID { get; set; }
        /// <summary>
        /// 系教研室名称
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 教师ID
        /// </summary>
        [DataMember]
        public string Teacher_ID { get; set; }
        /// <summary>
        /// 教师姓名
        /// </summary>
        [DataMember]
        public string TeacherName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public string Gender { get; set; }
        /// <summary>
        /// 领书证件类型
        /// </summary>
        [DataMember]
        public string IDCardType { get; set; }
        /// <summary>
        /// 证件编号
        /// </summary>
        [DataMember]
        public string IDCardNum { get; set; }
        /// <summary>
        /// 条形码
        /// </summary>
        [DataMember]
        public string Barcode { get; set; }
        //public virtual ReleaseRecord ReleaseRecord { get; set; }
    }
}
