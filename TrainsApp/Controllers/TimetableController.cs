using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainsApp.DAL;
using TrainsApp.Models.DB;

namespace TrainsApp.Controllers
{
    public class TimetableController : Controller
    {
        private readonly TrainDBContext _context = new TrainDBContext();
        // GET: Timetable
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Timetable model)
        {
           
            if (ModelState.IsValid)
            {
                _context.Timetables.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "Timetable");
            }
            return View("Index");
        }
        public ActionResult Change()
        {
            return View("Index");
        }
    }
}