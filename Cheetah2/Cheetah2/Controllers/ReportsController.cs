using Cheetah2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Cheetah2.Views.Reports
{
    public class ReportsController : Controller
    {
        
        // GET: Reports
        public ActionResult Index()
        {
            ScheduleDBModel schedule = new ScheduleDBModel();
            SemListDBModel semlist = new SemListDBModel();
            ViewBag.SemList = new SelectList(semlist.SemesterLists, "Semester", "Semester");
            var SchedulesList = schedule.Schedules.Where(x => x.Semester == "zzz").ToList();

            return View(SchedulesList);

        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection ScheduleReport, string SelectedSemester)
        {
            ScheduleDBModel schedule = new ScheduleDBModel();

            //SemListDBModel semlist = new SemListDBModel();
            //ViewBag.SemList = new SelectList(semlist.SemesterLists, "Semester", "Semester");

            var SchedulesList = schedule.Schedules.Where(x => x.Semester == SelectedSemester).ToList();
            string TitleString = SelectedSemester + " Schedule:";
            var pdf = new RazorPDF.PdfResult(SchedulesList, "PDF");
            pdf.ViewBag.Title = TitleString;
            return pdf;
           // string path = Server.MapPath("~/Reports/");
            //string filename = path + "SemesterSchdule.pdf";

            //Document document = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            //ViewBag.Selected = SelectedSemester;
            //return View(SchedulesList);
        }

        


    }

    
}