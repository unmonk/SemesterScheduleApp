using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Cheetah2.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace Cheetah2.Controllers
{
    
    public class UserController : Controller
    { 
        private ScheduleDBModel db = new ScheduleDBModel();
        private ScheduleDBModel db2 = new ScheduleDBModel();

        // GET: User
        public ActionResult Index()
        {
            ProfessorsDBModel profdb = new ProfessorsDBModel();
            ViewBag.Professors = new SelectList(profdb.Professors, "LastName", "LastName");

            CoursesDBModel2 corsdb = new CoursesDBModel2();
            ViewBag.Courses = new SelectList(corsdb.Courses, "CourseName", "CourseName");

            sweaver_cheetahEntities roomsdb = new sweaver_cheetahEntities();
            ViewBag.Rooms = new SelectList(roomsdb.Rooms, "Location", "Location");

            SemListDBModel semlist = new SemListDBModel();
            ViewBag.SemList = new SelectList(semlist.SemesterLists, "Semester", "Semester");
     
            ViewBag.Section = Sections;

            return View();
        }
        


        public static List<SelectListItem> Sections = new List<SelectListItem>()
        {
            new SelectListItem() {Text="1", Value="1" },
            new SelectListItem() {Text="2", Value="2" },
            new SelectListItem() {Text="3", Value="3" },
            new SelectListItem() {Text="4", Value="4" },
            new SelectListItem() {Text="5", Value="5" },

        };

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Semester,Course,Section,Location,TimeIn,TimeOut,Days,Professor")] Schedule schedule)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    db.Schedules.Add(schedule);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Could not save.");
            }

            return View(schedule);
        }

        

    }

   
}