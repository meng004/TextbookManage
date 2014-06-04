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
            this.ToTable("ReleaseRecord_Student", "Textbook");
            this.Property(t => t.ID).HasColumnName("ReleaseRecordID");
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
