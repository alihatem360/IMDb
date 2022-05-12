using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Movie_project.Context;
using Final_Movie_project.Models;

namespace Final_Movie_project.Controllers
{
    public class ActorController : Controller
    {

        DataContext _context = new DataContext();

        // GET: Movie
        [HttpGet]
        public ActionResult Index()
        {
            List<Actor> AllActos = _context.Actors.ToList();
            return View(AllActos);
        }
    }
}