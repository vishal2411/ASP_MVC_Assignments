using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_EntityFramework_Assignment1.Models;

namespace MVC_EntityFramework_Assignment1.Controllers
{      
    public class FootballLeaguesController : Controller
    {
        private FootBallContext db = new FootBallContext();

        // GET: FootballLeagues
        public ActionResult Index()
        {
            return View(db.FootballLeagues.SqlQuery("Select * From FootBallLeague where MatchStatus = 'Win'").ToList());
        }

        // GET: FootballLeagues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootballLeague footballLeague = db.FootballLeagues.Find(id);
            if (footballLeague == null)
            {
                return HttpNotFound();
            }
            return View(footballLeague);
        }

        // GET: FootballLeagues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FootballLeagues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchID,TeamName1,TeamName2,MatchStatus,WinningTeam,Points")] FootballLeague footballLeague)
        {
            if (ModelState.IsValid)
            {
                db.FootballLeagues.Add(footballLeague);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footballLeague);
        }

        // GET: FootballLeagues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootballLeague footballLeague = db.FootballLeagues.Find(id);
            if (footballLeague == null)
            {
                return HttpNotFound();
            }
            return View(footballLeague);
        }

        // POST: FootballLeagues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchID,TeamName1,TeamName2,MatchStatus,WinningTeam,Points")] FootballLeague footballLeague)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footballLeague).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footballLeague);
        }

        // GET: FootballLeagues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootballLeague footballLeague = db.FootballLeagues.Find(id);
            if (footballLeague == null)
            {
                return HttpNotFound();
            }
            return View(footballLeague);
        }

        // POST: FootballLeagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FootballLeague footballLeague = db.FootballLeagues.Find(id);
            db.FootballLeagues.Remove(footballLeague);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
