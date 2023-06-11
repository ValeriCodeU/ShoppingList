using System.ComponentModel.DataAnnotations;
using static ShoppingListApp.Infrastructure.Data.Constants.DataConstants.Category;

namespace ShoppingListApp.Infrastructure.Data.Entities
{
    public class Category
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxCategoryName)]

        public string Name { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public List<Product> Products { get; set; } = new List<Product>();        
    }
}
