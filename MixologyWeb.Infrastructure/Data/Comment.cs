using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MixologyWeb.Infrastructure.Data
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(1000)]
        public string Text { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public Guid CocktailId { get; set; }

        [ForeignKey(nameof(CocktailId))]
        public Cocktail Cocktail { get; set; }

    }
}
