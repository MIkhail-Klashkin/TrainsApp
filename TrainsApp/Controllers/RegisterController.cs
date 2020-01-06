using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainsApp.DAL;
using TrainsApp.Models;

namespace TrainsApp.Controllers
{
    public class RegisterController : Controller
    {

        // GET: Register
        private readonly TrainDBContext _context = new TrainDBContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserDB model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.PasswordConfirm)
                    ModelState.AddModelError(String.Empty, "Пароли не совпадают!");

                var userInDB = _context.Users.FirstOrDefault(user => user.Username == model.Username);
                if (userInDB != null)
                    ModelState.AddModelError(String.Empty, "Пользователь с таким псевдонимом уже существует!");

                if (!ModelState.IsValid)
                {
                    return View("Index", model);
                }

                _context.Users.Add(model);
                _context.SaveChanges();

                Session["UserId"] = model.Id.ToString();
                Session["UserNick"] = model.Username;
                return RedirectToAction("Index", "Timetable");
            }
            return View("Index");
        }
    }
}