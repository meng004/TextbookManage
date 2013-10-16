namespace TextbookManage.WebUI.FeedbackApprovalService
{
    using System.Runtime.Serialization;
    using System;

    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "BooksellerView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class BooksellerView : TextbookManage.WebUI.FeedbackApprovalService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string BooksellerIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NameField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string BooksellerId
        {
            get
            {
                return this.BooksellerIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BooksellerIdField, value) != true))
                {
                    this.BooksellerIdField = value;
                    this.RaisePropertyChanged("BooksellerId");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.NameField, value) != true))
                {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "BaseViewModel", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.FeedbackApprovalService.FeedbackView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.FeedbackApprovalService.FeedbackForApprovalView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.FeedbackApprovalService.ResponseView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.FeedbackApprovalService.BooksellerView))]
    public partial class BaseViewModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {
        [System.NonSerializedAttribute]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private bool CheckFlagField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DeleteFlagField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private bool IsDeleteField;
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public bool CheckFlag
        {
            get
            {
                return this.CheckFlagField;
            }
            set
            {
                if ((this.CheckFlagField.Equals(value) != true))
                {
                    this.CheckFlagField = value;
                    this.RaisePropertyChanged("CheckFlag");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string DeleteFlag
        {
            get
            {
                return this.DeleteFlagField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DeleteFlagField, value) != true))
                {
                    this.DeleteFlagField = value;
                    this.RaisePropertyChanged("DeleteFlag");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public bool IsDelete
        {
            get
            {
                return this.IsDeleteField;
            }
            set
            {
                if ((this.IsDeleteField.Equals(value) != true))
                {
                    this.IsDeleteField = value;
                    this.RaisePropertyChanged("IsDelete");
                }
            }
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "FeedbackView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.FeedbackApprovalService.FeedbackForApprovalView))]
    public partial class FeedbackView : TextbookManage.WebUI.FeedbackApprovalService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string BooksellerNameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string FeedbackDateField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string FeedbackIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string FeedbackStateField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string PersonField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string RemarkField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string BooksellerName
        {
            get
            {
                return this.BooksellerNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BooksellerNameField, value) != true))
                {
                    this.BooksellerNameField = value;
                    this.RaisePropertyChanged("BooksellerName");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string FeedbackDate
        {
            get
            {
                return this.FeedbackDateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FeedbackDateField, value) != true))
                {
                    this.FeedbackDateField = value;
                    this.RaisePropertyChanged("FeedbackDate");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string FeedbackId
        {
            get
            {
                return this.FeedbackIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FeedbackIdField, value) != true))
                {
                    this.FeedbackIdField = value;
                    this.RaisePropertyChanged("FeedbackId");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string FeedbackState
        {
            get
            {
                return this.FeedbackStateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FeedbackStateField, value) != true))
                {
                    this.FeedbackStateField = value;
                    this.RaisePropertyChanged("FeedbackState");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Person
        {
            get
            {
                return this.PersonField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PersonField, value) != true))
                {
                    this.PersonField = value;
                    this.RaisePropertyChanged("Person");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Remark
        {
            get
            {
                return this.RemarkField;
            }
            set
            {
                if ((object.ReferenceEquals(this.RemarkField, value) != true))
                {
                    this.RemarkField = value;
                    this.RaisePropertyChanged("Remark");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "FeedbackForApprovalView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class FeedbackForApprovalView : TextbookManage.WebUI.FeedbackApprovalService.FeedbackView
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string IsbnField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string SubscriptionCountField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TextbookIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TextbookNameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TextbookNumField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Isbn
        {
            get
            {
                return this.IsbnField;
            }
            set
            {
                if ((object.ReferenceEquals(this.IsbnField, value) != true))
                {
                    this.IsbnField = value;
                    this.RaisePropertyChanged("Isbn");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string SubscriptionCount
        {
            get
            {
                return this.SubscriptionCountField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SubscriptionCountField, value) != true))
                {
                    this.SubscriptionCountField = value;
                    this.RaisePropertyChanged("SubscriptionCount");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string TextbookId
        {
            get
            {
                return this.TextbookIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TextbookIdField, value) != true))
                {
                    this.TextbookIdField = value;
                    this.RaisePropertyChanged("TextbookId");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string TextbookName
        {
            get
            {
                return this.TextbookNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TextbookNameField, value) != true))
                {
                    this.TextbookNameField = value;
                    this.RaisePropertyChanged("TextbookName");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string TextbookNum
        {
            get
            {
                return this.TextbookNumField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TextbookNumField, value) != true))
                {
                    this.TextbookNumField = value;
                    this.RaisePropertyChanged("TextbookNum");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ResponseView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class ResponseView : TextbookManage.WebUI.FeedbackApprovalService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private bool IsSuccessField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string MessageField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public bool IsSuccess
        {
            get
            {
                return this.IsSuccessField;
            }
            set
            {
                if ((this.IsSuccessField.Equals(value) != true))
                {
                    this.IsSuccessField = value;
                    this.RaisePropertyChanged("IsSuccess");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                if ((object.ReferenceEquals(this.MessageField, value) != true))
                {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "FeedbackApprovalService.IFeedbackApprovalAppl")]
    public interface IFeedbackApprovalAppl
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackApprovalAppl/GetAuditor", ReplyAction = "http://tempuri.org/IFeedbackApprovalAppl/GetAuditorResponse")]
        string GetAuditor(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackApprovalAppl/GetAuditor", ReplyAction = "http://tempuri.org/IFeedbackApprovalAppl/GetAuditorResponse")]
        System.Threading.Tasks.Task<string> GetAuditorAsync(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackApprovalAppl/GetBooksellerWithNotApproval", ReplyAction = "http://tempuri.org/IFeedbackApprovalAppl/GetBooksellerWithNotApprovalResponse")]
        TextbookManage.WebUI.FeedbackApprovalService.BooksellerView[] GetBooksellerWithNotApproval(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackApprovalAppl/GetBooksellerWithNotApproval", ReplyAction = "http://tempuri.org/IFeedbackApprovalAppl/GetBooksellerWithNotApprovalResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackApprovalService.BooksellerView[]> GetBooksellerWithNotApprovalAsync(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackApprovalAppl/GetFeedbackWithNotApproval", ReplyAction = "http://tempuri.org/IFeedbackApprovalAppl/GetFeedbackWithNotApprovalResponse")]
        TextbookManage.WebUI.FeedbackApprovalService.FeedbackForApprovalView[] GetFeedbackWithNotApproval(string loginName, string booksellerId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackApprovalAppl/GetFeedbackWithNotApproval", ReplyAction = "http://tempuri.org/IFeedbackApprovalAppl/GetFeedbackWithNotApprovalResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackApprovalService.FeedbackForApprovalView[]> GetFeedbackWithNotApprovalAsync(string loginName, string booksellerId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackApprovalAppl/SubmitFeedbackApproval", ReplyAction = "http://tempuri.org/IFeedbackApprovalAppl/SubmitFeedbackApprovalResponse")]
        TextbookManage.WebUI.FeedbackApprovalService.ResponseView SubmitFeedbackApproval(TextbookManage.WebUI.FeedbackApprovalService.FeedbackForApprovalView[] feedbacks, string loginName, string suggestion, string remark);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackApprovalAppl/SubmitFeedbackApproval", ReplyAction = "http://tempuri.org/IFeedbackApprovalAppl/SubmitFeedbackApprovalResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackApprovalService.ResponseView> SubmitFeedbackApprovalAsync(TextbookManage.WebUI.FeedbackApprovalService.FeedbackForApprovalView[] feedbacks, string loginName, string suggestion, string remark);
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFeedbackApprovalApplChannel : TextbookManage.WebUI.FeedbackApprovalService.IFeedbackApprovalAppl, System.ServiceModel.IClientChannel
    {
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FeedbackApprovalApplClient : System.ServiceModel.ClientBase<TextbookManage.WebUI.FeedbackApprovalService.IFeedbackApprovalAppl>, TextbookManage.WebUI.FeedbackApprovalService.IFeedbackApprovalAppl
    {
        public FeedbackApprovalApplClient()
        {
        }
        public FeedbackApprovalApplClient(string endpointConfigurationName)
            :
            base(endpointConfigurationName)
        {
        }
        public FeedbackApprovalApplClient(string endpointConfigurationName, string remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public FeedbackApprovalApplClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public FeedbackApprovalApplClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(binding, remoteAddress)
        {
        }
        public string GetAuditor(string loginName)
        {
            return base.Channel.GetAuditor(loginName);
        }
        public System.Threading.Tasks.Task<string> GetAuditorAsync(string loginName)
        {
            return base.Channel.GetAuditorAsync(loginName);
        }
        public TextbookManage.WebUI.FeedbackApprovalService.BooksellerView[] GetBooksellerWithNotApproval(string loginName)
        {
            return base.Channel.GetBooksellerWithNotApproval(loginName);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackApprovalService.BooksellerView[]> GetBooksellerWithNotApprovalAsync(string loginName)
        {
            return base.Channel.GetBooksellerWithNotApprovalAsync(loginName);
        }
        public TextbookManage.WebUI.FeedbackApprovalService.FeedbackForApprovalView[] GetFeedbackWithNotApproval(string loginName, string booksellerId)
        {
            return base.Channel.GetFeedbackWithNotApproval(loginName, booksellerId);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackApprovalService.FeedbackForApprovalView[]> GetFeedbackWithNotApprovalAsync(string loginName, string booksellerId)
        {
            return base.Channel.GetFeedbackWithNotApprovalAsync(loginName, booksellerId);
        }
        public TextbookManage.WebUI.FeedbackApprovalService.ResponseView SubmitFeedbackApproval(TextbookManage.WebUI.FeedbackApprovalService.FeedbackForApprovalView[] feedbacks, string loginName, string suggestion, string remark)
        {
            return base.Channel.SubmitFeedbackApproval(feedbacks, loginName, suggestion, remark);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackApprovalService.ResponseView> SubmitFeedbackApprovalAsync(TextbookManage.WebUI.FeedbackApprovalService.FeedbackForApprovalView[] feedbacks, string loginName, string suggestion, string remark)
        {
            return base.Channel.SubmitFeedbackApprovalAsync(feedbacks, loginName, suggestion, remark);
        }
    }
}
