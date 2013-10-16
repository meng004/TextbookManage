namespace TextbookManage.WebUI.SubscriptionService
{
    using System.Runtime.Serialization;
    using System;

    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "BooksellerView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class BooksellerView : TextbookManage.WebUI.SubscriptionService.BaseViewModel
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
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.SubscriptionService.TextbookForDeclarationView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.SubscriptionService.DeclarationView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.SubscriptionService.SchoolView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.SubscriptionService.ResponseView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.SubscriptionService.BooksellerView))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "TextbookForDeclarationView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView))]
    public partial class TextbookForDeclarationView : TextbookManage.WebUI.SubscriptionService.BaseViewModel
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
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "SubscriptionForSubmitView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class SubscriptionForSubmitView : TextbookManage.WebUI.SubscriptionService.TextbookForDeclarationView
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DeclarationCountField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private TextbookManage.WebUI.SubscriptionService.DeclarationView[] DeclarationsField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string SubscriptionIdField;
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
        public TextbookManage.WebUI.SubscriptionService.DeclarationView[] Declarations
        {
            get
            {
                return this.DeclarationsField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DeclarationsField, value) != true))
                {
                    this.DeclarationsField = value;
                    this.RaisePropertyChanged("Declarations");
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
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "DeclarationView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class DeclarationView : TextbookManage.WebUI.SubscriptionService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string ApprovalStateField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DeclarationCountField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DeclarationDateField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DeclarationIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string HadViewFeedbackField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string MobileField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string ProfessionalClassIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string RecipientTypeField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TeacherIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TeachingTaskNumField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TelephoneField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TermField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TextbookIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string ViewFeedbackDateField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string ApprovalState
        {
            get
            {
                return this.ApprovalStateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ApprovalStateField, value) != true))
                {
                    this.ApprovalStateField = value;
                    this.RaisePropertyChanged("ApprovalState");
                }
            }
        }
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
        public string DeclarationDate
        {
            get
            {
                return this.DeclarationDateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DeclarationDateField, value) != true))
                {
                    this.DeclarationDateField = value;
                    this.RaisePropertyChanged("DeclarationDate");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string DeclarationId
        {
            get
            {
                return this.DeclarationIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DeclarationIdField, value) != true))
                {
                    this.DeclarationIdField = value;
                    this.RaisePropertyChanged("DeclarationId");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string HadViewFeedback
        {
            get
            {
                return this.HadViewFeedbackField;
            }
            set
            {
                if ((object.ReferenceEquals(this.HadViewFeedbackField, value) != true))
                {
                    this.HadViewFeedbackField = value;
                    this.RaisePropertyChanged("HadViewFeedback");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Mobile
        {
            get
            {
                return this.MobileField;
            }
            set
            {
                if ((object.ReferenceEquals(this.MobileField, value) != true))
                {
                    this.MobileField = value;
                    this.RaisePropertyChanged("Mobile");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string ProfessionalClassId
        {
            get
            {
                return this.ProfessionalClassIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ProfessionalClassIdField, value) != true))
                {
                    this.ProfessionalClassIdField = value;
                    this.RaisePropertyChanged("ProfessionalClassId");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string RecipientType
        {
            get
            {
                return this.RecipientTypeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.RecipientTypeField, value) != true))
                {
                    this.RecipientTypeField = value;
                    this.RaisePropertyChanged("RecipientType");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string TeacherId
        {
            get
            {
                return this.TeacherIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TeacherIdField, value) != true))
                {
                    this.TeacherIdField = value;
                    this.RaisePropertyChanged("TeacherId");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string TeachingTaskNum
        {
            get
            {
                return this.TeachingTaskNumField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TeachingTaskNumField, value) != true))
                {
                    this.TeachingTaskNumField = value;
                    this.RaisePropertyChanged("TeachingTaskNum");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Telephone
        {
            get
            {
                return this.TelephoneField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TelephoneField, value) != true))
                {
                    this.TelephoneField = value;
                    this.RaisePropertyChanged("Telephone");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Term
        {
            get
            {
                return this.TermField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TermField, value) != true))
                {
                    this.TermField = value;
                    this.RaisePropertyChanged("Term");
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
        public string ViewFeedbackDate
        {
            get
            {
                return this.ViewFeedbackDateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ViewFeedbackDateField, value) != true))
                {
                    this.ViewFeedbackDateField = value;
                    this.RaisePropertyChanged("ViewFeedbackDate");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "SchoolView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class SchoolView : TextbookManage.WebUI.SubscriptionService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string SchoolIdField;
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
        public string SchoolId
        {
            get
            {
                return this.SchoolIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SchoolIdField, value) != true))
                {
                    this.SchoolIdField = value;
                    this.RaisePropertyChanged("SchoolId");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ResponseView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class ResponseView : TextbookManage.WebUI.SubscriptionService.BaseViewModel
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "SubscriptionService.ISubscriptionAppl")]
    public interface ISubscriptionAppl
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ISubscriptionAppl/GetBookseller", ReplyAction = "http://tempuri.org/ISubscriptionAppl/GetBooksellerResponse")]
        TextbookManage.WebUI.SubscriptionService.BooksellerView[] GetBookseller();
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ISubscriptionAppl/GetBookseller", ReplyAction = "http://tempuri.org/ISubscriptionAppl/GetBooksellerResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.SubscriptionService.BooksellerView[]> GetBooksellerAsync();
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ISubscriptionAppl/CreateSubscriptionByTextbook", ReplyAction = "http://tempuri.org/ISubscriptionAppl/CreateSubscriptionByTextbookResponse")]
        TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView[] CreateSubscriptionByTextbook(string textbookName, string isbn);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ISubscriptionAppl/CreateSubscriptionByTextbook", ReplyAction = "http://tempuri.org/ISubscriptionAppl/CreateSubscriptionByTextbookResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView[]> CreateSubscriptionByTextbookAsync(string textbookName, string isbn);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ISubscriptionAppl/GetSchoolWithNotSub", ReplyAction = "http://tempuri.org/ISubscriptionAppl/GetSchoolWithNotSubResponse")]
        TextbookManage.WebUI.SubscriptionService.SchoolView[] GetSchoolWithNotSub();
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ISubscriptionAppl/GetSchoolWithNotSub", ReplyAction = "http://tempuri.org/ISubscriptionAppl/GetSchoolWithNotSubResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.SubscriptionService.SchoolView[]> GetSchoolWithNotSubAsync();
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ISubscriptionAppl/CreateSubscriptionBySchoolId", ReplyAction = "http://tempuri.org/ISubscriptionAppl/CreateSubscriptionBySchoolIdResponse")]
        TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView[] CreateSubscriptionBySchoolId(string schoolId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ISubscriptionAppl/CreateSubscriptionBySchoolId", ReplyAction = "http://tempuri.org/ISubscriptionAppl/CreateSubscriptionBySchoolIdResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView[]> CreateSubscriptionBySchoolIdAsync(string schoolId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ISubscriptionAppl/SubmitSubscription", ReplyAction = "http://tempuri.org/ISubscriptionAppl/SubmitSubscriptionResponse")]
        TextbookManage.WebUI.SubscriptionService.ResponseView SubmitSubscription(TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView[] subscriptions, string booksellerId, string spareCount);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ISubscriptionAppl/SubmitSubscription", ReplyAction = "http://tempuri.org/ISubscriptionAppl/SubmitSubscriptionResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.SubscriptionService.ResponseView> SubmitSubscriptionAsync(TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView[] subscriptions, string booksellerId, string spareCount);
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISubscriptionApplChannel : TextbookManage.WebUI.SubscriptionService.ISubscriptionAppl, System.ServiceModel.IClientChannel
    {
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SubscriptionApplClient : System.ServiceModel.ClientBase<TextbookManage.WebUI.SubscriptionService.ISubscriptionAppl>, TextbookManage.WebUI.SubscriptionService.ISubscriptionAppl
    {
        public SubscriptionApplClient()
        {
        }
        public SubscriptionApplClient(string endpointConfigurationName)
            :
            base(endpointConfigurationName)
        {
        }
        public SubscriptionApplClient(string endpointConfigurationName, string remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public SubscriptionApplClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public SubscriptionApplClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(binding, remoteAddress)
        {
        }
        public TextbookManage.WebUI.SubscriptionService.BooksellerView[] GetBookseller()
        {
            return base.Channel.GetBookseller();
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.SubscriptionService.BooksellerView[]> GetBooksellerAsync()
        {
            return base.Channel.GetBooksellerAsync();
        }
        public TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView[] CreateSubscriptionByTextbook(string textbookName, string isbn)
        {
            return base.Channel.CreateSubscriptionByTextbook(textbookName, isbn);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView[]> CreateSubscriptionByTextbookAsync(string textbookName, string isbn)
        {
            return base.Channel.CreateSubscriptionByTextbookAsync(textbookName, isbn);
        }
        public TextbookManage.WebUI.SubscriptionService.SchoolView[] GetSchoolWithNotSub()
        {
            return base.Channel.GetSchoolWithNotSub();
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.SubscriptionService.SchoolView[]> GetSchoolWithNotSubAsync()
        {
            return base.Channel.GetSchoolWithNotSubAsync();
        }
        public TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView[] CreateSubscriptionBySchoolId(string schoolId)
        {
            return base.Channel.CreateSubscriptionBySchoolId(schoolId);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView[]> CreateSubscriptionBySchoolIdAsync(string schoolId)
        {
            return base.Channel.CreateSubscriptionBySchoolIdAsync(schoolId);
        }
        public TextbookManage.WebUI.SubscriptionService.ResponseView SubmitSubscription(TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView[] subscriptions, string booksellerId, string spareCount)
        {
            return base.Channel.SubmitSubscription(subscriptions, booksellerId, spareCount);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.SubscriptionService.ResponseView> SubmitSubscriptionAsync(TextbookManage.WebUI.SubscriptionService.SubscriptionForSubmitView[] subscriptions, string booksellerId, string spareCount)
        {
            return base.Channel.SubmitSubscriptionAsync(subscriptions, booksellerId, spareCount);
        }
    }
}
