using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class ApprovalMap : EntityTypeConfiguration<Approval>
    {
        public ApprovalMap()
        {
            // Primary Key
            this.HasKey(t => t.ApprovalID);

            // Properties
            this.Property(t => t.Division)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Auditor)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Remark)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("Approval", "Textbook");
            this.Property(t => t.ApprovalID).HasColumnName("ApprovalID");
            this.Property(t => t.Division).HasColumnName("Division");
            this.Property(t => t.Auditor).HasColumnName("Auditor");
            this.Property(t => t.ApprovalDate).HasColumnName("ApprovalDate");
            this.Property(t => t.Suggestion).HasColumnName("Suggestion");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.ApprovalTarget).HasColumnName("ApprovalTarget");

        }
    }
}
