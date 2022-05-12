using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Movie_project.Context;
using Final_Movie_project.Models;

namespace Final_Movie_project.Controllers
{
    public class HomeController : Controller
    {
        DataContext MovieDataContext = new DataContext();

        public ActionResult Index()
        {
            List<Movie> Movies = MovieDataContext.Movies.ToList();
            return View(Movies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}