using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class SubscriptionMap : EntityTypeConfiguration<Subscription>
    {
        public SubscriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            //this.Property(t => t.Term)
            //    .IsRequired()
            //    .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Subscription", "Textbook");
            this.Property(t => t.ID).HasColumnName("SubscriptionID");
            this.Property(t => t.Bookseller_Id).HasColumnName("Bookseller_ID");
            this.Property(t => t.Textbook_Id).HasColumnName("Textbook_ID");
            this.Property(t => t.Feedback_Id).HasColumnName("Feedback_ID");
            this.Property(t => t.SchoolYearTerm.Year).HasColumnName("SchoolYear");
            this.Property(t => t.SchoolYearTerm.Term).HasColumnName("SchoolTerm");
            this.Property(t => t.PlanCount).HasColumnName("PlanCount");
            this.Property(t => t.SpareCount).HasColumnName("SpareCount");
            this.Property(t => t.SubscriptionDate).HasColumnName("SubscriptionDate");
            this.Property(t => t.SubscriptionState).HasColumnName("SubscriptionState");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion").IsRowVersion();//乐观并发标志
            // 书商：书商订单，1：N
            this.HasRequired(t => t.Bookseller)
                .WithMany(t => t.Subscriptions)
                .HasForeignKey(d => d.Bookseller_Id);
            //回告：书商订单，1：N
            this.HasRequired(t => t.Feedback)
                .WithMany(t => t.Subscriptions)
                .HasForeignKey(d => d.Feedback_Id);
            //教材：书商订单，1：N
            this.HasRequired(t => t.Textbook)
                .WithMany(t => t.Subscriptions)
                .HasForeignKey(d => d.Textbook_Id);

        }
    }
}
