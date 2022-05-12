using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Movie_project.Models
{
    public class Actor
    {

        [Key]
        [Required]
        public int ActorId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        public int Age { get; set; }


        //Relationships
        public virtual ICollection<ActorMovie> ActorMovie { get; set; }



    }
}