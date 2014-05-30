using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Repositories.Mapping
{
    public class PressMap : EntityTypeConfiguration<Press>
    {
        public PressMap()
        {
            this.HasKey(t => t.PreIsbn);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.PreIsbn)
                .HasMaxLength(10);

            this.ToTable("DM_CBS", "dbo");
            //this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Name).HasColumnName("CBSMC");
            //this.Property(t => t.Postcode).HasColumnName("PostCode");
            this.Property(t => t.PreIsbn).HasColumnName("CBSBM");
            //this.Property(t => t.PressId).HasColumnName("PressID");


        }
    }
}
