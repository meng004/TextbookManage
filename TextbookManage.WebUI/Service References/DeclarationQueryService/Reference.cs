namespace TextbookManage.WebUI.DeclarationQueryService
{
    using System.Runtime.Serialization;
    using System;

    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "SchoolView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class SchoolView : TextbookManage.WebUI.DeclarationQueryService.BaseViewModel
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
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationQueryService.DepartmentView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationQueryService.TermView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationQueryService.RecipientTypeView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationQueryService.CourseView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationQueryService.DeclarationBaseView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationQueryService.DeclarationForQueryView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationQueryService.ApprovalView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationQueryService.FeedbackView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationQueryService.SchoolView))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "DepartmentView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class DepartmentView : TextbookManage.WebUI.DeclarationQueryService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DepartmentIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NameField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string DepartmentId
        {
            get
            {
                return this.DepartmentIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DepartmentIdField, value) != true))
                {
                    this.DepartmentIdField = value;
                    this.RaisePropertyChanged("DepartmentId");
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "TermView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class TermView : TextbookManage.WebUI.DeclarationQueryService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string IsCurrentField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string YearTermField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string IsCurrent
        {
            get
            {
                return this.IsCurrentField;
            }
            set
            {
                if ((object.ReferenceEquals(this.IsCurrentField, value) != true))
                {
                    this.IsCurrentField = value;
                    this.RaisePropertyChanged("IsCurrent");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string YearTerm
        {
            get
            {
                return this.YearTermField;
            }
            set
            {
                if ((object.ReferenceEquals(this.YearTermField, value) != true))
                {
                    this.YearTermField = value;
                    this.RaisePropertyChanged("YearTerm");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "RecipientTypeView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class RecipientTypeView : TextbookManage.WebUI.DeclarationQueryService.BaseViewModel
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "CourseView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class CourseView : TextbookManage.WebUI.DeclarationQueryService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string CourseIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NumField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NumAndNameField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string CourseId
        {
            get
            {
                return this.CourseIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CourseIdField, value) != true))
                {
                    this.CourseIdField = value;
                    this.RaisePropertyChanged("CourseId");
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
        public string NumAndName
        {
            get
            {
                return this.NumAndNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.NumAndNameField, value) != true))
                {
                    this.NumAndNameField = value;
                    this.RaisePropertyChanged("NumAndName");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "DeclarationBaseView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationQueryService.DeclarationForQueryView))]
    public partial class DeclarationBaseView : TextbookManage.WebUI.DeclarationQueryService.BaseViewModel
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "DeclarationForQueryView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class DeclarationForQueryView : TextbookManage.WebUI.DeclarationQueryService.DeclarationBaseView
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string ApprovalStateField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string FeedbackStateField;
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
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ApprovalView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class ApprovalView : TextbookManage.WebUI.DeclarationQueryService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string ApprovalDateField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string ApprovalIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string AuditorField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string DivisionField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string RemarkField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string SuggestionField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string ApprovalDate
        {
            get
            {
                return this.ApprovalDateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ApprovalDateField, value) != true))
                {
                    this.ApprovalDateField = value;
                    this.RaisePropertyChanged("ApprovalDate");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string ApprovalId
        {
            get
            {
                return this.ApprovalIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ApprovalIdField, value) != true))
                {
                    this.ApprovalIdField = value;
                    this.RaisePropertyChanged("ApprovalId");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Auditor
        {
            get
            {
                return this.AuditorField;
            }
            set
            {
                if ((object.ReferenceEquals(this.AuditorField, value) != true))
                {
                    this.AuditorField = value;
                    this.RaisePropertyChanged("Auditor");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Division
        {
            get
            {
                return this.DivisionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DivisionField, value) != true))
                {
                    this.DivisionField = value;
                    this.RaisePropertyChanged("Division");
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
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Suggestion
        {
            get
            {
                return this.SuggestionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SuggestionField, value) != true))
                {
                    this.SuggestionField = value;
                    this.RaisePropertyChanged("Suggestion");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "FeedbackView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class FeedbackView : TextbookManage.WebUI.DeclarationQueryService.BaseViewModel
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "DeclarationQueryService.IDeclarationQueryAppl")]
    public interface IDeclarationQueryAppl
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetSchoolByLoginName", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetSchoolByLoginNameResponse")]
        TextbookManage.WebUI.DeclarationQueryService.SchoolView[] GetSchoolByLoginName(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetSchoolByLoginName", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetSchoolByLoginNameResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.SchoolView[]> GetSchoolByLoginNameAsync(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetDepartmentBySchoolId", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetDepartmentBySchoolIdResponse")]
        TextbookManage.WebUI.DeclarationQueryService.DepartmentView[] GetDepartmentBySchoolId(string loginName, string schoolId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetDepartmentBySchoolId", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetDepartmentBySchoolIdResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.DepartmentView[]> GetDepartmentBySchoolIdAsync(string loginName, string schoolId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetTerm", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetTermResponse")]
        TextbookManage.WebUI.DeclarationQueryService.TermView[] GetTerm();
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetTerm", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetTermResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.TermView[]> GetTermAsync();
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetRecipientType", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetRecipientTypeResponse")]
        TextbookManage.WebUI.DeclarationQueryService.RecipientTypeView[] GetRecipientType();
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetRecipientType", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetRecipientTypeResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.RecipientTypeView[]> GetRecipientTypeAsync();
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetCourseByDepartmentId", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetCourseByDepartmentIdResponse")]
        TextbookManage.WebUI.DeclarationQueryService.CourseView[] GetCourseByDepartmentId(string departmentId, string term);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetCourseByDepartmentId", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetCourseByDepartmentIdResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.CourseView[]> GetCourseByDepartmentIdAsync(string departmentId, string term);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetDeclarationByCourseId", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetDeclarationByCourseIdResponse")]
        TextbookManage.WebUI.DeclarationQueryService.DeclarationForQueryView[] GetDeclarationByCourseId(string courseId, string departmentId, string term, string recipientTypeName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetDeclarationByCourseId", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetDeclarationByCourseIdResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.DeclarationForQueryView[]> GetDeclarationByCourseIdAsync(string courseId, string departmentId, string term, string recipientTypeName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetDeclarationApproval", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetDeclarationApprovalResponse")]
        TextbookManage.WebUI.DeclarationQueryService.ApprovalView[] GetDeclarationApproval(string declarationId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetDeclarationApproval", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetDeclarationApprovalResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.ApprovalView[]> GetDeclarationApprovalAsync(string declarationId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetFeedbackByDeclarationId", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetFeedbackByDeclarationIdResponse")]
        TextbookManage.WebUI.DeclarationQueryService.FeedbackView GetFeedbackByDeclarationId(string declarationId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IDeclarationQueryAppl/GetFeedbackByDeclarationId", ReplyAction = "http://tempuri.org/IDeclarationQueryAppl/GetFeedbackByDeclarationIdResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.FeedbackView> GetFeedbackByDeclarationIdAsync(string declarationId);
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeclarationQueryApplChannel : TextbookManage.WebUI.DeclarationQueryService.IDeclarationQueryAppl, System.ServiceModel.IClientChannel
    {
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeclarationQueryApplClient : System.ServiceModel.ClientBase<TextbookManage.WebUI.DeclarationQueryService.IDeclarationQueryAppl>, TextbookManage.WebUI.DeclarationQueryService.IDeclarationQueryAppl
    {
        public DeclarationQueryApplClient()
        {
        }
        public DeclarationQueryApplClient(string endpointConfigurationName)
            :
            base(endpointConfigurationName)
        {
        }
        public DeclarationQueryApplClient(string endpointConfigurationName, string remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public DeclarationQueryApplClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public DeclarationQueryApplClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(binding, remoteAddress)
        {
        }
        public TextbookManage.WebUI.DeclarationQueryService.SchoolView[] GetSchoolByLoginName(string loginName)
        {
            return base.Channel.GetSchoolByLoginName(loginName);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.SchoolView[]> GetSchoolByLoginNameAsync(string loginName)
        {
            return base.Channel.GetSchoolByLoginNameAsync(loginName);
        }
        public TextbookManage.WebUI.DeclarationQueryService.DepartmentView[] GetDepartmentBySchoolId(string loginName, string schoolId)
        {
            return base.Channel.GetDepartmentBySchoolId(loginName, schoolId);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.DepartmentView[]> GetDepartmentBySchoolIdAsync(string loginName, string schoolId)
        {
            return base.Channel.GetDepartmentBySchoolIdAsync(loginName, schoolId);
        }
        public TextbookManage.WebUI.DeclarationQueryService.TermView[] GetTerm()
        {
            return base.Channel.GetTerm();
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.TermView[]> GetTermAsync()
        {
            return base.Channel.GetTermAsync();
        }
        public TextbookManage.WebUI.DeclarationQueryService.RecipientTypeView[] GetRecipientType()
        {
            return base.Channel.GetRecipientType();
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.RecipientTypeView[]> GetRecipientTypeAsync()
        {
            return base.Channel.GetRecipientTypeAsync();
        }
        public TextbookManage.WebUI.DeclarationQueryService.CourseView[] GetCourseByDepartmentId(string departmentId, string term)
        {
            return base.Channel.GetCourseByDepartmentId(departmentId, term);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.CourseView[]> GetCourseByDepartmentIdAsync(string departmentId, string term)
        {
            return base.Channel.GetCourseByDepartmentIdAsync(departmentId, term);
        }
        public TextbookManage.WebUI.DeclarationQueryService.DeclarationForQueryView[] GetDeclarationByCourseId(string courseId, string departmentId, string term, string recipientTypeName)
        {
            return base.Channel.GetDeclarationByCourseId(courseId, departmentId, term, recipientTypeName);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.DeclarationForQueryView[]> GetDeclarationByCourseIdAsync(string courseId, string departmentId, string term, string recipientTypeName)
        {
            return base.Channel.GetDeclarationByCourseIdAsync(courseId, departmentId, term, recipientTypeName);
        }
        public TextbookManage.WebUI.DeclarationQueryService.ApprovalView[] GetDeclarationApproval(string declarationId)
        {
            return base.Channel.GetDeclarationApproval(declarationId);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.ApprovalView[]> GetDeclarationApprovalAsync(string declarationId)
        {
            return base.Channel.GetDeclarationApprovalAsync(declarationId);
        }
        public TextbookManage.WebUI.DeclarationQueryService.FeedbackView GetFeedbackByDeclarationId(string declarationId)
        {
            return base.Channel.GetFeedbackByDeclarationId(declarationId);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationQueryService.FeedbackView> GetFeedbackByDeclarationIdAsync(string declarationId)
        {
            return base.Channel.GetFeedbackByDeclarationIdAsync(declarationId);
        }
    }
}
