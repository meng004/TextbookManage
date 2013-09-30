//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextbookManage.Design
{
    using System;
    using System.Collections.Generic;
    
    public partial class Textbook
    {
        public Textbook()
        {
            this.Declaration = new HashSet<Declaration>();
            this.Inventory = new HashSet<Inventory>();
            this.Subscription = new HashSet<Subscription>();
        }
    
        public int ID { get; set; }
    
        public virtual ICollection<Declaration> Declaration { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Subscription> Subscription { get; set; }
    }
}
