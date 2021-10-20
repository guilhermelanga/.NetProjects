using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cinema Logo URL")]
        [Required(ErrorMessage = "Cinema logo URL is required.")]
        public string CinemaLogoURL { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "The address is required.")]
        public string Address { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
