using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Movie_project.Models
{
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "the string length must be 50")]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Second Name")]
        public string Lname { get; set; }

        [Required]
        public int Age { get; set; }



        /// <summary>
        /// Relationships
        /// </summary>
        public virtual ICollection<Movie> Movie { get; set; }




    }
}