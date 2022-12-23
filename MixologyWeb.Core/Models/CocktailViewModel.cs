using System.ComponentModel.DataAnnotations;

namespace MixologyWeb.Core.Models
{
    public class CocktailViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string PreparationInfo { get; set; }

        public string Description { get; set; }

        public double? Rating { get; set; }

        public IList<IngredientViewModel> Ingredients { get; set; }
    }
}
