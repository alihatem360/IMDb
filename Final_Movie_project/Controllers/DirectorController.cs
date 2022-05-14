using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Movie_project.Context;
using Final_Movie_project.Models;
using Final_Movie_project.ViewModel;

namespace Final_Movie_project.Controllers
{
    public class DirectorController : Controller
    {

        DataContext _context = new DataContext();

        // GET: Movie
        [HttpGet]
        public ActionResult Index()
        {
            List<Director> AllDirectors = _context.Directors.ToList();

            return View(AllDirectors);
        }


        // Get Create New Movie

        [HttpGet]
        public ActionResult CreateNewDirector()
        {
            //var MovieList = _context.Movies.ToList();
            //Director_movie_view_model DirectorMovieView = new Director_movie_view_model
            //{
            //    Movie = MovieList,
            //};

            //return View(DirectorMovieView);
            return View();

        }

        /// CreateNewDirector HTTp Post
        /// 

        [HttpPost]
        public ActionResult CreateNewDirector(Director_movie_view_model DirectorMovieViewModel)
        {
            if (ModelState.IsValid)
            {

                _context.Directors.Add(DirectorMovieViewModel.Director);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        // ========== start of  DirectorDetails ===========================
        public ActionResult DirectorDetails(int id)
        {
            var Director = _context.Directors.SingleOrDefault(x => x.DirectorId == id);
            if (Director == null)
            {
                return HttpNotFound();
            }
            return View(Director);
        }

        // ========== End  of  DirectorDetails ===========================


        ///======================== start of GET  Director Edite 
        [HttpGet]
        public ActionResult EditDirector(int? id)
        {
            if (id != null)
            {
                var Director = _context.Directors.SingleOrDefault(a => a.DirectorId == id);
                if (Director == null)
                {
                    return HttpNotFound();
                }

                //var MovieList = _context.Movies.ToList();

                Director_movie_view_model DiretorMovieView = new Director_movie_view_model
                {
                    //Movie = MovieList,
                    Director = Director,

                };

                return View(DiretorMovieView);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        //////// End Of Director Edit


        [HttpPost]
        public ActionResult EditDirector(Director_movie_view_model DirectorMovieViewModel)
        {
            if (ModelState.IsValid)
            {
                var Director = _context.Directors.SingleOrDefault(a => a.DirectorId == DirectorMovieViewModel.Director.DirectorId);

                Director.Fname = DirectorMovieViewModel.Director.Fname;
                Director.Lname = DirectorMovieViewModel.Director.Lname;
                Director.Age = DirectorMovieViewModel.Director.Age;
                Director.DirectorId = DirectorMovieViewModel.Director.DirectorId;

                _context.Entry(Director).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("DirectorDetails", new { id = Director.DirectorId });
            }
            return View();
        }

        //////// Delete 
        [HttpGet]
        public ActionResult DeleteDirector(int id)
        {
            var DirectorItem = _context.Directors.Single(x => x.DirectorId == id);
            _context.Directors.Remove(DirectorItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}