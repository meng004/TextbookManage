using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class FeedbackMap : EntityTypeConfiguration<Feedback>
    {
        public FeedbackMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);            

            // Properties
            this.Property(t => t.Person)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Remark)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("Feedback", "Textbook");
            this.Property(t => t.ID).HasColumnName("FeedbackID");
            this.Property(t => t.Person).HasColumnName("Person");
            this.Property(t => t.FeedbackDate).HasColumnName("FeedbackDate");
            this.Property(t => t.FeedbackState).HasColumnName("FeedbackState");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.ApprovalState).HasColumnName("ApprovalState");
            
        }
    }
}
