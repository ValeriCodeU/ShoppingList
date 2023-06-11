using Microsoft.AspNetCore.Mvc;

namespace ShoppingListApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
