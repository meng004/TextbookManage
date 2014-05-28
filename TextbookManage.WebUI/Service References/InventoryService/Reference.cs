﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18046
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextbookManage.WebUI.InventoryService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StorageView", Namespace="http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute()]
    public partial class StorageView : TextbookManage.WebUI.InventoryService.BaseViewModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BooksellerIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BooksellerNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StorageIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
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
        public string BooksellerName {
            get {
                return this.BooksellerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.BooksellerNameField, value) != true)) {
                    this.BooksellerNameField = value;
                    this.RaisePropertyChanged("BooksellerName");
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
        public string StorageId {
            get {
                return this.StorageIdField;
            }
            set {
                if ((object.ReferenceEquals(this.StorageIdField, value) != true)) {
                    this.StorageIdField = value;
                    this.RaisePropertyChanged("StorageId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseViewModel", Namespace="http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.InventoryService.TextbookView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.InventoryService.InventoryView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.InventoryService.StockRecordView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.InventoryService.ResponseView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.InventoryService.StorageView))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TextbookView", Namespace="http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.InventoryService.InventoryView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.InventoryService.StockRecordView))]
    public partial class TextbookView : TextbookManage.WebUI.InventoryService.BaseViewModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EditionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IsSelfCompileField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IsbnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PageCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PressAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PrintCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime PublishDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextbookIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextbookTypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Author {
            get {
                return this.AuthorField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthorField, value) != true)) {
                    this.AuthorField = value;
                    this.RaisePropertyChanged("Author");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Edition {
            get {
                return this.EditionField;
            }
            set {
                if ((object.ReferenceEquals(this.EditionField, value) != true)) {
                    this.EditionField = value;
                    this.RaisePropertyChanged("Edition");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IsSelfCompile {
            get {
                return this.IsSelfCompileField;
            }
            set {
                if ((object.ReferenceEquals(this.IsSelfCompileField, value) != true)) {
                    this.IsSelfCompileField = value;
                    this.RaisePropertyChanged("IsSelfCompile");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Isbn {
            get {
                return this.IsbnField;
            }
            set {
                if ((object.ReferenceEquals(this.IsbnField, value) != true)) {
                    this.IsbnField = value;
                    this.RaisePropertyChanged("Isbn");
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
        public string Num {
            get {
                return this.NumField;
            }
            set {
                if ((object.ReferenceEquals(this.NumField, value) != true)) {
                    this.NumField = value;
                    this.RaisePropertyChanged("Num");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PageCount {
            get {
                return this.PageCountField;
            }
            set {
                if ((object.ReferenceEquals(this.PageCountField, value) != true)) {
                    this.PageCountField = value;
                    this.RaisePropertyChanged("PageCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Press {
            get {
                return this.PressField;
            }
            set {
                if ((object.ReferenceEquals(this.PressField, value) != true)) {
                    this.PressField = value;
                    this.RaisePropertyChanged("Press");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PressAddress {
            get {
                return this.PressAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.PressAddressField, value) != true)) {
                    this.PressAddressField = value;
                    this.RaisePropertyChanged("PressAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PrintCount {
            get {
                return this.PrintCountField;
            }
            set {
                if ((object.ReferenceEquals(this.PrintCountField, value) != true)) {
                    this.PrintCountField = value;
                    this.RaisePropertyChanged("PrintCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime PublishDate {
            get {
                return this.PublishDateField;
            }
            set {
                if ((this.PublishDateField.Equals(value) != true)) {
                    this.PublishDateField = value;
                    this.RaisePropertyChanged("PublishDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TextbookId {
            get {
                return this.TextbookIdField;
            }
            set {
                if ((object.ReferenceEquals(this.TextbookIdField, value) != true)) {
                    this.TextbookIdField = value;
                    this.RaisePropertyChanged("TextbookId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TextbookType {
            get {
                return this.TextbookTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TextbookTypeField, value) != true)) {
                    this.TextbookTypeField = value;
                    this.RaisePropertyChanged("TextbookType");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InventoryView", Namespace="http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute()]
    public partial class InventoryView : TextbookManage.WebUI.InventoryService.TextbookView {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int InventoryCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InventoryIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ShelfNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StorageIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int InventoryCount {
            get {
                return this.InventoryCountField;
            }
            set {
                if ((this.InventoryCountField.Equals(value) != true)) {
                    this.InventoryCountField = value;
                    this.RaisePropertyChanged("InventoryCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string InventoryId {
            get {
                return this.InventoryIdField;
            }
            set {
                if ((object.ReferenceEquals(this.InventoryIdField, value) != true)) {
                    this.InventoryIdField = value;
                    this.RaisePropertyChanged("InventoryId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ShelfNumber {
            get {
                return this.ShelfNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.ShelfNumberField, value) != true)) {
                    this.ShelfNumberField = value;
                    this.RaisePropertyChanged("ShelfNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StorageId {
            get {
                return this.StorageIdField;
            }
            set {
                if ((object.ReferenceEquals(this.StorageIdField, value) != true)) {
                    this.StorageIdField = value;
                    this.RaisePropertyChanged("StorageId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StockRecordView", Namespace="http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute()]
    public partial class StockRecordView : TextbookManage.WebUI.InventoryService.TextbookView {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OperatorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ShelfNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StockCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StockDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StockRecordIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Operator {
            get {
                return this.OperatorField;
            }
            set {
                if ((object.ReferenceEquals(this.OperatorField, value) != true)) {
                    this.OperatorField = value;
                    this.RaisePropertyChanged("Operator");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ShelfNumber {
            get {
                return this.ShelfNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.ShelfNumberField, value) != true)) {
                    this.ShelfNumberField = value;
                    this.RaisePropertyChanged("ShelfNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StockCount {
            get {
                return this.StockCountField;
            }
            set {
                if ((object.ReferenceEquals(this.StockCountField, value) != true)) {
                    this.StockCountField = value;
                    this.RaisePropertyChanged("StockCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StockDate {
            get {
                return this.StockDateField;
            }
            set {
                if ((object.ReferenceEquals(this.StockDateField, value) != true)) {
                    this.StockDateField = value;
                    this.RaisePropertyChanged("StockDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StockRecordId {
            get {
                return this.StockRecordIdField;
            }
            set {
                if ((object.ReferenceEquals(this.StockRecordIdField, value) != true)) {
                    this.StockRecordIdField = value;
                    this.RaisePropertyChanged("StockRecordId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseView", Namespace="http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute()]
    public partial class ResponseView : TextbookManage.WebUI.InventoryService.BaseViewModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSuccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSuccess {
            get {
                return this.IsSuccessField;
            }
            set {
                if ((this.IsSuccessField.Equals(value) != true)) {
                    this.IsSuccessField = value;
                    this.RaisePropertyChanged("IsSuccess");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="InventoryService.IInventoryAppl")]
    public interface IInventoryAppl {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryAppl/GetStorages", ReplyAction="http://tempuri.org/IInventoryAppl/GetStoragesResponse")]
        TextbookManage.WebUI.InventoryService.StorageView[] GetStorages(string loginName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryAppl/GetStorages", ReplyAction="http://tempuri.org/IInventoryAppl/GetStoragesResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.InventoryService.StorageView[]> GetStoragesAsync(string loginName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryAppl/GetTextbooksByName", ReplyAction="http://tempuri.org/IInventoryAppl/GetTextbooksByNameResponse")]
        TextbookManage.WebUI.InventoryService.TextbookView[] GetTextbooksByName(string name, string isbn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryAppl/GetTextbooksByName", ReplyAction="http://tempuri.org/IInventoryAppl/GetTextbooksByNameResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.InventoryService.TextbookView[]> GetTextbooksByNameAsync(string name, string isbn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryAppl/GetInventory", ReplyAction="http://tempuri.org/IInventoryAppl/GetInventoryResponse")]
        TextbookManage.WebUI.InventoryService.InventoryView GetInventory(string storageId, string textbookId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryAppl/GetInventory", ReplyAction="http://tempuri.org/IInventoryAppl/GetInventoryResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.InventoryService.InventoryView> GetInventoryAsync(string storageId, string textbookId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryAppl/SubmitInStock", ReplyAction="http://tempuri.org/IInventoryAppl/SubmitInStockResponse")]
        TextbookManage.WebUI.InventoryService.ResponseView SubmitInStock(TextbookManage.WebUI.InventoryService.InventoryView inventory, string instockCount, string loginName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryAppl/SubmitInStock", ReplyAction="http://tempuri.org/IInventoryAppl/SubmitInStockResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.InventoryService.ResponseView> SubmitInStockAsync(TextbookManage.WebUI.InventoryService.InventoryView inventory, string instockCount, string loginName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryAppl/GetStockRecordsByDate", ReplyAction="http://tempuri.org/IInventoryAppl/GetStockRecordsByDateResponse")]
        TextbookManage.WebUI.InventoryService.StockRecordView[] GetStockRecordsByDate(string storageId, string stockType, string beginDate, string endDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryAppl/GetStockRecordsByDate", ReplyAction="http://tempuri.org/IInventoryAppl/GetStockRecordsByDateResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.InventoryService.StockRecordView[]> GetStockRecordsByDateAsync(string storageId, string stockType, string beginDate, string endDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryAppl/GetStockRecordsByTextbook", ReplyAction="http://tempuri.org/IInventoryAppl/GetStockRecordsByTextbookResponse")]
        TextbookManage.WebUI.InventoryService.StockRecordView[] GetStockRecordsByTextbook(string storageId, string stockType, string textbookName, string isbn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryAppl/GetStockRecordsByTextbook", ReplyAction="http://tempuri.org/IInventoryAppl/GetStockRecordsByTextbookResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.InventoryService.StockRecordView[]> GetStockRecordsByTextbookAsync(string storageId, string stockType, string textbookName, string isbn);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IInventoryApplChannel : TextbookManage.WebUI.InventoryService.IInventoryAppl, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InventoryApplClient : System.ServiceModel.ClientBase<TextbookManage.WebUI.InventoryService.IInventoryAppl>, TextbookManage.WebUI.InventoryService.IInventoryAppl {
        
        public InventoryApplClient() {
        }
        
        public InventoryApplClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public InventoryApplClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InventoryApplClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InventoryApplClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TextbookManage.WebUI.InventoryService.StorageView[] GetStorages(string loginName) {
            return base.Channel.GetStorages(loginName);
        }
        
        public System.Threading.Tasks.Task<TextbookManage.WebUI.InventoryService.StorageView[]> GetStoragesAsync(string loginName) {
            return base.Channel.GetStoragesAsync(loginName);
        }
        
        public TextbookManage.WebUI.InventoryService.TextbookView[] GetTextbooksByName(string name, string isbn) {
            return base.Channel.GetTextbooksByName(name, isbn);
        }
        
        public System.Threading.Tasks.Task<TextbookManage.WebUI.InventoryService.TextbookView[]> GetTextbooksByNameAsync(string name, string isbn) {
            return base.Channel.GetTextbooksByNameAsync(name, isbn);
        }
        
        public TextbookManage.WebUI.InventoryService.InventoryView GetInventory(string storageId, string textbookId) {
            return base.Channel.GetInventory(storageId, textbookId);
        }
        
        public System.Threading.Tasks.Task<TextbookManage.WebUI.InventoryService.InventoryView> GetInventoryAsync(string storageId, string textbookId) {
            return base.Channel.GetInventoryAsync(storageId, textbookId);
        }
        
        public TextbookManage.WebUI.InventoryService.ResponseView SubmitInStock(TextbookManage.WebUI.InventoryService.InventoryView inventory, string instockCount, string loginName) {
            return base.Channel.SubmitInStock(inventory, instockCount, loginName);
        }
        
        public System.Threading.Tasks.Task<TextbookManage.WebUI.InventoryService.ResponseView> SubmitInStockAsync(TextbookManage.WebUI.InventoryService.InventoryView inventory, string instockCount, string loginName) {
            return base.Channel.SubmitInStockAsync(inventory, instockCount, loginName);
        }
        
        public TextbookManage.WebUI.InventoryService.StockRecordView[] GetStockRecordsByDate(string storageId, string stockType, string beginDate, string endDate) {
            return base.Channel.GetStockRecordsByDate(storageId, stockType, beginDate, endDate);
        }
        
        public System.Threading.Tasks.Task<TextbookManage.WebUI.InventoryService.StockRecordView[]> GetStockRecordsByDateAsync(string storageId, string stockType, string beginDate, string endDate) {
            return base.Channel.GetStockRecordsByDateAsync(storageId, stockType, beginDate, endDate);
        }
        
        public TextbookManage.WebUI.InventoryService.StockRecordView[] GetStockRecordsByTextbook(string storageId, string stockType, string textbookName, string isbn) {
            return base.Channel.GetStockRecordsByTextbook(storageId, stockType, textbookName, isbn);
        }
        
        public System.Threading.Tasks.Task<TextbookManage.WebUI.InventoryService.StockRecordView[]> GetStockRecordsByTextbookAsync(string storageId, string stockType, string textbookName, string isbn) {
            return base.Channel.GetStockRecordsByTextbookAsync(storageId, stockType, textbookName, isbn);
        }
    }
}