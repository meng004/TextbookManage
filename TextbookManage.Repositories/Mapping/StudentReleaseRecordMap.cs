using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class StudentReleaseRecordMap : EntityTypeConfiguration<StudentReleaseRecord>
    {
        public StudentReleaseRecordMap()
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
            this.Property(t => t.ClassName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.StudentNum)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.StudentName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Gender)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Recipient1Name)
                .HasMaxLength(200);

            this.Property(t => t.Recipient1Phone)
                .HasMaxLength(200);

            this.Property(t => t.Recipient2Name)
                .HasMaxLength(200);

            this.Property(t => t.Recipient2Phone)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("StudentReleaseRecord", "Textbook");
            //this.Property(t => t.ID).HasColumnName("ReleaseRecordID");
            this.Property(t => t.Class_Id).HasColumnName("Class_ID");
            this.Property(t => t.ClassName).HasColumnName("ClassName");
            this.Property(t => t.Student_Id).HasColumnName("Student_ID");
            this.Property(t => t.StudentNum).HasColumnName("StudentNum");
            this.Property(t => t.StudentName).HasColumnName("StudentName");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.Recipient1Name).HasColumnName("Recipient1Name");
            this.Property(t => t.Recipient1Phone).HasColumnName("Recipient1Phone");
            this.Property(t => t.Recipient2Name).HasColumnName("Recipient2Name");
            this.Property(t => t.Recipient2Phone).HasColumnName("Recipient2Phone");

            // Relationships
            //this.HasRequired(t => t.ReleaseRecord)
            //    .WithOptional(t => t.ReleaseRecord_Student);
            
            //学生：发放记录，1：N
            this.HasRequired(t => t.Student)
                .WithMany(t => t.ReleaseRecords)
                .HasForeignKey(t => t.Student_Id);
        }
    }
}
