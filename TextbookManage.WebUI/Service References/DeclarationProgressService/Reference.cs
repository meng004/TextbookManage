﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18046
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextbookManage.WebUI.DeclarationProgressService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataSignView", Namespace="http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute()]
    public partial class DataSignView : TextbookManage.WebUI.DeclarationProgressService.BaseViewModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DataSignIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DataSignId {
            get {
                return this.DataSignIdField;
            }
            set {
                if ((object.ReferenceEquals(this.DataSignIdField, value) != true)) {
                    this.DataSignIdField = value;
                    this.RaisePropertyChanged("DataSignId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseViewModel", Namespace="http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationProgressService.SchoolProgressView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationProgressService.DepartmentProgressView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationProgressService.DepartmentView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationProgressService.DataSignView))]
    public partial class BaseViewModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CheckFlagField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DeleteFlagField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsDeleteField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool CheckFlag {
            get {
                return this.CheckFlagField;
            }
            set {
                if ((this.CheckFlagField.Equals(value) != true)) {
                    this.CheckFlagField = value;
                    this.RaisePropertyChanged("CheckFlag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DeleteFlag {
            get {
                return this.DeleteFlagField;
            }
            set {
                if ((object.ReferenceEquals(this.DeleteFlagField, value) != true)) {
                    this.DeleteFlagField = value;
                    this.RaisePropertyChanged("DeleteFlag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsDelete {
            get {
                return this.IsDeleteField;
            }
            set {
                if ((this.IsDeleteField.Equals(value) != true)) {
                    this.IsDeleteField = value;
                    this.RaisePropertyChanged("IsDelete");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SchoolProgressView", Namespace="http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.DeclarationProgressService.DepartmentProgressView))]
    public partial class SchoolProgressView : TextbookManage.WebUI.DeclarationProgressService.BaseViewModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FinishedCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProportionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RestCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SchoolIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TotalCountField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FinishedCount {
            get {
                return this.FinishedCountField;
            }
            set {
                if ((object.ReferenceEquals(this.FinishedCountField, value) != true)) {
                    this.FinishedCountField = value;
                    this.RaisePropertyChanged("FinishedCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Proportion {
            get {
                return this.ProportionField;
            }
            set {
                if ((object.ReferenceEquals(this.ProportionField, value) != true)) {
                    this.ProportionField = value;
                    this.RaisePropertyChanged("Proportion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RestCount {
            get {
                return this.RestCountField;
            }
            set {
                if ((object.ReferenceEquals(this.RestCountField, value) != true)) {
                    this.RestCountField = value;
                    this.RaisePropertyChanged("RestCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SchoolId {
            get {
                return this.SchoolIdField;
            }
            set {
                if ((object.ReferenceEquals(this.SchoolIdField, value) != true)) {
                    this.SchoolIdField = value;
                    this.RaisePropertyChanged("SchoolId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TotalCount {
            get {
                return this.TotalCountField;
            }
            set {
                if ((object.ReferenceEquals(this.TotalCountField, value) != true)) {
                    this.TotalCountField = value;
                    this.RaisePropertyChanged("TotalCount");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DepartmentProgressView", Namespace="http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute()]
    public partial class DepartmentProgressView : TextbookManage.WebUI.DeclarationProgressService.SchoolProgressView {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CourseNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CourseNumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DataSignNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CourseName {
            get {
                return this.CourseNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CourseNameField, value) != true)) {
                    this.CourseNameField = value;
                    this.RaisePropertyChanged("CourseName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CourseNum {
            get {
                return this.CourseNumField;
            }
            set {
                if ((object.ReferenceEquals(this.CourseNumField, value) != true)) {
                    this.CourseNumField = value;
                    this.RaisePropertyChanged("CourseNum");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DataSignName {
            get {
                return this.DataSignNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DataSignNameField, value) != true)) {
                    this.DataSignNameField = value;
                    this.RaisePropertyChanged("DataSignName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DepartmentId {
            get {
                return this.DepartmentIdField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentIdField, value) != true)) {
                    this.DepartmentIdField = value;
                    this.RaisePropertyChanged("DepartmentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DepartmentName {
            get {
                return this.DepartmentNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentNameField, value) != true)) {
                    this.DepartmentNameField = value;
                    this.RaisePropertyChanged("DepartmentName");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DepartmentView", Namespace="http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute()]
    public partial class DepartmentView : TextbookManage.WebUI.DeclarationProgressService.BaseViewModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DepartmentId {
            get {
                return this.DepartmentIdField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentIdField, value) != true)) {
                    this.DepartmentIdField = value;
                    this.RaisePropertyChanged("DepartmentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DeclarationProgressService.IDeclarationProgressAppl")]
    public interface IDeclarationProgressAppl {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeclarationProgressAppl/GetDataSign", ReplyAction="http://tempuri.org/IDeclarationProgressAppl/GetDataSignResponse")]
        TextbookManage.WebUI.DeclarationProgressService.DataSignView[] GetDataSign();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeclarationProgressAppl/GetDataSign", ReplyAction="http://tempuri.org/IDeclarationProgressAppl/GetDataSignResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationProgressService.DataSignView[]> GetDataSignAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeclarationProgressAppl/GetSchoolProgress", ReplyAction="http://tempuri.org/IDeclarationProgressAppl/GetSchoolProgressResponse")]
        TextbookManage.WebUI.DeclarationProgressService.SchoolProgressView[] GetSchoolProgress(string dataSignId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeclarationProgressAppl/GetSchoolProgress", ReplyAction="http://tempuri.org/IDeclarationProgressAppl/GetSchoolProgressResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationProgressService.SchoolProgressView[]> GetSchoolProgressAsync(string dataSignId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeclarationProgressAppl/GetDepartments", ReplyAction="http://tempuri.org/IDeclarationProgressAppl/GetDepartmentsResponse")]
        TextbookManage.WebUI.DeclarationProgressService.DepartmentView[] GetDepartments(string schoolId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeclarationProgressAppl/GetDepartments", ReplyAction="http://tempuri.org/IDeclarationProgressAppl/GetDepartmentsResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationProgressService.DepartmentView[]> GetDepartmentsAsync(string schoolId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeclarationProgressAppl/GetDepartmentProgress", ReplyAction="http://tempuri.org/IDeclarationProgressAppl/GetDepartmentProgressResponse")]
        TextbookManage.WebUI.DeclarationProgressService.DepartmentProgressView[] GetDepartmentProgress(string dataSignId, string departmentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeclarationProgressAppl/GetDepartmentProgress", ReplyAction="http://tempuri.org/IDeclarationProgressAppl/GetDepartmentProgressResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationProgressService.DepartmentProgressView[]> GetDepartmentProgressAsync(string dataSignId, string departmentId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeclarationProgressApplChannel : TextbookManage.WebUI.DeclarationProgressService.IDeclarationProgressAppl, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeclarationProgressApplClient : System.ServiceModel.ClientBase<TextbookManage.WebUI.DeclarationProgressService.IDeclarationProgressAppl>, TextbookManage.WebUI.DeclarationProgressService.IDeclarationProgressAppl {
        
        public DeclarationProgressApplClient() {
        }
        
        public DeclarationProgressApplClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DeclarationProgressApplClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DeclarationProgressApplClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DeclarationProgressApplClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TextbookManage.WebUI.DeclarationProgressService.DataSignView[] GetDataSign() {
            return base.Channel.GetDataSign();
        }
        
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationProgressService.DataSignView[]> GetDataSignAsync() {
            return base.Channel.GetDataSignAsync();
        }
        
        public TextbookManage.WebUI.DeclarationProgressService.SchoolProgressView[] GetSchoolProgress(string dataSignId) {
            return base.Channel.GetSchoolProgress(dataSignId);
        }
        
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationProgressService.SchoolProgressView[]> GetSchoolProgressAsync(string dataSignId) {
            return base.Channel.GetSchoolProgressAsync(dataSignId);
        }
        
        public TextbookManage.WebUI.DeclarationProgressService.DepartmentView[] GetDepartments(string schoolId) {
            return base.Channel.GetDepartments(schoolId);
        }
        
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationProgressService.DepartmentView[]> GetDepartmentsAsync(string schoolId) {
            return base.Channel.GetDepartmentsAsync(schoolId);
        }
        
        public TextbookManage.WebUI.DeclarationProgressService.DepartmentProgressView[] GetDepartmentProgress(string dataSignId, string departmentId) {
            return base.Channel.GetDepartmentProgress(dataSignId, departmentId);
        }
        
        public System.Threading.Tasks.Task<TextbookManage.WebUI.DeclarationProgressService.DepartmentProgressView[]> GetDepartmentProgressAsync(string dataSignId, string departmentId) {
            return base.Channel.GetDepartmentProgressAsync(dataSignId, departmentId);
        }
    }
}
