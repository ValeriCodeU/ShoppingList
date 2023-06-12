using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingListApp.Controllers
{
    [Authorize]

    public class BaseController : Controller
    {        

    }
}
