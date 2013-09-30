using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class StockRecordMap : EntityTypeConfiguration<StockRecord>
    {
        public StockRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.StockRecordID);

            // Properties
            this.Property(t => t.Operator)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("StockRecord", "Textbook");
            this.Property(t => t.StockRecordID).HasColumnName("StockRecordID");
            this.Property(t => t.Inventory_ID).HasColumnName("Inventory_ID");
            this.Property(t => t.StockCount).HasColumnName("StockCount");
            this.Property(t => t.StockDate).HasColumnName("StockDate");
            this.Property(t => t.Operator).HasColumnName("Operator");
            //this.Property(t => t.StockType).HasColumnName("StockType");

            this.Ignore(t => t.StockType);
            //”≥…‰◊”¿‡
            this.Map<InStockRecord>(m => m.Requires("StockType").HasValue(true));
            this.Map<OutStockRecord>(m => m.Requires("StockType").HasValue(false));


            // Relationships
            this.HasRequired(t => t.Inventory)
                .WithMany(t => t.StockRecords)
                .HasForeignKey(d => d.Inventory_ID);

        }
    }
}
