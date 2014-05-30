using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class TeacherReleaseRecordMap : EntityTypeConfiguration<TeacherReleaseRecord>
    {
        public TeacherReleaseRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.ReleaseRecordId);

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
            this.Property(t => t.ReleaseRecordId).HasColumnName("ReleaseRecordID");
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

            this.HasRequired(t => t.Teacher)
                .WithMany(t => t.ReleaseRecords)
                .HasForeignKey(t => t.Teacher_Id);
        }
    }
}
