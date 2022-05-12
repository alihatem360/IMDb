using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Movie_project.Context;
using Final_Movie_project.Models;

namespace Final_Movie_project.Controllers
{
    public class DirectorController : Controller
    {
        // GET: Director
        //private readonly DataContext _context;

        //public DirectorController(DataContext context)
        //{
        //    _context = context;

        //}
        //public ActionResult Index()
        //{
        //    List<Director> AllDirectors = _context.Directors.ToList();
        //    return View(AllDirectors);
        //}


        DataContext _context = new DataContext();

        // GET: Movie
        [HttpGet]
        public ActionResult Index()
        {
            List<Director> AllDirectors = _context.Directors.ToList();
            return View(AllDirectors);
        }



    }
}