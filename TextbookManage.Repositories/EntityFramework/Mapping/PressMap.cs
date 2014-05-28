using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class PressMap : EntityTypeConfiguration<Press>
    {
        public PressMap()
        {
            this.HasKey(t => t.PressId);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.PreIsbn)
                .HasMaxLength(20);

            this.Property(t => t.Address)
                .HasMaxLength(200);

            this.Property(t => t.Postcode)
                .HasMaxLength(20);

            this.ToTable("Press", "Textbook");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Postcode).HasColumnName("PostCode");
            this.Property(t => t.PreIsbn).HasColumnName("PreISBN");
            this.Property(t => t.PressId).HasColumnName("PressID");


        }
    }
}
