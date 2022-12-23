using Microsoft.AspNetCore.Mvc;
using MixologyWeb.Core.Contracts;
using MixologyWeb.Core.Services;

namespace MixologyWeb.Controllers
{
    public class CocktailController : BaseController
    {

        private readonly ICocktailService cocktailService;

        public CocktailController(ICocktailService _cocktailService)
        {
            cocktailService = _cocktailService;
        }
        public async Task<IActionResult> All()
        {
            var cocktails = await cocktailService.GetAllCocktails();
            return View(cocktails);
        }

        public async Task<IActionResult> Details(string id)
        {
            var cocktail = await cocktailService.GetCocktailById(id);
            return View(cocktail);
        }
    }
}
