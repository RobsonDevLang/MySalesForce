using Microsoft.EntityFrameworkCore;
using User.Configurations;
using User.Models;
using User.Services;

namespace User.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<UserModel> AppUser  { get; set; }
        public DbSet<PositionModel> Position { get; set; }
        public DbSet<DepartmentModel> Department { get; set; }
        public DbSet<RoleModel> Role { get; set; }
        public DbSet<PermissionModel> Permission { get; set; }
        public DbSet<RolePermissionModel> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
            modelBuilder.Entity<RolePermissionModel>()
                        .HasKey(x => new { x.RoleId, x.PermissionId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
