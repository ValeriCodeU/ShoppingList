using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingListApp.Infrastructure.Data.Entities;
using System.Xml.Linq;

namespace ShoppingListApp.Infrastructure.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(CollectionOfProducts());
        }

        private List<Product> CollectionOfProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "T-Shirt",
                    Description = "Short sleeve",
                    ImageUrl = "https://underarmour.scene7.com/is/image/Underarmour/PS1370179-369_HF?rp=standard-0pad|pdpZoomDesktop&scl=0.72&fmt=jpg&qlt=85&resMode=sharp2&cache=on,on&bgc=f0f0f0&wid=1836&hei=1950&size=1500,1500",
                    CategoryId = 3,
                    CustomerId = new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3")
                },
                new Product()
                {
                    Id = 2,
                    Name = "Code Complete",
                    Description = "Programming book",
                    ImageUrl = "https://m.media-amazon.com/images/I/51IM3Ywr1yL._SX218_BO1,204,203,200_QL40_FMwebp_.jpg",
                    CategoryId = 4,
                    CustomerId = new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3")
                },
                 new Product()
                {
                    Id = 3,
                    Name = "Pizza",
                    Description = "Quattro formaggi",
                    ImageUrl = "https://images.ctfassets.net/nw5k25xfqsik/7v9YdB3xOTeDCx2PJuw6Nk/e755ce5413e7c9600bda03ace27f3ee1/FourCheese_Resized.jpg?w=1024",
                    CategoryId = 1,
                    CustomerId = new Guid("bfbcc7d7-2e7e-4d3c-b7fb-4b76f27cefe3")
                },
            };
        }
    }
}
