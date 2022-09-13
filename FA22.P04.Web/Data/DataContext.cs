using Microsoft.EntityFrameworkCore;
using FA22.P04.Web.Features.Users;
using FA22.P04.Web.Features.Roles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace FA22.P04.Web.Data;

public class DataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole,
IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DataContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserRole>()
     .HasKey(bc => new { bc.UserId, bc.RoleId });
        modelBuilder.Entity<UserRole>()
            .HasOne(bc => bc.User)
            .WithMany(b => b.UserRoles)
            .HasForeignKey(bc => bc.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<UserRole>()
            .HasOne(bc => bc.Role)
            .WithMany()
            .HasForeignKey(bc => bc.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        // this stores all decimal values to two decimal points by default - good enough for our purposes
        configurationBuilder.Properties<decimal>()
            .HavePrecision(18, 2);
    }
}
