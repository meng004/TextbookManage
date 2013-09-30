namespace TextbookManage.Repositories.Mapping
{

    using System.Data.Entity.ModelConfiguration;
    using TextbookManage.Domain.Models;

    public class TermMap : EntityTypeConfiguration<Term>
    {
        public TermMap()
        {
            // Primary Key
            this.HasKey(t => t.Name);

            // Properties
            //this.Property(t => t.Name)
            //    .IsRequired()
            //    .HasMaxLength(20);

            //this.Property(t => t.IsValid)
            //    .IsRequired();

            // Table & Column Mappings
            this.ToTable("DM_XNXQ", "dbo");
            //this.Property(t => t.TermID).HasColumnName("TermID");
            this.Property(t => t.Name).HasColumnName("XNXQ");
            this.Property(t => t.IsValid).HasColumnName("DQXNXQBZ");

            //this.Ignore(t => t.IsValid);
            
            //this.Map<Term>(m => 
            //    {
            //        m.ToTable("DM_XNXQ", "dbo");
            //        m.Requires("DQXNXQBZ").HasValue("0");
            //    });
            //this.Map<CurrentTerm>(m => m.Requires("DQXNXQBZ").HasValue("1"));
        }
    }
}
