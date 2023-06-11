using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Infrastructure.Configuration;
using ShoppingListApp.Infrastructure.Data.Entities;
using ShoppingListApp.Infrastructure.Data.Identity;

namespace ShoppingListApp.Infrastructure.Data
{
    public class ShoppingListDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserConfiguration());

            this.SeedRoles(builder);
            this.SeedUserRoles(builder);

            base.OnModelCreating(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>() { Id = new Guid("b3bf89bc-b80a-4b24-9f4b-9a90bb4fe652"), Name = "Administrator", ConcurrencyStamp = "1", NormalizedName = "ADMINISTRATOR" },
                new IdentityRole<Guid>() { Id = new Guid("5fb4a609-b894-4db7-a7cf-7fe80cb6d536"), Name = "Customer", ConcurrencyStamp = "2", NormalizedName = "CUSTOMER" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            //Admin

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>() { RoleId = new Guid("b3bf89bc-b80a-4b24-9f4b-9a90bb4fe652"), UserId = new Guid("48787569-f841-4832-8528-1f503a8427cf") }
                );

            //Customer

            builder.Entity<IdentityUserRole<Guid>>().HasData(
               new IdentityUserRole<Guid>() { RoleId = new Guid("5fb4a609-b894-4db7-a7cf-7fe80cb6d536"), UserId = new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3") }
               );

            builder.Entity<IdentityUserRole<Guid>>().HasData(
              new IdentityUserRole<Guid>() { RoleId = new Guid("5fb4a609-b894-4db7-a7cf-7fe80cb6d536"), UserId = new Guid("da24feae-ab42-4702-bbf9-9c5361aee8d6") }
              );
        }
    }
}