﻿namespace TextbookManage.WebUI.TextbookApprovalService
{
    using System.Runtime.Serialization;
    using System;

    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "SchoolView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class SchoolView : TextbookManage.WebUI.TextbookApprovalService.BaseViewModel
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "BaseViewModel", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.TextbookApprovalService.TextbookView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.TextbookApprovalService.TextbookForQueryView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.TextbookApprovalService.ResponseView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.TextbookApprovalService.SchoolView))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "TextbookView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.TextbookApprovalService.TextbookForQueryView))]
    public partial class TextbookView : TextbookManage.WebUI.TextbookApprovalService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string AuthorField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string EditionField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string IsSelfCompileField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string IsbnField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NumField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string PageCountField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string PressField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string PressAddressField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private decimal PriceField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string PrintCountField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private System.DateTime PublishDateField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TextbookIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TextbookTypeField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Author
        {
            get
            {
                return this.AuthorField;
            }
            set
            {
                if ((object.ReferenceEquals(this.AuthorField, value) != true))
                {
                    this.AuthorField = value;
                    this.RaisePropertyChanged("Author");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Edition
        {
            get
            {
                return this.EditionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.EditionField, value) != true))
                {
                    this.EditionField = value;
                    this.RaisePropertyChanged("Edition");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string IsSelfCompile
        {
            get
            {
                return this.IsSelfCompileField;
            }
            set
            {
                if ((object.ReferenceEquals(this.IsSelfCompileField, value) != true))
                {
                    this.IsSelfCompileField = value;
                    this.RaisePropertyChanged("IsSelfCompile");
                }
            }
        }
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
        public string PageCount
        {
            get
            {
                return this.PageCountField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PageCountField, value) != true))
                {
                    this.PageCountField = value;
                    this.RaisePropertyChanged("PageCount");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Press
        {
            get
            {
                return this.PressField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PressField, value) != true))
                {
                    this.PressField = value;
                    this.RaisePropertyChanged("Press");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string PressAddress
        {
            get
            {
                return this.PressAddressField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PressAddressField, value) != true))
                {
                    this.PressAddressField = value;
                    this.RaisePropertyChanged("PressAddress");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public decimal Price
        {
            get
            {
                return this.PriceField;
            }
            set
            {
                if ((this.PriceField.Equals(value) != true))
                {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string PrintCount
        {
            get
            {
                return this.PrintCountField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PrintCountField, value) != true))
                {
                    this.PrintCountField = value;
                    this.RaisePropertyChanged("PrintCount");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public System.DateTime PublishDate
        {
            get
            {
                return this.PublishDateField;
            }
            set
            {
                if ((this.PublishDateField.Equals(value) != true))
                {
                    this.PublishDateField = value;
                    this.RaisePropertyChanged("PublishDate");
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
        public string TextbookType
        {
            get
            {
                return this.TextbookTypeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TextbookTypeField, value) != true))
                {
                    this.TextbookTypeField = value;
                    this.RaisePropertyChanged("TextbookType");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "TextbookForQueryView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class TextbookForQueryView : TextbookManage.WebUI.TextbookApprovalService.TextbookView
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string ApprovalStateField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DeclarantField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DeclarationDateField;
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
        public string Declarant
        {
            get
            {
                return this.DeclarantField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DeclarantField, value) != true))
                {
                    this.DeclarantField = value;
                    this.RaisePropertyChanged("Declarant");
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
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ResponseView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class ResponseView : TextbookManage.WebUI.TextbookApprovalService.BaseViewModel
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "TextbookApprovalService.ITextbookApprovalAppl")]
    public interface ITextbookApprovalAppl
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ITextbookApprovalAppl/GetAuditor", ReplyAction = "http://tempuri.org/ITextbookApprovalAppl/GetAuditorResponse")]
        string GetAuditor(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ITextbookApprovalAppl/GetAuditor", ReplyAction = "http://tempuri.org/ITextbookApprovalAppl/GetAuditorResponse")]
        System.Threading.Tasks.Task<string> GetAuditorAsync(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ITextbookApprovalAppl/GetSchoolWithNotApproval", ReplyAction = "http://tempuri.org/ITextbookApprovalAppl/GetSchoolWithNotApprovalResponse")]
        TextbookManage.WebUI.TextbookApprovalService.SchoolView[] GetSchoolWithNotApproval(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ITextbookApprovalAppl/GetSchoolWithNotApproval", ReplyAction = "http://tempuri.org/ITextbookApprovalAppl/GetSchoolWithNotApprovalResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.TextbookApprovalService.SchoolView[]> GetSchoolWithNotApprovalAsync(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ITextbookApprovalAppl/GetTextbookWithNotApproval", ReplyAction = "http://tempuri.org/ITextbookApprovalAppl/GetTextbookWithNotApprovalResponse")]
        TextbookManage.WebUI.TextbookApprovalService.TextbookForQueryView[] GetTextbookWithNotApproval(string loginName, string schoolId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ITextbookApprovalAppl/GetTextbookWithNotApproval", ReplyAction = "http://tempuri.org/ITextbookApprovalAppl/GetTextbookWithNotApprovalResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.TextbookApprovalService.TextbookForQueryView[]> GetTextbookWithNotApprovalAsync(string loginName, string schoolId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ITextbookApprovalAppl/SubmitTextbookApproval", ReplyAction = "http://tempuri.org/ITextbookApprovalAppl/SubmitTextbookApprovalResponse")]
        TextbookManage.WebUI.TextbookApprovalService.ResponseView SubmitTextbookApproval(TextbookManage.WebUI.TextbookApprovalService.TextbookForQueryView[] textbook, string loginName, string suggestion, string remark);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ITextbookApprovalAppl/SubmitTextbookApproval", ReplyAction = "http://tempuri.org/ITextbookApprovalAppl/SubmitTextbookApprovalResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.TextbookApprovalService.ResponseView> SubmitTextbookApprovalAsync(TextbookManage.WebUI.TextbookApprovalService.TextbookForQueryView[] textbook, string loginName, string suggestion, string remark);
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITextbookApprovalApplChannel : TextbookManage.WebUI.TextbookApprovalService.ITextbookApprovalAppl, System.ServiceModel.IClientChannel
    {
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TextbookApprovalApplClient : System.ServiceModel.ClientBase<TextbookManage.WebUI.TextbookApprovalService.ITextbookApprovalAppl>, TextbookManage.WebUI.TextbookApprovalService.ITextbookApprovalAppl
    {
        public TextbookApprovalApplClient()
        {
        }
        public TextbookApprovalApplClient(string endpointConfigurationName)
            :
            base(endpointConfigurationName)
        {
        }
        public TextbookApprovalApplClient(string endpointConfigurationName, string remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public TextbookApprovalApplClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public TextbookApprovalApplClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
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
        public TextbookManage.WebUI.TextbookApprovalService.SchoolView[] GetSchoolWithNotApproval(string loginName)
        {
            return base.Channel.GetSchoolWithNotApproval(loginName);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.TextbookApprovalService.SchoolView[]> GetSchoolWithNotApprovalAsync(string loginName)
        {
            return base.Channel.GetSchoolWithNotApprovalAsync(loginName);
        }
        public TextbookManage.WebUI.TextbookApprovalService.TextbookForQueryView[] GetTextbookWithNotApproval(string loginName, string schoolId)
        {
            return base.Channel.GetTextbookWithNotApproval(loginName, schoolId);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.TextbookApprovalService.TextbookForQueryView[]> GetTextbookWithNotApprovalAsync(string loginName, string schoolId)
        {
            return base.Channel.GetTextbookWithNotApprovalAsync(loginName, schoolId);
        }
        public TextbookManage.WebUI.TextbookApprovalService.ResponseView SubmitTextbookApproval(TextbookManage.WebUI.TextbookApprovalService.TextbookForQueryView[] textbook, string loginName, string suggestion, string remark)
        {
            return base.Channel.SubmitTextbookApproval(textbook, loginName, suggestion, remark);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.TextbookApprovalService.ResponseView> SubmitTextbookApprovalAsync(TextbookManage.WebUI.TextbookApprovalService.TextbookForQueryView[] textbook, string loginName, string suggestion, string remark)
        {
            return base.Channel.SubmitTextbookApprovalAsync(textbook, loginName, suggestion, remark);
        }
    }
}
