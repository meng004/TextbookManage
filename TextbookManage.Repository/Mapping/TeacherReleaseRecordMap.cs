using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class TeacherReleaseRecordMap : EntityTypeConfiguration<TeacherReleaseRecord>
    {
        public TeacherReleaseRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.ReleaseRecordID);

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
                

            this.Property(t => t.IDCardNum)
                .HasMaxLength(20);

            this.Property(t => t.Barcode)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ReleaseRecord_Teacher", "Textbook");
            this.Property(t => t.ReleaseRecordID).HasColumnName("ReleaseRecordID");
            this.Property(t => t.Department_ID).HasColumnName("Department_ID");
            this.Property(t => t.DepartmentName).HasColumnName("DepartmentName");
            this.Property(t => t.Teacher_ID).HasColumnName("Teacher_ID");
            this.Property(t => t.TeacherName).HasColumnName("TeacherName");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.IDCardType).HasColumnName("IDCardType");
            this.Property(t => t.IDCardNum).HasColumnName("IDCardNum");
            this.Property(t => t.Barcode).HasColumnName("Barcode");

            // Relationships
            //this.HasRequired(t => t.ReleaseRecord)
            //    .WithOptional(t => t.ReleaseRecord_Teacher);

        }
    }
}
