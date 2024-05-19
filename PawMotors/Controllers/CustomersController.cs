using Microsoft.AspNetCore.Mvc;
using PawMotors.ProjeContext;

namespace PawMotors.Controllers
{
    public class CustomersController : Controller
    {
        Context Context = new Context();
        public IActionResult Index()
        {
            return View();
        }
    }
}
