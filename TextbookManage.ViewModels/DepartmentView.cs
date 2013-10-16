namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;
    /// <summary>
    /// 教研室View
    /// </summary>
    [DataContract]
    public class DepartmentView : BaseViewModel
    {
        /// <summary>
        /// 教研室ID
        /// </summary>
        [DataMember]
        public string DepartmentId { get; set; }

        /// <summary>
        /// 教研室名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }


    }
}
