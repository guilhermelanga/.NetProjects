using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture URL")]
        [Required(ErrorMessage = "The profile picture URL is required.")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "The name is required.")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string? Bio { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
