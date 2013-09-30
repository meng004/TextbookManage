using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class TextbookMap : EntityTypeConfiguration<Textbook>
    {
        public TextbookMap()
        {
            // Primary Key
            this.HasKey(t => t.TextbookID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Isbn)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Author)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Press)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.PressAddress)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.TextbookType)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Textbook", "Textbook");
            this.Property(t => t.TextbookID).HasColumnName("TextbookID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Isbn).HasColumnName("Isbn");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.Press).HasColumnName("Press");
            this.Property(t => t.PressAddress).HasColumnName("PressAddress");
            this.Property(t => t.Edition).HasColumnName("Edition");
            this.Property(t => t.PrintCount).HasColumnName("PrintCount");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.TextbookType).HasColumnName("TextbookType");
            this.Property(t => t.IsSelfCompile).HasColumnName("IsSelfCompile");
            this.Property(t => t.PageCount).HasColumnName("PageCount");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.DiscountPrice).HasColumnName("DiscountPrice");
            this.Property(t => t.ApprovalState).HasColumnName("ApprovalState");
            this.Property(t => t.TeacherId).HasColumnName("Teacher_ID");
            this.Property(t => t.DeclarationDate).HasColumnName("DeclarationDate");
        }
    }
}
