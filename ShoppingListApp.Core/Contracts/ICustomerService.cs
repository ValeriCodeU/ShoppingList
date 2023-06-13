using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Core.Contracts
{
	public interface ICustomerService
	{
		Task<bool> IsExistsByIdAsync(Guid userId);
	}
}
