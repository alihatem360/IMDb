using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Movie_project.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Movie Name")]
        public String MovieName { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")] 
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Movie Image")]
        public string Image { get; set; }


        /// <summary>
        /// Relationships
        /// </summary>
        [ForeignKey("Director")]
        public int DirectortId { get; set; }
        public virtual Director Director { get; set; }

        public virtual ICollection<ActorMovie> ActorMovie { get; set; }



    }
}