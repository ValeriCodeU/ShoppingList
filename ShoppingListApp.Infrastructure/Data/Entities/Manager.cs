using ShoppingListApp.Infrastructure.Data.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListApp.Infrastructure.Data.Entities
{
    public class Manager
	{
        public int Id { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]

        public ApplicationUser User { get; set; } = null!;

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
