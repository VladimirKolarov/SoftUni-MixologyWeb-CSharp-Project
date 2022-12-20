using System.ComponentModel.DataAnnotations;

namespace MixologyWeb.Infrastructure.Data
{
    public class Song
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0, 3000)]
        public int YearReleased { get; set; }

        [StringLength(2048)]
        public string? ExternalLink { get; set; }

        public List<Performer> Performers { get; set; } = new List<Performer>();
        public List<Cocktail> Cocktails { get; set; } = new List<Cocktail>();
    }
}
