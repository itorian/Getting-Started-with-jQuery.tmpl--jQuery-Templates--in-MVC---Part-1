using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcJQueryTemplate.Models;

namespace MvcJQueryTemplate.Controllers
{   
    public class PlayersController : Controller
    {
        private IPLContext context = new IPLContext();

        //
        // GET: /Players/

        public ViewResult Index()
        {
            return View(context.Players.Include(player => player.Team).ToList());
        }

        //
        // GET: /Players/Details/5

        public ViewResult Details(int id)
        {
            Player player = context.Players.Single(x => x.PlayerId == id);
            return View(player);
        }

        //
        // GET: /Players/Create

        public ActionResult Create()
        {
            ViewBag.PossibleTeams = context.Teams;
            return View();
        } 

        //
        // POST: /Players/Create

        [HttpPost]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                context.Players.Add(player);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleTeams = context.Teams;
            return View(player);
        }
        
        //
        // GET: /Players/Edit/5
 
        public ActionResult Edit(int id)
        {
            Player player = context.Players.Single(x => x.PlayerId == id);
            ViewBag.PossibleTeams = context.Teams;
            return View(player);
        }

        //
        // POST: /Players/Edit/5

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                context.Entry(player).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleTeams = context.Teams;
            return View(player);
        }

        //
        // GET: /Players/Delete/5
 
        public ActionResult Delete(int id)
        {
            Player player = context.Players.Single(x => x.PlayerId == id);
            return View(player);
        }

        //
        // POST: /Players/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = context.Players.Single(x => x.PlayerId == id);
            context.Players.Remove(player);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}