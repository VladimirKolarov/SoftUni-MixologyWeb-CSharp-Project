using System.ComponentModel.DataAnnotations;

namespace MixologyWeb.Core.Models
{
    public class UserEditViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "User Name")]
        public string Name { get; set; }

    }
}
