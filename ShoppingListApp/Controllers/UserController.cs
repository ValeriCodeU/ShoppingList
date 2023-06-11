using Microsoft.AspNetCore.Mvc;

namespace ShoppingListApp.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
