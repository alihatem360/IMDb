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
    public class MovieController : Controller
    {
        /// <summary>
        ///  instance of DataContext 
        /// </summary>
        DataContext MovieDataContext = new DataContext();

        // GET: Movie
        [HttpGet]
        public ActionResult Index()
        {
            List<Movie> Movies = MovieDataContext.Movies.ToList();
            return View(Movies);
        }


        // Get Create New Movie
        [HttpGet]
        public ActionResult CreateNewMovie()
        {
            var DirectoData = MovieDataContext.Directors.ToList();
            Movie_Diretor_View_Model MDVM = new Movie_Diretor_View_Model
            {
                Director = DirectoData,
            };

            return View(MDVM);
        }


        [HttpPost]
        public ActionResult CreateNewMovie(Movie_Diretor_View_Model MovieDirectorViewModel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/images/profiles/"), pic);

                    file.SaveAs(path);

                    MovieDirectorViewModel.Movie.Image = pic;
                }
                MovieDataContext.Movies.Add(MovieDirectorViewModel.Movie);
                MovieDataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // ========== start of  MovieDetails ===========================
        public ActionResult MovieDetails(int id)
        {
            var Movie = MovieDataContext.Movies.SingleOrDefault(x => x.MovieId == id);
            
            if (Movie == null)
            {
                return HttpNotFound();
            }
            return View(Movie);
        }

        // ========== End  of  MovieDetails ===========================



///======================== start of GET  Movie Edite 
        [HttpGet]
        public ActionResult MovieEdit(int? id)
        {
            if (id != null)
            {
                var Movie = MovieDataContext.Movies.SingleOrDefault(a => a.MovieId == id);
                if (Movie == null)
                {
                    return HttpNotFound();
                }

                var DirectorList = MovieDataContext.Directors.ToList();

                Movie_Diretor_View_Model MovieDiretorView = new Movie_Diretor_View_Model
                {
                   Movie = Movie,
                   Director = DirectorList ,

                };

                return View(MovieDiretorView);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public ActionResult MovieEdit(Movie_Diretor_View_Model MovieDirectorViewModel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var movie = MovieDataContext.Movies.SingleOrDefault(a => a.MovieId == MovieDirectorViewModel.Movie.MovieId);

                movie.MovieName = MovieDirectorViewModel.Movie.MovieName;
                movie.DirectortId = MovieDirectorViewModel.Movie.DirectortId;

                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/images/profiles/"), pic);

                    file.SaveAs(path);

                    movie.Image = pic;
                }
                MovieDataContext.Entry(movie).State = EntityState.Modified;
                MovieDataContext.SaveChanges();

                return RedirectToAction("MovieDetails", new { id = movie.MovieId });
            }
            return View();
        }


        //////// Delete 
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Movieitem = MovieDataContext.Movies.Single(x => x.MovieId == id);
            MovieDataContext.Movies.Remove(Movieitem);
            MovieDataContext.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}