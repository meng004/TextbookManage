using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class BooksellerMap : EntityTypeConfiguration<Bookseller>
    {
        public BooksellerMap()
        {
            // Primary Key
            this.HasKey(t => t.BooksellerId);

            this.Property(t => t.BooksellerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Contact)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Telephone)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Bookseller", "Textbook");
            this.Property(t => t.BooksellerId).HasColumnName("BookSellerID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.Telephone).HasColumnName("Telephone");

        }
    }
}
