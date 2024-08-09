using Microsoft.AspNetCore.Mvc;

namespace BKMeCommerceWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
