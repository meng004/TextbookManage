using System.Data.Entity.ModelConfiguration;
using TextbookManage.Domain.Models;

namespace TextbookManage.Repositories.Mapping
{
    public class TbmisUserMap:EntityTypeConfiguration<TbmisUser>
    {
        public TbmisUserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(256);

            this.ToTable("V_SYS_UsersInfo", "dbo");
            this.Property(t => t.UserId).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.TbmisUserId).HasColumnName("YHID");
            this.Property(t => t.TbmisUserName).HasColumnName("XM");
            this.Property(t => t.SchoolId).HasColumnName("YXSID");
            this.Property(t => t.SchoolName).HasColumnName("YXSMC");
            this.Property(t => t.YHLXM).HasColumnName("YHLXM");
            this.Property(t => t.IdCard).HasColumnName("SFZH");

            Ignore(t => t.UserType);

            //用户与角色，多对多
            this.HasMany(t=>t.Roles)
                .WithMany(t=>t.Users)
                 .Map(m =>
                    {
                        m.ToTable("aspnet_UsersInRoles","dbo");
                        m.MapLeftKey("UserId");
                        m.MapRightKey("RoleId");
                    });
                

        }
    }
}
