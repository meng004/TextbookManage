using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class BooksellerStaffMap : EntityTypeConfiguration<BooksellerStaff>
    {
        public BooksellerStaffMap()
        {
            // Primary Key
            this.HasKey(t => t.BooksellerStaffId);

            // Properties
            this.Property(t => t.BooksellerStaffId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.StaffName)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("BooksellerStaff", "Textbook");
            this.Property(t => t.Bookseller_Id).HasColumnName("BookSeller_ID");            
            this.Property(t => t.StaffName).HasColumnName("StaffName");
            this.Property(t => t.Gender).HasColumnName("Gender");
            
            //书商员工与书商，多对1关系
            this.HasRequired(t => t.Bookseller)
                .WithMany(t => t.BooksellerStaffs)
                .HasForeignKey(d => d.Bookseller_Id);
        }
    }
}
