using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Core.Contracts;
using ShoppingListApp.Infrastructure.Data.Common;
using ShoppingListApp.Infrastructure.Data.Identity;

namespace ShoppingListApp.Core.Services
{

	public class CustomerService : ICustomerService
	{
        private readonly IRepository repo;

		public CustomerService(IRepository _repo)
		{
			repo = _repo;				
		}

        public async Task<bool> IsExistsByIdAsync(Guid userId)
		{
			return await repo.AllReadonly<ApplicationUser>().AnyAsync(u => u.Id == userId && u.IsActive);
        }
	}
}
