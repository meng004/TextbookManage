﻿namespace TextbookManage.WebUI.ReleaseClassBookService
{
    using System.Runtime.Serialization;
    using System;

    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "SchoolView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class SchoolView : TextbookManage.WebUI.ReleaseClassBookService.BaseViewModel
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
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.ProfessionalClassBaseView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.StorageView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.ResponseView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.TextbookView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.InventoryView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.InventoryForReleaseClassView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.StudentView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.ReleaseBookView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.ReleaseBookForClassView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.SchoolView))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "ProfessionalClassBaseView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class ProfessionalClassBaseView : TextbookManage.WebUI.ReleaseClassBookService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string ProfessionalClassIdField;
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
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "StorageView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class StorageView : TextbookManage.WebUI.ReleaseClassBookService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string AddressField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string BooksellerIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string BooksellerNameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string StorageIdField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Address
        {
            get
            {
                return this.AddressField;
            }
            set
            {
                if ((object.ReferenceEquals(this.AddressField, value) != true))
                {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
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
        public string StorageId
        {
            get
            {
                return this.StorageIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.StorageIdField, value) != true))
                {
                    this.StorageIdField = value;
                    this.RaisePropertyChanged("StorageId");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ResponseView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class ResponseView : TextbookManage.WebUI.ReleaseClassBookService.BaseViewModel
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "TextbookView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.InventoryView))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.InventoryForReleaseClassView))]
    public partial class TextbookView : TextbookManage.WebUI.ReleaseClassBookService.BaseViewModel
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
    [System.Runtime.Serialization.DataContractAttribute(Name = "InventoryView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.InventoryForReleaseClassView))]
    public partial class InventoryView : TextbookManage.WebUI.ReleaseClassBookService.TextbookView
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private int InventoryCountField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string InventoryIdField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string ShelfNumberField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string StorageIdField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public int InventoryCount
        {
            get
            {
                return this.InventoryCountField;
            }
            set
            {
                if ((this.InventoryCountField.Equals(value) != true))
                {
                    this.InventoryCountField = value;
                    this.RaisePropertyChanged("InventoryCount");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string InventoryId
        {
            get
            {
                return this.InventoryIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.InventoryIdField, value) != true))
                {
                    this.InventoryIdField = value;
                    this.RaisePropertyChanged("InventoryId");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string ShelfNumber
        {
            get
            {
                return this.ShelfNumberField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ShelfNumberField, value) != true))
                {
                    this.ShelfNumberField = value;
                    this.RaisePropertyChanged("ShelfNumber");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string StorageId
        {
            get
            {
                return this.StorageIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.StorageIdField, value) != true))
                {
                    this.StorageIdField = value;
                    this.RaisePropertyChanged("StorageId");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "InventoryForReleaseClassView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class InventoryForReleaseClassView : TextbookManage.WebUI.ReleaseClassBookService.InventoryView
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private int AverageCountField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private int DeclarationCountField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private decimal DiscountField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private decimal DiscountPriceField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private int ReleaseCountField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private TextbookManage.WebUI.ReleaseClassBookService.StudentView[] StudentsField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public int AverageCount
        {
            get
            {
                return this.AverageCountField;
            }
            set
            {
                if ((this.AverageCountField.Equals(value) != true))
                {
                    this.AverageCountField = value;
                    this.RaisePropertyChanged("AverageCount");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public int DeclarationCount
        {
            get
            {
                return this.DeclarationCountField;
            }
            set
            {
                if ((this.DeclarationCountField.Equals(value) != true))
                {
                    this.DeclarationCountField = value;
                    this.RaisePropertyChanged("DeclarationCount");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public decimal Discount
        {
            get
            {
                return this.DiscountField;
            }
            set
            {
                if ((this.DiscountField.Equals(value) != true))
                {
                    this.DiscountField = value;
                    this.RaisePropertyChanged("Discount");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public decimal DiscountPrice
        {
            get
            {
                return this.DiscountPriceField;
            }
            set
            {
                if ((this.DiscountPriceField.Equals(value) != true))
                {
                    this.DiscountPriceField = value;
                    this.RaisePropertyChanged("DiscountPrice");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public int ReleaseCount
        {
            get
            {
                return this.ReleaseCountField;
            }
            set
            {
                if ((this.ReleaseCountField.Equals(value) != true))
                {
                    this.ReleaseCountField = value;
                    this.RaisePropertyChanged("ReleaseCount");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public TextbookManage.WebUI.ReleaseClassBookService.StudentView[] Students
        {
            get
            {
                return this.StudentsField;
            }
            set
            {
                if ((object.ReferenceEquals(this.StudentsField, value) != true))
                {
                    this.StudentsField = value;
                    this.RaisePropertyChanged("Students");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "StudentView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class StudentView : TextbookManage.WebUI.ReleaseClassBookService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string GenderField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string NumField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string StudentIdField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Gender
        {
            get
            {
                return this.GenderField;
            }
            set
            {
                if ((object.ReferenceEquals(this.GenderField, value) != true))
                {
                    this.GenderField = value;
                    this.RaisePropertyChanged("Gender");
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
        public string StudentId
        {
            get
            {
                return this.StudentIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.StudentIdField, value) != true))
                {
                    this.StudentIdField = value;
                    this.RaisePropertyChanged("StudentId");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ReleaseBookView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TextbookManage.WebUI.ReleaseClassBookService.ReleaseBookForClassView))]
    public partial class ReleaseBookView : TextbookManage.WebUI.ReleaseClassBookService.BaseViewModel
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string OperatorField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string RecipientNameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string RecipientTelephoneField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Operator
        {
            get
            {
                return this.OperatorField;
            }
            set
            {
                if ((object.ReferenceEquals(this.OperatorField, value) != true))
                {
                    this.OperatorField = value;
                    this.RaisePropertyChanged("Operator");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string RecipientName
        {
            get
            {
                return this.RecipientNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.RecipientNameField, value) != true))
                {
                    this.RecipientNameField = value;
                    this.RaisePropertyChanged("RecipientName");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string RecipientTelephone
        {
            get
            {
                return this.RecipientTelephoneField;
            }
            set
            {
                if ((object.ReferenceEquals(this.RecipientTelephoneField, value) != true))
                {
                    this.RecipientTelephoneField = value;
                    this.RaisePropertyChanged("RecipientTelephone");
                }
            }
        }
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ReleaseBookForClassView", Namespace = "http://schemas.datacontract.org/2004/07/TextbookManage.ViewModels")]
    [System.SerializableAttribute]
    public partial class ReleaseBookForClassView : TextbookManage.WebUI.ReleaseClassBookService.ReleaseBookView
    {
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string Recipient2NameField;
        [System.Runtime.Serialization.OptionalFieldAttribute]
        private string Recipient2TelephoneField;
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Recipient2Name
        {
            get
            {
                return this.Recipient2NameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.Recipient2NameField, value) != true))
                {
                    this.Recipient2NameField = value;
                    this.RaisePropertyChanged("Recipient2Name");
                }
            }
        }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Recipient2Telephone
        {
            get
            {
                return this.Recipient2TelephoneField;
            }
            set
            {
                if ((object.ReferenceEquals(this.Recipient2TelephoneField, value) != true))
                {
                    this.Recipient2TelephoneField = value;
                    this.RaisePropertyChanged("Recipient2Telephone");
                }
            }
        }
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "ReleaseClassBookService.IReleaseClassBookAppl")]
    public interface IReleaseClassBookAppl
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetSchoolByLoginName", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetSchoolByLoginNameResponse")]
        TextbookManage.WebUI.ReleaseClassBookService.SchoolView[] GetSchoolByLoginName(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetSchoolByLoginName", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetSchoolByLoginNameResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.SchoolView[]> GetSchoolByLoginNameAsync(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetGradeBySchoolId", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetGradeBySchoolIdResponse")]
        string[] GetGradeBySchoolId(string schoolId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetGradeBySchoolId", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetGradeBySchoolIdResponse")]
        System.Threading.Tasks.Task<string[]> GetGradeBySchoolIdAsync(string schoolId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetClassBySchoolId", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetClassBySchoolIdResponse")]
        TextbookManage.WebUI.ReleaseClassBookService.ProfessionalClassBaseView[] GetClassBySchoolId(string schoolId, string grade);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetClassBySchoolId", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetClassBySchoolIdResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.ProfessionalClassBaseView[]> GetClassBySchoolIdAsync(string schoolId, string grade);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetStorages", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetStoragesResponse")]
        TextbookManage.WebUI.ReleaseClassBookService.StorageView[] GetStorages(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetStorages", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetStoragesResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.StorageView[]> GetStoragesAsync(string loginName);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetStudentNameByStudentNum", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetStudentNameByStudentNumResponse")]
        TextbookManage.WebUI.ReleaseClassBookService.ResponseView GetStudentNameByStudentNum(string studentNum);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetStudentNameByStudentNum", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetStudentNameByStudentNumResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.ResponseView> GetStudentNameByStudentNumAsync(string studentNum);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetInventoriesByClassId", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetInventoriesByClassIdResponse")]
        TextbookManage.WebUI.ReleaseClassBookService.InventoryForReleaseClassView[] GetInventoriesByClassId(string classId, string storageId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetInventoriesByClassId", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetInventoriesByClassIdResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.InventoryForReleaseClassView[]> GetInventoriesByClassIdAsync(string classId, string storageId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetNotReleaseStudents", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetNotReleaseStudentsResponse")]
        TextbookManage.WebUI.ReleaseClassBookService.StudentView[] GetNotReleaseStudents(string classId, string textbookId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/GetNotReleaseStudents", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/GetNotReleaseStudentsResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.StudentView[]> GetNotReleaseStudentsAsync(string classId, string textbookId);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/SubmitReleaseClass", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/SubmitReleaseClassResponse")]
        TextbookManage.WebUI.ReleaseClassBookService.ResponseView SubmitReleaseClass(TextbookManage.WebUI.ReleaseClassBookService.InventoryForReleaseClassView[] inventoryViews, TextbookManage.WebUI.ReleaseClassBookService.ReleaseBookForClassView releaseView);
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReleaseClassBookAppl/SubmitReleaseClass", ReplyAction = "http://tempuri.org/IReleaseClassBookAppl/SubmitReleaseClassResponse")]
        System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.ResponseView> SubmitReleaseClassAsync(TextbookManage.WebUI.ReleaseClassBookService.InventoryForReleaseClassView[] inventoryViews, TextbookManage.WebUI.ReleaseClassBookService.ReleaseBookForClassView releaseView);
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReleaseClassBookApplChannel : TextbookManage.WebUI.ReleaseClassBookService.IReleaseClassBookAppl, System.ServiceModel.IClientChannel
    {
    }
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReleaseClassBookApplClient : System.ServiceModel.ClientBase<TextbookManage.WebUI.ReleaseClassBookService.IReleaseClassBookAppl>, TextbookManage.WebUI.ReleaseClassBookService.IReleaseClassBookAppl
    {
        public ReleaseClassBookApplClient()
        {
        }
        public ReleaseClassBookApplClient(string endpointConfigurationName)
            :
            base(endpointConfigurationName)
        {
        }
        public ReleaseClassBookApplClient(string endpointConfigurationName, string remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public ReleaseClassBookApplClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public ReleaseClassBookApplClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
            base(binding, remoteAddress)
        {
        }
        public TextbookManage.WebUI.ReleaseClassBookService.SchoolView[] GetSchoolByLoginName(string loginName)
        {
            return base.Channel.GetSchoolByLoginName(loginName);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.SchoolView[]> GetSchoolByLoginNameAsync(string loginName)
        {
            return base.Channel.GetSchoolByLoginNameAsync(loginName);
        }
        public string[] GetGradeBySchoolId(string schoolId)
        {
            return base.Channel.GetGradeBySchoolId(schoolId);
        }
        public System.Threading.Tasks.Task<string[]> GetGradeBySchoolIdAsync(string schoolId)
        {
            return base.Channel.GetGradeBySchoolIdAsync(schoolId);
        }
        public TextbookManage.WebUI.ReleaseClassBookService.ProfessionalClassBaseView[] GetClassBySchoolId(string schoolId, string grade)
        {
            return base.Channel.GetClassBySchoolId(schoolId, grade);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.ProfessionalClassBaseView[]> GetClassBySchoolIdAsync(string schoolId, string grade)
        {
            return base.Channel.GetClassBySchoolIdAsync(schoolId, grade);
        }
        public TextbookManage.WebUI.ReleaseClassBookService.StorageView[] GetStorages(string loginName)
        {
            return base.Channel.GetStorages(loginName);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.StorageView[]> GetStoragesAsync(string loginName)
        {
            return base.Channel.GetStoragesAsync(loginName);
        }
        public TextbookManage.WebUI.ReleaseClassBookService.ResponseView GetStudentNameByStudentNum(string studentNum)
        {
            return base.Channel.GetStudentNameByStudentNum(studentNum);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.ResponseView> GetStudentNameByStudentNumAsync(string studentNum)
        {
            return base.Channel.GetStudentNameByStudentNumAsync(studentNum);
        }
        public TextbookManage.WebUI.ReleaseClassBookService.InventoryForReleaseClassView[] GetInventoriesByClassId(string classId, string storageId)
        {
            return base.Channel.GetInventoriesByClassId(classId, storageId);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.InventoryForReleaseClassView[]> GetInventoriesByClassIdAsync(string classId, string storageId)
        {
            return base.Channel.GetInventoriesByClassIdAsync(classId, storageId);
        }
        public TextbookManage.WebUI.ReleaseClassBookService.StudentView[] GetNotReleaseStudents(string classId, string textbookId)
        {
            return base.Channel.GetNotReleaseStudents(classId, textbookId);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.StudentView[]> GetNotReleaseStudentsAsync(string classId, string textbookId)
        {
            return base.Channel.GetNotReleaseStudentsAsync(classId, textbookId);
        }
        public TextbookManage.WebUI.ReleaseClassBookService.ResponseView SubmitReleaseClass(TextbookManage.WebUI.ReleaseClassBookService.InventoryForReleaseClassView[] inventoryViews, TextbookManage.WebUI.ReleaseClassBookService.ReleaseBookForClassView releaseView)
        {
            return base.Channel.SubmitReleaseClass(inventoryViews, releaseView);
        }
        public System.Threading.Tasks.Task<TextbookManage.WebUI.ReleaseClassBookService.ResponseView> SubmitReleaseClassAsync(TextbookManage.WebUI.ReleaseClassBookService.InventoryForReleaseClassView[] inventoryViews, TextbookManage.WebUI.ReleaseClassBookService.ReleaseBookForClassView releaseView)
        {
            return base.Channel.SubmitReleaseClassAsync(inventoryViews, releaseView);
        }
    }
}
