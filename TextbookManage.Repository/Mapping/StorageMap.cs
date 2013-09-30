using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class StorageMap : EntityTypeConfiguration<Storage>
    {
        public StorageMap()
        {
            // Primary Key
            this.HasKey(t => t.StorageID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Address)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Storage", "Textbook");
            this.Property(t => t.StorageID).HasColumnName("StorageID");
            this.Property(t => t.Bookseller_ID).HasColumnName("Bookseller_ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Address).HasColumnName("Address");

            // Relationships
            this.HasRequired(t => t.Bookseller)
                .WithMany(t => t.Storages)
                .HasForeignKey(d => d.Bookseller_ID);

        }
    }
}
