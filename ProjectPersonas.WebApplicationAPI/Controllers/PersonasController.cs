using Microsoft.AspNetCore.Mvc;

namespace ProjectPersonas.WebApplicationAPI.Controllers
{
    public class PersonasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
