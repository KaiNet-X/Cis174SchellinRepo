using Microsoft.EntityFrameworkCore;

namespace ProjectCentral.Models
{
    public class UserContextModel : DbContext
    {
        //creates user context model
        public UserContextModel(DbContextOptions<UserContextModel> options)
            : base(options) { }
        //associates user model in the database
        public DbSet<UserModel> Users { get; set; }
        //associates role model in the database
        public DbSet<RoleAuthorizationModel> Roles { get; set; }
        //seeds data and passes modelbuilder to the base method
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SeedData(builder);
        }
        //seeds user and role data
        private void SeedData(ModelBuilder builder)
        {

            builder.Entity<RoleAuthorizationModel>().HasData(
                new RoleAuthorizationModel { RoleID = 1, RoleName = "Administrator" },
                new RoleAuthorizationModel { RoleID = 2, RoleName = "User" },
                new RoleAuthorizationModel { RoleID = 3, RoleName = "Anonymous" }
                );
            builder.Entity<UserModel>().HasData(
                new UserModel { UserID = 1, Password = "Admin", UserName = "Admin", RoleID = 1 },
                new UserModel { UserID = 2, Password = "", UserName = "", RoleID = 3}
                );
        }
    }
}
