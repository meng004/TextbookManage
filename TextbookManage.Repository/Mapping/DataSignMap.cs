namespace TextbookManage.Repositories.Mapping
{

    using System.Data.Entity.ModelConfiguration;
    using TextbookManage.Domain.Models;

    public class DataSignMap : EntityTypeConfiguration<DataSign>
    {
        public DataSignMap()
        {
            // Primary Key
            this.HasKey(t => t.Num);

            // Properties
            //this.Property(t => t.Num)
            //    .IsRequired();
                //.HasMaxLength(20);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("XT_SJBS", "dbo");
            //this.Property(t => t.DataSignID).HasColumnName("DataSignID");
            this.Property(t => t.Num).HasColumnName("SJBSID");
            this.Property(t => t.Name).HasColumnName("SJBSMC");
        }
    }
}
