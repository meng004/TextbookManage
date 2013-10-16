using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class TermMap : EntityTypeConfiguration<Term>
    {
        public TermMap()
        {
            // Primary Key
            this.HasKey(t => t.YearTerm);

            // Properties
            this.Property(t => t.YearTerm)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("DM_XNXQ", "dbo");
            this.Property(t => t.YearTerm).HasColumnName("XNXQ");
            this.Property(t => t.dqxnxqbz).HasColumnName("DQXNXQBZ");
            //²»Ó³ÉäIscurrentÊôÐÔ
            this.Ignore(t => t.IsCurrent);
        }
    }
}
