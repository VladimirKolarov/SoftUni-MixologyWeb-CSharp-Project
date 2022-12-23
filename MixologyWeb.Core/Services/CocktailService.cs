using Microsoft.EntityFrameworkCore;
using MixologyWeb.Core.Contracts;
using MixologyWeb.Core.Models;
using MixologyWeb.Infrastructure.Data;
using MixologyWeb.Infrastructure.Repositories;

namespace MixologyWeb.Core.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly IApplicationDbRepository repo;

        public CocktailService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        //public async Task<IEnumerable<CocktailViewModel>> GetIngredientsInCocktail(string id)
        //{
        //    return await repo.All<IngredientQuantity>()
        //        .Where(i=>i.CocktailId.ToString().Equals(id))
        //        .Select(i => new Dictionary<IngredientViewModel, double>()
        //        {
        //            Id = c.Id.ToString(),
        //            Name = c.Name,
        //            ImageUrl = c.ImageUrl ?? string.Empty,
        //            PreparationInfo = c.PreparationInfo,
        //            Description = c.Description ?? string.Empty,
        //            Rating = c.Rating
        //        }).ToListAsync();
        //}

        public async Task<IEnumerable<CocktailViewModel>> GetAllCocktails()
        {
            return await repo.All<Cocktail>()
                .Include(c=>c.Ingredient)
                .Select(c => new CocktailViewModel
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    ImageUrl = c.ImageUrl ?? string.Empty,
                    PreparationInfo = c.PreparationInfo,
                    Description = c.Description ?? string.Empty,
                    Rating = c.Rating,
                    Ingredients = c.Ingredient.Select( i=>new IngredientViewModel 
                    { 
                        Id = i.Id.ToString(),
                        Name= i.Name,
                        Description = i.Description ?? string.Empty,
                    }).ToList(),
                }).ToListAsync();
        }

        public async Task<CocktailViewModel> GetCocktailById(string id)
        {
            return await repo.All<Cocktail>()
                .Include(c => c.Ingredient)
                .Where(c => c.Id.ToString().Equals(id))
                .Select(c => new CocktailViewModel
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    ImageUrl = c.ImageUrl ?? string.Empty,
                    PreparationInfo = c.PreparationInfo,
                    Description = c.Description ?? string.Empty,
                    Rating = c.Rating,
                    Ingredients = c.Ingredient.Select(i => new IngredientViewModel
                    {
                        Id = i.Id.ToString(),
                        Name = i.Name,
                        Description = i.Description ?? string.Empty,
                    }).ToList(),
                }).FirstAsync();
        }
    }
}
