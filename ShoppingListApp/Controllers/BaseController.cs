using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ShoppingListApp.Core.Constants.AdminConstants;

namespace ShoppingListApp.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]

    public class BaseController : Controller
    {        

    }
}
