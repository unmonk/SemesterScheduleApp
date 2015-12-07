using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cheetah2.Models;


namespace Cheetah2.Views
{
    public class SchedulesController : Controller
    {
        private ScheduleDBModel db = new ScheduleDBModel();
        
        // GET: Schedules
        public ActionResult Index()
        {
            SemListDBModel semlist = new SemListDBModel();
            ViewBag.SemList = new SelectList(semlist.SemesterLists, "Semester", "Semester");
            var SchedulesList = db.Schedules.Where(x => x.Semester == "zzz").ToList();
            
            return View(SchedulesList);
            //return View(db.Schedules.OrderBy(x=> x.Semester).ToList());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection ScheduleSelect, string SelectedSemester)
        {
            ScheduleDBModel schedule = new ScheduleDBModel();

            SemListDBModel semlist = new SemListDBModel();
            ViewBag.SemList = new SelectList(semlist.SemesterLists, "Semester", "Semester");

            var SchedulesList = schedule.Schedules.Where(x => x.Semester == SelectedSemester).ToList();
            return View(SchedulesList);
        }


        // GET: Schedules/Details/5
        public ActionResult Details(string Semester, string Course, string Section)
        {
            if (Semester  == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(Semester, Course, Section);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Semester,Course,Section,Location,TimeIn,TimeOut,Days,Professor")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public ActionResult Edit(string Semester, string Course, string Section)
        {
            if (Semester == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(Semester, Course, Section);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Semester,Course,Section,Location,TimeIn,TimeOut,Days,Professor")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public ActionResult Delete(string Semester, string Course, string Section)
        {
            if (Semester == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(Semester, Course, Section);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string Semester, string Course, string Section)
        {
            Schedule schedule = db.Schedules.Find(Semester, Course, Section);
            db.Schedules.Remove(schedule);
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
