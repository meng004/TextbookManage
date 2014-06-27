﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18449
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextbookManage.WebUI.BooksellerService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BooksellerView", Namespace="http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute()]
    public partial class BooksellerView : TextbookManage.WebUI.BooksellerService.BaseViewModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BooksellerIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BooksellerId {
            get {
                return this.BooksellerIdField;
            }
            set {
                if ((object.ReferenceEquals(this.BooksellerIdField, value) != true)) {
                    this.BooksellerIdField = value;
                    this.RaisePropertyChanged("BooksellerId");
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
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.BooksellerService.BooksellerView))]
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BooksellerService.IBooksellerAppl")]
    public interface IBooksellerAppl {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBooksellerAppl/GetBooksellers", ReplyAction="http://tempuri.org/IBooksellerAppl/GetBooksellersResponse")]
        TextbookManage.WebUI.BooksellerService.BooksellerView[] GetBooksellers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBooksellerAppl/GetBooksellers", ReplyAction="http://tempuri.org/IBooksellerAppl/GetBooksellersResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.BooksellerService.BooksellerView[]> GetBooksellersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBooksellerApplChannel : TextbookManage.WebUI.BooksellerService.IBooksellerAppl, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BooksellerApplClient : System.ServiceModel.ClientBase<TextbookManage.WebUI.BooksellerService.IBooksellerAppl>, TextbookManage.WebUI.BooksellerService.IBooksellerAppl {
        
        public BooksellerApplClient() {
        }
        
        public BooksellerApplClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BooksellerApplClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BooksellerApplClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BooksellerApplClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TextbookManage.WebUI.BooksellerService.BooksellerView[] GetBooksellers() {
            return base.Channel.GetBooksellers();
        }
        
        public System.Threading.Tasks.Task<TextbookManage.WebUI.BooksellerService.BooksellerView[]> GetBooksellersAsync() {
            return base.Channel.GetBooksellersAsync();
        }
    }
}
