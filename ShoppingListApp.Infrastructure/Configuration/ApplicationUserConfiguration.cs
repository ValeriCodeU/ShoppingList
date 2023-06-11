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

            //Admin user and manager of the web shop

            var adminUser = new ApplicationUser()
            {
                Id = new Guid("48787569-f841-4832-8528-1f503a8427cf"),
                FirstName = "Valeri",
                LastName = "Yanev",
                UserName = "valeri",
                NormalizedUserName = "valeri",
                Email = "valeri.yanev@icloud.com",
                NormalizedEmail = "VALERI.YANEV@ICLOUD.COM",
            };

            adminUser.PasswordHash =
                 hasher.HashPassword(adminUser, "pass11");            

            var customerUser = new ApplicationUser()
            {
                Id = new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3"),
                FirstName = "Georgi",
                LastName = "Ivanov",
                UserName = "georgi",
                NormalizedUserName = "GEORGI",
                Email = "georgi@mail.com",
                NormalizedEmail = "GEORGI@MAIL.COM",                
            };

            customerUser.PasswordHash =
                 hasher.HashPassword(customerUser, "georgi123");
            

            var otherCustomer = new ApplicationUser()
            {
                Id = new Guid("da24feae-ab42-4702-bbf9-9c5361aee8d6"),
                FirstName = "Svetlin",
                LastName = "Nakov",
                UserName = "nakov",
                NormalizedUserName = "NAKOV",
                Email = "nakov@softuni.bg",
                NormalizedEmail = "NAKOV@SOFTUNI.BG",               
            };

            otherCustomer.PasswordHash =
                 hasher.HashPassword(otherCustomer, "cat123");

            users.Add(adminUser);
            users.Add(customerUser);
            users.Add(otherCustomer);

            return users;
        }
    }
}
