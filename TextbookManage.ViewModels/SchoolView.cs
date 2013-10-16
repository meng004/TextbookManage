namespace TextbookManage.ViewModels
{

    using System.Runtime.Serialization;

    /// <summary>
    /// 学院View
    /// </summary>
    [DataContract]
    public class SchoolView : BaseViewModel
    {   
         /// <summary>
         /// 学院ID
         /// </summary>
        [DataMember] 
        public string SchoolId { set; get; }

         /// <summary>
         /// 学院名称
         /// </summary>
        [DataMember] 
        public string Name { set; get; }

       
    }
}
