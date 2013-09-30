using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class StudentReleaseRecordMap : EntityTypeConfiguration<StudentReleaseRecord>
    {
        public StudentReleaseRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.ReleaseRecordID);

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


            // Table & Column Mappings
            this.ToTable("ReleaseRecord_Student", "Textbook");
            this.Property(t => t.ReleaseRecordID).HasColumnName("ReleaseRecordID");
            this.Property(t => t.Class_ID).HasColumnName("Class_ID");
            this.Property(t => t.ClassName).HasColumnName("ClassName");
            this.Property(t => t.Student_ID).HasColumnName("Student_ID");
            this.Property(t => t.StudentNum).HasColumnName("StudentNum");
            this.Property(t => t.StudentName).HasColumnName("StudentName");
            this.Property(t => t.Gender).HasColumnName("Gender");

            // Relationships
            //this.HasRequired(t => t.ReleaseRecord)
            //    .WithOptional(t => t.ReleaseRecord_Student);

        }
    }
}
