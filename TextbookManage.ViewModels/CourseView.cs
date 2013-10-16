namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    /// <summary>
    /// 课程View
    /// </summary>
   [DataContract]
    public class CourseView : BaseViewModel
    {
     
       /// <summary>
       /// 课程ID
       /// </summary>
       [DataMember]
       public string  CourseId { get; set; }
       /// <summary>
       /// 课程编号
       /// </summary>
       [DataMember]
       public string Num { get; set; }
       /// <summary>
       /// 课程名称
       /// </summary>
       [DataMember]
       public string Name{ get; set; }
       /// <summary>
       /// 课程编号和名称
       /// </summary>
       [DataMember]
       public string NumAndName { get; set; }

    }
}
