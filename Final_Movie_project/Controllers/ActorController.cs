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
        // Get Create New Movie

        [HttpGet]
        public ActionResult CreateNewActor()
        {
            return View();

        }


        [HttpPost]
        public ActionResult CreateNewActor(Actor ActorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Actors.Add(ActorModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        // ========== start of  ActorDetails ===========================
        public ActionResult ActorDetails(int id)
        {
            var Actor = _context.Actors.SingleOrDefault(x => x.ActorId == id);
            if (Actor == null)
            {
                return HttpNotFound();
            }
            return View(Actor);
        }

        // ========== End  of  ActorDetails ===========================


        ///======================== start of GET  Actor Edite 
        [HttpGet]
        public ActionResult EditActor(int? id)
        {
            if (id != null)
            {
                var Actor = _context.Actors.SingleOrDefault(a => a.ActorId == id);
                if (Actor == null)
                {
                    return HttpNotFound();
                }
                
                return View(Actor);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //////// End Of Actor Edit



        [HttpPost]
        public ActionResult EditActor(Actor ActorViewModel)
        {
            if (ModelState.IsValid)
            {
                var Actor = _context.Actors.SingleOrDefault(a => a.ActorId == ActorViewModel.ActorId);

                Actor.FirstName = ActorViewModel.FirstName;
                Actor.LastName = ActorViewModel.LastName;
                Actor.Age = ActorViewModel.Age;
                Actor.ActorId = ActorViewModel.ActorId;

                _context.Entry(Actor).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("ActorDetails", new { id = Actor.ActorId });
            }
            return View();
        }


        //////// Delete 
        [HttpGet]
        public ActionResult DeleteActor(int id)
        {
            var ActorItem = _context.Actors.Single(x => x.ActorId == id);
            _context.Actors.Remove(ActorItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}