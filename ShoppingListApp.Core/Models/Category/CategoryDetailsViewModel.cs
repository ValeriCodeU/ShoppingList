using System.ComponentModel.DataAnnotations;
using static ShoppingListApp.Core.Constants.ViewModelConstants.Category;

namespace ShoppingListApp.Core.Models.Category
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxCategoryName, MinimumLength = MinCategoryName)]

        public string Name { get; set; } = null!;
    }
}
