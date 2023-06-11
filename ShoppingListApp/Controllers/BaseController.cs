using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ShoppingListApp.Core.Constants.AdminConstants;

namespace ShoppingListApp.Controllers
{
    [Authorize(Roles = AdminRoleName)]

    public class BaseController : Controller
    {        

    }
}
