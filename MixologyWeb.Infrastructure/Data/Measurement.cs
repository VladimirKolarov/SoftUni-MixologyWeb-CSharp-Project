using System.ComponentModel.DataAnnotations;

namespace MixologyWeb.Infrastructure.Data
{
    public class Measurement
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
