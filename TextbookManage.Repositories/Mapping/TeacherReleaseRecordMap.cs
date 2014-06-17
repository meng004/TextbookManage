using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class TeacherReleaseRecordMap : EntityTypeConfiguration<TeacherReleaseRecord>
    {
        public TeacherReleaseRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Num)
                .IsRequired();

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

            this.Property(t => t.TextbookType)
                .HasMaxLength(200);

            this.Property(t => t.SchoolName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.BooksellerName)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            //this.ToTable("ReleaseRecord", "Textbook");
            this.Property(t => t.ID).HasColumnName("ReleaseRecordID");
            this.Property(t => t.StockRecord_Id).HasColumnName("StockRecord_ID");
            this.Property(t => t.Textbook_Id).HasColumnName("Textbook_ID");
            this.Property(t => t.Num).HasColumnName("Num");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Isbn).HasColumnName("Isbn");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.Press).HasColumnName("Press");
            this.Property(t => t.Edition).HasColumnName("Edition");
            this.Property(t => t.PrintCount).HasColumnName("PrintCount");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.DiscountPrice).HasColumnName("DiscountPrice");
            this.Property(t => t.TextbookType).HasColumnName("TextbookType");
            this.Property(t => t.School_Id).HasColumnName("School_ID");
            this.Property(t => t.SchoolName).HasColumnName("SchoolName");
            this.Property(t => t.SchoolYearTerm.Year).HasColumnName("SchoolYear");
            this.Property(t => t.SchoolYearTerm.Term).HasColumnName("SchoolTerm");
            this.Property(t => t.ReleaseDate).HasColumnName("ReleaseDate");
            this.Property(t => t.ReleaseCount).HasColumnName("ReleaseCount");
            this.Property(t => t.Bookseller_Id).HasColumnName("Bookseller_ID");
            this.Property(t => t.BooksellerName).HasColumnName("BooksellerName");

            // Properties
            this.Property(t => t.DepartmentName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.TeacherName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Gender)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.IdCardNum)
                .HasMaxLength(20);

            this.Property(t => t.Barcode)
                .HasMaxLength(20);

            this.Property(t => t.RecipientName).HasMaxLength(200);
            this.Property(t => t.RecipientPhone).HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("ReleaseRecord_Teacher", "Textbook");
            //this.Property(t => t.ID).HasColumnName("ReleaseRecordID");
            this.Property(t => t.Department_Id).HasColumnName("Department_ID");
            this.Property(t => t.DepartmentName).HasColumnName("DepartmentName");
            this.Property(t => t.Teacher_Id).HasColumnName("Teacher_ID");
            this.Property(t => t.TeacherName).HasColumnName("TeacherName");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.IdCardType).HasColumnName("IDCardType");
            this.Property(t => t.IdCardNum).HasColumnName("IDCardNum");
            this.Property(t => t.Barcode).HasColumnName("Barcode");
            this.Property(t => t.RecipientName).HasColumnName("RecipientName");
            this.Property(t => t.RecipientPhone).HasColumnName("RecipientPhone");
            // Relationships
            //this.HasRequired(t => t.ReleaseRecord)
            //    .WithOptional(t => t.ReleaseRecord_Teacher);

            //教师：发放记录，1：N
            this.HasRequired(t => t.Teacher)
                .WithMany(t => t.ReleaseRecords)
                .HasForeignKey(t => t.Teacher_Id);
        }
    }
}
