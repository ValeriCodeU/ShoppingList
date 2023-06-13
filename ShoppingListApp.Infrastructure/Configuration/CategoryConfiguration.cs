using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingListApp.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Infrastructure.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CollectionOfCategories());
        }

        private List<Category> CollectionOfCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Foods"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Drinks"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Clothes"
                },
                 new Category()
                {
                    Id = 6,
                    Name = "Books"
                }
            };
        }
    }
}
