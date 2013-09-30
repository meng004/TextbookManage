namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

   [DataContract]
    public abstract class ResponseBase
    {
        /// <summary>
        /// 操作是否成功
        /// </summary>
        [DataMember]
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        public ResponseBase()
        {
            IsSuccess = true;
            Message = "本次操作成功！";
        }
    }
}