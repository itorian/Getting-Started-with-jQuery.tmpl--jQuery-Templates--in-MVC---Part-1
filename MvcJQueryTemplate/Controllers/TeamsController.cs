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
    public class TeamsController : Controller
    {
        private IPLContext db = new IPLContext();

        //
        // GET: /Teams/

        public ViewResult Index()
        {
            return View(db.Teams.Include(team => team.Players).ToList());
        }

        public ViewResult TeamAndPlayer()
        {
            return View();
        }

        public JsonResult RequestData()
        {
            var data = db.Teams.ToList();

            var collection = data.Select(x => new
            {
                x.TeamId,
                x.Name,
                x.City,
                x.Founded,
                Players = x.Players.Select(item => new
                {
                    item.PlayerId,
                    item.Name,
                    item.TotalScored,
                    item.TeamId
                })
            });

            return Json(collection, JsonRequestBehavior.AllowGet);
        }


        //
        // GET: /Teams/Details/5

        public ViewResult Details(int id)
        {
            Team team = db.Teams.Single(x => x.TeamId == id);
            return View(team);
        }

        //
        // GET: /Teams/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Teams/Create

        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(team);
        }
        
        //
        // GET: /Teams/Edit/5
 
        public ActionResult Edit(int id)
        {
            Team team = db.Teams.Single(x => x.TeamId == id);
            return View(team);
        }

        //
        // POST: /Teams/Edit/5

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        //
        // GET: /Teams/Delete/5
 
        public ActionResult Delete(int id)
        {
            Team team = db.Teams.Single(x => x.TeamId == id);
            return View(team);
        }

        //
        // POST: /Teams/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = db.Teams.Single(x => x.TeamId == id);
            db.Teams.Remove(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}