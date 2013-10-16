namespace TextbookManage.ViewModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ResponseView : BaseViewModel
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

        public ResponseView()
        {
            IsSuccess = true;
            Message = "本次操作成功！";
        }
        /// <summary>
        /// 操作失败
        /// </summary>
        public void Fault()
        {
            IsSuccess = false;
            Message = "本次操作失败！";
        }
        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="message">返回消息</param>
        public void Fault(string message)
        {
            IsSuccess = false;
            Message = message;
        }
    }
}