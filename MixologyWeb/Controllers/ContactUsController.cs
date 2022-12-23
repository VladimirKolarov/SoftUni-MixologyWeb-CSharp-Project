using Microsoft.AspNetCore.Mvc;

namespace MixologyWeb.Controllers
{
    public class ContactUsController : BaseController
    {
        public IActionResult ContactCard()
        {
            return View();
        }
    }
}
