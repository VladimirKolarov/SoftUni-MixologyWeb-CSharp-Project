using Microsoft.AspNetCore.Mvc;

namespace MixologyWeb.Controllers
{
    public class NotFoundController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
