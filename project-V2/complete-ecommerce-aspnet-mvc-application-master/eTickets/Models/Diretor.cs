using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Diretor:CSEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Director Logo")]
        [Required(ErrorMessage = "Director logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Director Name")]
        [Required(ErrorMessage = "Director name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Director description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
