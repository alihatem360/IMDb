using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Movie_project.Models;

namespace Final_Movie_project.ViewModel
{
    public class Movie_Diretor_View_Model
    {
        public Movie Movie { get; set; }
        public List<Actor> Actor { get; set; }
        public List<Director> Director { get; set; }

    }
}