using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixologyWeb.Infrastructure.Data
{
    public class IngredientQuantity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid IngredientId { get; set; }

        [ForeignKey(nameof(IngredientId))]
        public Ingredient Ingredient { get; set; }

        [Required]
        public Guid CocktailId { get; set; }

        [ForeignKey(nameof(CocktailId))]
        public Cocktail Cocktail { get; set; }

        [Required]
        [Range(0.0, 1000.0)]
        public double Quantity { get; set; }
    }
}
