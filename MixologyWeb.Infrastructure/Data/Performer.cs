using System.ComponentModel.DataAnnotations;

namespace MixologyWeb.Infrastructure.Data
{
    public class Performer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
