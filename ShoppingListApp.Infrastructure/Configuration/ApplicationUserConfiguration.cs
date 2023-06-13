using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingListApp.Infrastructure.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Infrastructure.Configuration
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(CollectionOfUsers());
        }

        private List<ApplicationUser> CollectionOfUsers()
        {
            var users = new List<ApplicationUser>();

            var hasher = new PasswordHasher<ApplicationUser>();

            //Seed data for admin user and manager of the web shop

            var adminUser = new ApplicationUser()
            {
                Id = new Guid("48787569-f841-4832-8528-1f503a8427cf"),
                FirstName = "Valeri",
                LastName = "Yanev",
                UserName = "valeri",
                NormalizedUserName = "valeri",
                Email = "valeri.yanev@icloud.com",
                NormalizedEmail = "VALERI.YANEV@ICLOUD.COM",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            adminUser.PasswordHash =
                 hasher.HashPassword(adminUser, "pass11");

            users.Add(adminUser);

            //Seed data for customer

            var customerUser = new ApplicationUser()
            {
                Id = new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3"),
                FirstName = "Georgi",
                LastName = "Ivanov",
                UserName = "georgi",
                NormalizedUserName = "GEORGI",
                Email = "georgi@mail.com",
                NormalizedEmail = "GEORGI@MAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            customerUser.PasswordHash =
                 hasher.HashPassword(customerUser, "georgi123");

            users.Add(customerUser);

            //Seed data for customer

            var otherCustomer = new ApplicationUser()
            {
                Id = new Guid("da24feae-ab42-4702-bbf9-9c5361aee8d6"),
                FirstName = "Svetlin",
                LastName = "Nakov",
                UserName = "nakov",
                NormalizedUserName = "NAKOV",
                Email = "nakov@softuni.bg",
                NormalizedEmail = "NAKOV@SOFTUNI.BG",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            otherCustomer.PasswordHash =
                 hasher.HashPassword(otherCustomer, "cat123");
            
            
            users.Add(otherCustomer);

            return users;
        }
    }
}
