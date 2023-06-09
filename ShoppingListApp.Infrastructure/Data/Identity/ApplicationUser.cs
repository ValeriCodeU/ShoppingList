using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static ShoppingListApp.Infrastructure.Data.Constants.DataConstants.ApplicationUser;

namespace ShoppingListApp.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [MaxLength(MaxUserFirstName)]

        public string? FirstName { get; set; }

        [MaxLength(MaxUserLastName)]

        public string? LastName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
