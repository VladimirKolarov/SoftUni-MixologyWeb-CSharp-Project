using System.ComponentModel.DataAnnotations;

namespace MixologyWeb.Infrastructure.Data
{
    public class Cocktail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(2048)]
        public string? ImageUrl { get; set; }

        [Required]
        [StringLength(1000)]
        public string PreparationInfo { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Range (0.0, 10.0)]
        public double? Rating { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<IngredientQuantity> IngredientQuantities { get; set; } = new List<IngredientQuantity>();

        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
