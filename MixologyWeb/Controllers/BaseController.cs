using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MixologyWeb.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
