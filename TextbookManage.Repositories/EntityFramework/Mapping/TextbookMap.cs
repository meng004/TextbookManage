using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class TextbookMap : EntityTypeConfiguration<Textbook>
    {
        public TextbookMap()
        {
            // Primary Key
            this.HasKey(t => t.TextbookId);

            // Properties
            this.Property(t => t.Num)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Isbn)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Author)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.PressId)
                .IsRequired();

            this.Property(t => t.TextbookType)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Textbook", "Textbook");
            this.Property(t => t.TextbookId).HasColumnName("TextbookID");
            this.Property(t => t.Num).HasColumnName("Num");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Isbn).HasColumnName("Isbn");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.PressId).HasColumnName("Press_ID");            
            this.Property(t => t.Edition).HasColumnName("Edition");
            this.Property(t => t.PrintCount).HasColumnName("PrintCount");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.TextbookType).HasColumnName("TextbookType");
            this.Property(t => t.IsSelfCompile).HasColumnName("IsSelfCompile");
            this.Property(t => t.PageCount).HasColumnName("PageCount");
            //this.Property(t => t.Discount).HasColumnName("Discount");
            //this.Property(t => t.DiscountPrice).HasColumnName("DiscountPrice");
            this.Property(t => t.ApprovalState).HasColumnName("ApprovalState");
            this.Property(t => t.TeacherId).HasColumnName("Teacher_ID");
            this.Property(t => t.DeclarationDate).HasColumnName("DeclarationDate");

            //教师
            this.HasOptional(t => t.Declarant)
                .WithMany(t => t.Textbooks)
                .HasForeignKey(t => t.TeacherId);

            //出版社
            this.HasRequired(t => t.Press)
                .WithMany(p => p.Textbooks)
                .HasForeignKey(f => f.PressId);
                
        }
    }
}
