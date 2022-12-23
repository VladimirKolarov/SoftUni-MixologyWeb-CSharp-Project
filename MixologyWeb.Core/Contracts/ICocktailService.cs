using MixologyWeb.Core.Models;

namespace MixologyWeb.Core.Contracts
{
    public interface ICocktailService
    {
        Task<IEnumerable<CocktailViewModel>> GetAllCocktails();

        Task<CocktailViewModel> GetCocktailById(string id);
    }
}
