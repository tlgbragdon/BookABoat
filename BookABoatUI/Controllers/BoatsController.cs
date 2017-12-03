using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookABoat;

namespace BookABoatUI.Controllers
{
    public class BoatsController : Controller
    {
        private BoathouseRowModel db = new BoathouseRowModel();

        // GET: Boats
        [Authorize]
        public ActionResult Index()
        {
            var userName = HttpContext.User.Identity.Name;
            //TODO: this needs to be based on the logged in user
            //var rower = Registrar.GetRowerByEmailAddress(userName);
            //if (rower == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var boats = BoathouseManager.GetAllActiveBoatsForSkillLevel(rower.ApprovedSkillLevel);
            var boats = BoathouseManager.GetAllActiveBoats();
            return View(boats);
        }

        // GET: Boats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boat boat = BoathouseManager.GetBoatById(id.Value);
            if (boat == null)
            {
                return HttpNotFound();
            }
            return View(boat);
        }

        // GET: Boats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Type,WeightClass,MinSkillLevelRequired,IsActive,Make,YearOfManufacture,DateAquired")] Boat boat)
        {
            if (ModelState.IsValid)
            {
                BoathouseManager.AddBoatToFleet(boat.Name, boat.Type, boat.Make, Convert.ToInt32(boat.YearOfManufacture), Convert.ToDateTime(boat.DateAquired), boat.WeightClass, boat.MinSkillLevelRequired);
                return RedirectToAction("Index");
            }

            return View(boat);
        }

        // GET: Boats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boat boat = BoathouseManager.GetBoatById(id.Value);
            if (boat == null)
            {
                return HttpNotFound();
            }
            return View(boat);
        }

        // POST: Boats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,WeightClass,MinSkillLevelRequired,DateAquired,Make,YearOfManufacture")] Boat boat)
        {
            if (ModelState.IsValid)
            {
                BoathouseManager.EditBoat(boat);
                return RedirectToAction("Index");
            }
            return View(boat);
        }

        // GET: Boats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boat boat = db.Boats.Find(id);
            if (boat == null)
            {
                return HttpNotFound();
            }
            return View(boat);
        }

        // POST: Boats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boat boat = db.Boats.Find(id);
            db.Boats.Remove(boat);
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
