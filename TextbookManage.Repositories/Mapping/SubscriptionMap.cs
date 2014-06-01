using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class SubscriptionMap : EntityTypeConfiguration<Subscription>
    {
        public SubscriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.SubscriptionId);

            // Properties
            //this.Property(t => t.Term)
            //    .IsRequired()
            //    .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Subscription", "Textbook");
            this.Property(t => t.SubscriptionId).HasColumnName("SubscriptionID");
            this.Property(t => t.Bookseller_Id).HasColumnName("Bookseller_ID");
            this.Property(t => t.Textbook_Id).HasColumnName("Textbook_ID");
            this.Property(t => t.Feedback_Id).HasColumnName("Feedback_ID");
            this.Property(t => t.SchoolYearTerm.Year).HasColumnName("Year");
            this.Property(t => t.SchoolYearTerm.Term).HasColumnName("Term");
            this.Property(t => t.PlanCount).HasColumnName("PlanCount");
            this.Property(t => t.SpareCount).HasColumnName("SpareCount");
            this.Property(t => t.SubscriptionDate).HasColumnName("SubscriptionDate");           

            // Relationships
            this.HasRequired(t => t.Bookseller)
                .WithMany(t => t.Subscriptions)
                .HasForeignKey(d => d.Bookseller_Id);

            this.HasRequired(t => t.Feedback)
                .WithMany(t => t.Subscriptions)
                .HasForeignKey(d => d.Feedback_Id);

            this.HasRequired(t => t.Textbook)
                .WithMany(t => t.Subscriptions)
                .HasForeignKey(d => d.Textbook_Id);

        }
    }
}
