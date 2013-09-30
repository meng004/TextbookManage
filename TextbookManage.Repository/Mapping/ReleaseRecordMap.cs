using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class ReleaseRecordMap : EntityTypeConfiguration<ReleaseRecord>
    {
        public ReleaseRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.ReleaseRecordID);

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

            this.Property(t => t.SchoolName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Term)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Telephone)
                .HasMaxLength(20);

            this.Property(t => t.BooksellerName)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("ReleaseRecord", "Textbook");
            this.Property(t => t.ReleaseRecordID).HasColumnName("ReleaseRecordID");
            this.Property(t => t.StockRecord_ID).HasColumnName("StockRecord_ID");
            this.Property(t => t.TextbookID).HasColumnName("Textbook_ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Isbn).HasColumnName("Isbn");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.Press).HasColumnName("Press");
            this.Property(t => t.PressAddress).HasColumnName("PressAddress");
            this.Property(t => t.Edition).HasColumnName("Edition");
            this.Property(t => t.PrintCount).HasColumnName("PrintCount");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.DiscountPrice).HasColumnName("DiscountPrice");
            this.Property(t => t.TextbookType).HasColumnName("TextbookType");
            this.Property(t => t.IsSelfCompile).HasColumnName("IsSelfCompile");
            this.Property(t => t.PageCount).HasColumnName("PageCount");
            this.Property(t => t.School_ID).HasColumnName("School_ID");
            this.Property(t => t.SchoolName).HasColumnName("SchoolName");
            this.Property(t => t.Term).HasColumnName("Term");
            this.Property(t => t.ReleaseDate).HasColumnName("ReleaseDate");
            this.Property(t => t.ReleaseCount).HasColumnName("ReleaseCount");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.Bookseller_ID).HasColumnName("Bookseller_ID");
            this.Property(t => t.BooksellerName).HasColumnName("BooksellerName");
            this.Property(t => t.RecipientType).HasColumnName("RecipientType");

            // Relationships
            this.HasRequired(t => t.StockRecord)
                .WithMany(t => t.ReleaseRecords)
                .HasForeignKey(d => d.StockRecord_ID);
                        
            //子类识别
            //Map<StudentReleaseRecord>(m =>
            //    m.Requires("RecipientType").HasValue((int)RecipientType.Student))
                //Map<TeacherReleaseRecord>(m =>
                //    m.Requires("RecipientType").HasValue((int)RecipientType.Teacher));

        }
    }
}
