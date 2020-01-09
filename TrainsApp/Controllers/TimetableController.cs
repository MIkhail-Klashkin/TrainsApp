using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainsApp.DAL;
using TrainsApp.Models.DB;
using TrainsApp.Models.ViewModel;

namespace TrainsApp.Controllers
{
    public class TimetableController : Controller
    {
        private readonly TrainDBContext _context = new TrainDBContext();
        private static TimetableViewModel timetableView;
    //    private static List<Timetable> timetables;
        // GET: Timetable
        public ActionResult Index(/*int id*/)
        {
            
            //Timetable model = _context.Timetables.First(c => c.Id == id);
            //timetables = _context.Timetables.Where(c => c.Id == model.Id).ToList();
            Update();
            return View();
        }
        
        [HttpPost]
        public ActionResult AddTimetable(TimetableViewModel model)
        {
            //View("Add");
            timetableView = model;
            Update();
            if (!ModelState.IsValid) { return View("Index", model); }
           
            Timetable timetable = new Timetable
            {
                TrainNumber = model.TrainNumber,
                Way = model.Way,
                Platform = model.Platform,
                Destination = model.Destination,
                DepartureTime = model.DepartureTime,
                ArrivalTime = model.ArrivalTime,
                Type = model.Type,
                WagonCount = model.WagonCount
            };
            
                _context.Timetables.Add(timetable);
                _context.SaveChanges();
               // ViewBag.Timetables.Add(timetable);
                return RedirectToAction("Index", "Timetable");
        }
        public ActionResult SelectType()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Пассажирский", Value = "Пассажирский" });

            items.Add(new SelectListItem { Text = "Товарный", Value = "Товарный" });

            items.Add(new SelectListItem { Text = "Электропоезд", Value = "Электропоезд"});

            ViewBag.Type = items;
            return View("Index");
        }
        [HttpPost]
        public ActionResult ChangeTimetable(TimetableViewModel model)
        {
            timetableView = model;
            Update();
            var timetableInDb = _context.Timetables.First(timetable => timetable.Id == model.Id);
            if (ModelState.IsValid)
            { 
                timetableInDb.TrainNumber = model.TrainNumber;
                timetableInDb.Way = model.Way;
                timetableInDb.Platform = model.Platform;
                timetableInDb.Destination = model.Destination;
                timetableInDb.DepartureTime = model.DepartureTime;
                timetableInDb.ArrivalTime = model.ArrivalTime;
                timetableInDb.Type = model.Type;
                timetableInDb.WagonCount = model.WagonCount;
                _context.SaveChanges();
                return View("Index", model);
            }
            return View("Index", model);
        }

        public ActionResult Change()
        {
            SelectType();
            return View();
        }
        public ActionResult Add()
        {
            SelectType();
            return View();
        }
        private void Update()
        {
            var timetables = _context.Timetables.ToList();
            ViewBag.TimetableView = timetableView;
            ViewBag.Timetables = timetables;
        }
    }
}