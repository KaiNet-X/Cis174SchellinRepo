using Microsoft.EntityFrameworkCore;
using ProjectCentral.Migrations;

namespace ProjectCentral.Models
{
    public class UserContextModel : DbContext
    {
        public UserContextModel(DbContextOptions<UserContextModel> options)
            : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleAuthorizationModel> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SeedData(builder);
        }
        private void SeedData(ModelBuilder builder)
        {

            builder.Entity<RoleAuthorizationModel>().HasData(
                new RoleAuthorizationModel { RoleID = 1, RoleName = "Administrator" },
                new RoleAuthorizationModel { RoleID = 2, RoleName = "User" }
                );
            builder.Entity<UserModel>().HasData(
                new UserModel { UserID = 1, Password = "Admin", UserName = "Admin", RoleID = 1 }
                );
        }
    }
}
