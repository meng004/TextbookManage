using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class InventoryMap : EntityTypeConfiguration<Inventory>
    {
        public InventoryMap()
        {
            // Primary Key
            this.HasKey(t => t.InventoryID);

            // Properties
            this.Property(t => t.ShelfNumber)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Inventory", "Textbook");
            this.Property(t => t.InventoryID).HasColumnName("InventoryID");
            this.Property(t => t.Storage_ID).HasColumnName("Storage_ID");
            this.Property(t => t.Textbook_ID).HasColumnName("Textbook_ID");
            this.Property(t => t.ShelfNumber).HasColumnName("ShelfNumber");
            this.Property(t => t.InventoryCount).HasColumnName("InventoryCount");

            // Relationships
            this.HasRequired(t => t.Storage)
                .WithMany(t => t.Inventories)
                .HasForeignKey(d => d.Storage_ID);
            this.HasRequired(t => t.Textbook)
                .WithMany(t => t.Inventories)
                .HasForeignKey(d => d.Textbook_ID);

        }
    }
}
