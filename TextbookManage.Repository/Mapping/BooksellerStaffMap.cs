using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class BooksellerStaffMap : EntityTypeConfiguration<BooksellerStaff>
    {
        public BooksellerStaffMap()
        {
            // Primary Key
            this.HasKey(t => t.BooksellerStaffID);

            // Properties
            this.Property(t => t.StaffName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Sex)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("BooksellerStaff", "Textbook");
            this.Property(t => t.BooksellerStaffID).HasColumnName("BooksellerStaffID");
            this.Property(t => t.Bookseller_ID).HasColumnName("Bookseller_ID");
            this.Property(t => t.StaffName).HasColumnName("StaffName");
            this.Property(t => t.Sex).HasColumnName("Sex");

            // Relationships
            this.HasRequired(t => t.Bookseller)
                .WithMany(t => t.BooksellerStaffs)
                .HasForeignKey(d => d.Bookseller_ID);

        }
    }
}
