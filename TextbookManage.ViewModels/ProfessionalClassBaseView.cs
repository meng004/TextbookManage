using System.Runtime.Serialization;


namespace TextbookManage.ViewModels
{
    /// <summary>
    /// 班级基本信息
    /// </summary>
    [DataContract]
    public class ProfessionalClassBaseView : BaseViewModel
    {
        /// <summary>
        /// 班级ID
        /// </summary>
        [DataMember]
        public string ProfessionalClassId { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
