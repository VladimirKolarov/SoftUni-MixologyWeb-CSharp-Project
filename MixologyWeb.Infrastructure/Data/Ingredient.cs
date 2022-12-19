using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MixologyWeb.Infrastructure.Data
{
    public class Ingredient
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public Guid MeasurementId { get; set; }

        [ForeignKey(nameof(MeasurementId))]
        public Measurement Measurement { get; set; }

        public List<IngredientQuantity> IngredientQuantities { get; set; } = new List<IngredientQuantity>();
    }
}
