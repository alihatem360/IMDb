using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Movie_project.Models;

namespace Final_Movie_project.ViewModel
{
    public class Director_movie_view_model
    {
        public Director Director { get; set; }
        public List<Movie> Movie { get; set; }

    
    }
}