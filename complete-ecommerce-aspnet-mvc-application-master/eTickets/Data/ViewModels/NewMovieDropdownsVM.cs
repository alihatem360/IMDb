﻿using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Diretor>();
            Actors = new List<Actor>();
        }

        public List<Producer> Producers { get; set; }
        public List<Diretor> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}