﻿namespace TextbookManage.WebUI.DeclarationApprovalService
{
    using System.Runtime.Serialization;
    using System;

    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "SchoolView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class SchoolView : TextbookManage.WebUI.DeclarationApprovalService.BaseViewModel
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
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationApprovalService.DeclarationBaseView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationApprovalService.DeclarationForApprovalView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationApprovalService.ResponseView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationApprovalService.SchoolView))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "DeclarationBaseView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationApprovalService.DeclarationForApprovalView))]
    public partial class DeclarationBaseView : TextbookManage.WebUI.DeclarationApprovalService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DeclarantField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DeclarationCountField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DeclarationDateField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DeclarationIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string MobileField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string ProfessionalClassNameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TeachingTaskNumField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TelephoneField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TextbookIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TextbookNameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string TextbookNumField;
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
        public string ProfessionalClassName
        {
            get
            {
                return this.ProfessionalClassNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ProfessionalClassNameField, value) != true))
                {
                    this.ProfessionalClassNameField = value;
                    this.RaisePropertyChanged("ProfessionalClassName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "DeclarationForApprovalView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class DeclarationForApprovalView : TextbookManage.WebUI.DeclarationApprovalService.DeclarationBaseView
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string CourseNameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string CourseNumField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DataSignNameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string RecipientTypeField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string CourseName
        {
            get
            {
                return this.CourseNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CourseNameField, value) != true))
                {
                    this.CourseNameField = value;
                    this.RaisePropertyChanged("CourseName");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string CourseNum
        {
            get
            {
                return this.CourseNumField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CourseNumField, value) != true))
                {
                    this.CourseNumField = value;
                    this.RaisePropertyChanged("CourseNum");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string DataSignName
        {
            get
            {
                return this.DataSignNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DataSignNameField, value) != true))
                {
                    this.DataSignNameField = value;
                    this.RaisePropertyChanged("DataSignName");
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
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ResponseView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class ResponseView : TextbookManage.WebUI.DeclarationApprovalService.BaseViewModel
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "DeclarationApprovalService.IDeclarationApprovalAppl")]
    public interface IDeclarationApprovalAppl
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationApprovalAppl/GetAuditor", ReplyAction = "http://tempuri.org/IDeclarationApprovalAppl/GetAuditorResponse")]
        string GetAuditor(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationApprovalAppl/GetAuditor", ReplyAction = "http://tempuri.org/IDeclarationApprovalAppl/GetAuditorResponse")]
        System.Threading.Tasks.Task<string> GetAuditorAsync(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationApprovalAppl/GetSchoolWithNotApproval", ReplyAction = "http://tempuri.org/IDeclarationApprovalAppl/GetSchoolWithNotApprovalResponse")]
        TextbookManage.WebUI.DeclarationApprovalService.SchoolView[] GetSchoolWithNotApproval(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationApprovalAppl/GetSchoolWithNotApproval", ReplyAction = "http://tempuri.org/IDeclarationApprovalAppl/GetSchoolWithNotApprovalResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationApprovalService.SchoolView[]> GetSchoolWithNotApprovalAsync(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationApprovalAppl/GetDeclarationWithNotApproval", ReplyAction = "http://tempuri.org/IDeclarationApprovalAppl/GetDeclarationWithNotApprovalResponse" +
        "")]
        TextbookManage.WebUI.DeclarationApprovalService.DeclarationForApprovalView[] GetDeclarationWithNotApproval(string loginName, string schoolId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationApprovalAppl/GetDeclarationWithNotApproval", ReplyAction = "http://tempuri.org/IDeclarationApprovalAppl/GetDeclarationWithNotApprovalResponse" +
        "")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationApprovalService.DeclarationForApprovalView[]> GetDeclarationWithNotApprovalAsync(string loginName, string schoolId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationApprovalAppl/SubmitDeclarationApproval", ReplyAction = "http://tempuri.org/IDeclarationApprovalAppl/SubmitDeclarationApprovalResponse")]
        TextbookManage.WebUI.DeclarationApprovalService.ResponseView SubmitDeclarationApproval(TextbookManage.WebUI.DeclarationApprovalService.DeclarationForApprovalView[] declarations, string loginName, string suggestion, string remark);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationApprovalAppl/SubmitDeclarationApproval", ReplyAction = "http://tempuri.org/IDeclarationApprovalAppl/SubmitDeclarationApprovalResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationApprovalService.ResponseView> SubmitDeclarationApprovalAsync(TextbookManage.WebUI.DeclarationApprovalService.DeclarationForApprovalView[] declarations, string loginName, string suggestion, string remark);
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeclarationApprovalApplChannel : TextbookManage.WebUI.DeclarationApprovalService.IDeclarationApprovalAppl, System.ServiceModel.IClientChannel
    {
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeclarationApprovalApplClient : System.ServiceModel.ClientBase<TextbookManage.WebUI.DeclarationApprovalService.IDeclarationApprovalAppl>, TextbookManage.WebUI.DeclarationApprovalService.IDeclarationApprovalAppl
    {
        public DeclarationApprovalApplClient()
        {
        }
        public DeclarationApprovalApplClient(string endpointConfigurationName)
            :
            base(endpointConfigurationName)
        {
        }
        public DeclarationApprovalApplClient(string endpointConfigurationName, string remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public DeclarationApprovalApplClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public DeclarationApprovalApplClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
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
        public TextbookManage.WebUI.DeclarationApprovalService.SchoolView[] GetSchoolWithNotApproval(string loginName)
        {
            return base.Channel.GetSchoolWithNotApproval(loginName);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationApprovalService.SchoolView[]> GetSchoolWithNotApprovalAsync(string loginName)
        {
            return base.Channel.GetSchoolWithNotApprovalAsync(loginName);
        }
        public TextbookManage.WebUI.DeclarationApprovalService.DeclarationForApprovalView[] GetDeclarationWithNotApproval(string loginName, string schoolId)
        {
            return base.Channel.GetDeclarationWithNotApproval(loginName, schoolId);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationApprovalService.DeclarationForApprovalView[]> GetDeclarationWithNotApprovalAsync(string loginName, string schoolId)
        {
            return base.Channel.GetDeclarationWithNotApprovalAsync(loginName, schoolId);
        }
        public TextbookManage.WebUI.DeclarationApprovalService.ResponseView SubmitDeclarationApproval(TextbookManage.WebUI.DeclarationApprovalService.DeclarationForApprovalView[] declarations, string loginName, string suggestion, string remark)
        {
            return base.Channel.SubmitDeclarationApproval(declarations, loginName, suggestion, remark);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationApprovalService.ResponseView> SubmitDeclarationApprovalAsync(TextbookManage.WebUI.DeclarationApprovalService.DeclarationForApprovalView[] declarations, string loginName, string suggestion, string remark)
        {
            return base.Channel.SubmitDeclarationApprovalAsync(declarations, loginName, suggestion, remark);
        }
    }
}
