using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping.JiaoWu
{
    public class TextbookMap : EntityTypeConfiguration<Textbook>
    {
        public TextbookMap()
        {
            // Primary Key
            this.HasKey(t => t.TextbookId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Isbn)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Author)
                .IsRequired()
                .HasMaxLength(50);

            Ignore(t => t.PublishDate);
            Ignore(t => t.ID);
            

            

            this.Property(t => t.Edition)
                .HasMaxLength(30);

            this.Property(t => t.PrintCount)
                .HasMaxLength(30);

            this.Property(t => t.Press)
                .HasMaxLength(200);

            this.Property(t => t.TextbookType)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Textbook", "dbo");
            this.Property(t => t.TextbookId).HasColumnName("TextbookID");
            this.Property(t => t.Name).HasColumnName("TextbookName");
            this.Property(t => t.Isbn).HasColumnName("ISBN");
            this.Property(t => t.Author).HasColumnName("Author");
            //this.Property(t => t.PublishDate).HasColumnName("CBSJ");
            this.Property(t => t.Price).HasColumnName("RetailPrice");                       
            this.Property(t => t.Edition).HasColumnName("Edition");
            this.Property(t => t.PrintCount).HasColumnName("PrintingCount");
            this.Property(t => t.Press).HasColumnName("Press");             
            this.Property(t => t.TextbookType).HasColumnName("TextbookType");
            this.Property(t => t.IsSelfCompile).HasColumnName("IsSelfCompile");

        }
    }
}
