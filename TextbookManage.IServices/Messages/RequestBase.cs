namespace TextbookManage.ViewModels
{
    
    using System.Runtime.Serialization;

    [DataContract]
    public abstract class RequestBase
    {
        [DataMember]
        public string UserName { get; set; }
    }
}