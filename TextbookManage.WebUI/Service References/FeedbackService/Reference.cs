﻿namespace TextbookManage.WebUI.FeedbackService
{
    using System.Runtime.Serialization;
    using System;

    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "SubscriptionForFeedbackView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class SubscriptionForFeedbackView : TextbookManage.WebUI.FeedbackService.TextbookForDeclarationView
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DeclarationCountField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string SpareCountField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string SubscriptionDateField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string SubscriptionIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TotalCountField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string DeclarationCount
        {
            get
            {
                return this.DeclarationCountField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DeclarationCountField, value) != true))
                {
                    this.DeclarationCountField = value;
                    this.RaisePropertyChanged("DeclarationCount");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string SpareCount
        {
            get
            {
                return this.SpareCountField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SpareCountField, value) != true))
                {
                    this.SpareCountField = value;
                    this.RaisePropertyChanged("SpareCount");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string SubscriptionDate
        {
            get
            {
                return this.SubscriptionDateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SubscriptionDateField, value) != true))
                {
                    this.SubscriptionDateField = value;
                    this.RaisePropertyChanged("SubscriptionDate");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string SubscriptionId
        {
            get
            {
                return this.SubscriptionIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SubscriptionIdField, value) != true))
                {
                    this.SubscriptionIdField = value;
                    this.RaisePropertyChanged("SubscriptionId");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string TotalCount
        {
            get
            {
                return this.TotalCountField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TotalCountField, value) != true))
                {
                    this.TotalCountField = value;
                    this.RaisePropertyChanged("TotalCount");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "BaseViewModel", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.FeedbackService.ResponseView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.FeedbackService.BooksellerView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.FeedbackService.FeedbackStateView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.FeedbackService.FeedbackView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.FeedbackService.TextbookForDeclarationView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "ResponseView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class ResponseView : TextbookManage.WebUI.FeedbackService.BaseViewModel
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
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "BooksellerView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class BooksellerView : TextbookManage.WebUI.FeedbackService.BaseViewModel
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "FeedbackStateView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class FeedbackStateView : TextbookManage.WebUI.FeedbackService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string IdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NameField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.IdField, value) != true))
                {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "FeedbackView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class FeedbackView : TextbookManage.WebUI.FeedbackService.BaseViewModel
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "TextbookForDeclarationView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView))]
    public partial class TextbookForDeclarationView : TextbookManage.WebUI.FeedbackService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string IsbnField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NumField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TextbookIdField;
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
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Num
        {
            get
            {
                return this.NumField;
            }
            set
            {
                if ((object.ReferenceEquals(this.NumField, value) != true))
                {
                    this.NumField = value;
                    this.RaisePropertyChanged("Num");
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
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "FeedbackService.IFeedbackAppl")]
    public interface IFeedbackAppl
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/GetSubscriptionWithNotFeedback", ReplyAction = "http://tempuri.org/IFeedbackAppl/GetSubscriptionWithNotFeedbackResponse")]
        TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView[] GetSubscriptionWithNotFeedback(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/GetSubscriptionWithNotFeedback", ReplyAction = "http://tempuri.org/IFeedbackAppl/GetSubscriptionWithNotFeedbackResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView[]> GetSubscriptionWithNotFeedbackAsync(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/SubmitFeedback", ReplyAction = "http://tempuri.org/IFeedbackAppl/SubmitFeedbackResponse")]
        TextbookManage.WebUI.FeedbackService.ResponseView SubmitFeedback(TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView[] subscriptions, string loginName, string feedbackState, string remark);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/SubmitFeedback", ReplyAction = "http://tempuri.org/IFeedbackAppl/SubmitFeedbackResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackService.ResponseView> SubmitFeedbackAsync(TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView[] subscriptions, string loginName, string feedbackState, string remark);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/GetBookseller", ReplyAction = "http://tempuri.org/IFeedbackAppl/GetBooksellerResponse")]
        TextbookManage.WebUI.FeedbackService.BooksellerView[] GetBookseller(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/GetBookseller", ReplyAction = "http://tempuri.org/IFeedbackAppl/GetBooksellerResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackService.BooksellerView[]> GetBooksellerAsync(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/GetFeedbackState", ReplyAction = "http://tempuri.org/IFeedbackAppl/GetFeedbackStateResponse")]
        TextbookManage.WebUI.FeedbackService.FeedbackStateView[] GetFeedbackState();
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/GetFeedbackState", ReplyAction = "http://tempuri.org/IFeedbackAppl/GetFeedbackStateResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackService.FeedbackStateView[]> GetFeedbackStateAsync();
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/GetSubscriptionByBooksellerId", ReplyAction = "http://tempuri.org/IFeedbackAppl/GetSubscriptionByBooksellerIdResponse")]
        TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView[] GetSubscriptionByBooksellerId(string booksellerId, string feedbackStateName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/GetSubscriptionByBooksellerId", ReplyAction = "http://tempuri.org/IFeedbackAppl/GetSubscriptionByBooksellerIdResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView[]> GetSubscriptionByBooksellerIdAsync(string booksellerId, string feedbackStateName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/GetFeedbackBySubscriptionId", ReplyAction = "http://tempuri.org/IFeedbackAppl/GetFeedbackBySubscriptionIdResponse")]
        TextbookManage.WebUI.FeedbackService.FeedbackView GetFeedbackBySubscriptionId(string subscriptionId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/GetFeedbackBySubscriptionId", ReplyAction = "http://tempuri.org/IFeedbackAppl/GetFeedbackBySubscriptionIdResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackService.FeedbackView> GetFeedbackBySubscriptionIdAsync(string subscriptionId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/GetFeedbackPerson", ReplyAction = "http://tempuri.org/IFeedbackAppl/GetFeedbackPersonResponse")]
        string GetFeedbackPerson(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IFeedbackAppl/GetFeedbackPerson", ReplyAction = "http://tempuri.org/IFeedbackAppl/GetFeedbackPersonResponse")]
        System.Threading.Tasks.Task<string> GetFeedbackPersonAsync(string loginName);
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFeedbackApplChannel : TextbookManage.WebUI.FeedbackService.IFeedbackAppl, System.ServiceModel.IClientChannel
    {
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FeedbackApplClient : System.ServiceModel.ClientBase<TextbookManage.WebUI.FeedbackService.IFeedbackAppl>, TextbookManage.WebUI.FeedbackService.IFeedbackAppl
    {
        public FeedbackApplClient()
        {
        }
        public FeedbackApplClient(string endpointConfigurationName)
            :
            base(endpointConfigurationName)
        {
        }
        public FeedbackApplClient(string endpointConfigurationName, string remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public FeedbackApplClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public FeedbackApplClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(binding, remoteAddress)
        {
        }
        public TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView[] GetSubscriptionWithNotFeedback(string loginName)
        {
            return base.Channel.GetSubscriptionWithNotFeedback(loginName);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView[]> GetSubscriptionWithNotFeedbackAsync(string loginName)
        {
            return base.Channel.GetSubscriptionWithNotFeedbackAsync(loginName);
        }
        public TextbookManage.WebUI.FeedbackService.ResponseView SubmitFeedback(TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView[] subscriptions, string loginName, string feedbackState, string remark)
        {
            return base.Channel.SubmitFeedback(subscriptions, loginName, feedbackState, remark);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackService.ResponseView> SubmitFeedbackAsync(TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView[] subscriptions, string loginName, string feedbackState, string remark)
        {
            return base.Channel.SubmitFeedbackAsync(subscriptions, loginName, feedbackState, remark);
        }
        public TextbookManage.WebUI.FeedbackService.BooksellerView[] GetBookseller(string loginName)
        {
            return base.Channel.GetBookseller(loginName);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackService.BooksellerView[]> GetBooksellerAsync(string loginName)
        {
            return base.Channel.GetBooksellerAsync(loginName);
        }
        public TextbookManage.WebUI.FeedbackService.FeedbackStateView[] GetFeedbackState()
        {
            return base.Channel.GetFeedbackState();
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackService.FeedbackStateView[]> GetFeedbackStateAsync()
        {
            return base.Channel.GetFeedbackStateAsync();
        }
        public TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView[] GetSubscriptionByBooksellerId(string booksellerId, string feedbackStateName)
        {
            return base.Channel.GetSubscriptionByBooksellerId(booksellerId, feedbackStateName);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackService.SubscriptionForFeedbackView[]> GetSubscriptionByBooksellerIdAsync(string booksellerId, string feedbackStateName)
        {
            return base.Channel.GetSubscriptionByBooksellerIdAsync(booksellerId, feedbackStateName);
        }
        public TextbookManage.WebUI.FeedbackService.FeedbackView GetFeedbackBySubscriptionId(string subscriptionId)
        {
            return base.Channel.GetFeedbackBySubscriptionId(subscriptionId);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.FeedbackService.FeedbackView> GetFeedbackBySubscriptionIdAsync(string subscriptionId)
        {
            return base.Channel.GetFeedbackBySubscriptionIdAsync(subscriptionId);
        }
        public string GetFeedbackPerson(string loginName)
        {
            return base.Channel.GetFeedbackPerson(loginName);
        }
        public System.Threading.Tasks.Task<string> GetFeedbackPersonAsync(string loginName)
        {
            return base.Channel.GetFeedbackPersonAsync(loginName);
        }
    }
}