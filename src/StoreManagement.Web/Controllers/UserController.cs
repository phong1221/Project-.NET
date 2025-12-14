using Microsoft.AspNetCore.Mvc;

namespace StoreManagement.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
