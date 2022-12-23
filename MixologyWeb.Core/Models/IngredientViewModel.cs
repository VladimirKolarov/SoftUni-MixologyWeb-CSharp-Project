using System.ComponentModel.DataAnnotations;

namespace MixologyWeb.Core.Models
{
    public class IngredientViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
