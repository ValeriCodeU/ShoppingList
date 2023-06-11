using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Infrastructure.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ShoppingListApp.Infrastructure.Data.Constants.DataConstants.Product;


namespace ShoppingListApp.Infrastructure.Data.Entities
{
    public class Product
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxProductName)]

        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(MaxProductDescription)]

        public string Description { get; set; } = null!;

        [Column(TypeName = "Money")]
        [Precision(PrecisionDecimal, ScaleDecimal)]

        public decimal Price { get; set; }

        [MaxLength(MaxProductImageUrl)]

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]

        public Category Category { get; set; } = null!;

        public Guid? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]

        public ApplicationUser? Customer { get; set; }       

        public bool IsActive { get; set; } = true;
    }
}
