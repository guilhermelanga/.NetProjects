using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage ="The type is required.")]
        public string Type { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
