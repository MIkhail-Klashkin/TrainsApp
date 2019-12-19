using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TrainsApp.DAL;
using TrainsApp.Models.ViewModel;

namespace TrainsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrainDBContext _context = new TrainDBContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userInDB = _context.Users.FirstOrDefault(user => user.Username == model.Username && user.Password == model.Password);

                if (userInDB != null)
                {
                  // FormsAuthentication.SetAuthCookie(model.Nickname, model.RememberMe);
                    Session["UserId"] = userInDB.Id.ToString();
                    Session["UserNick"] = userInDB.Username;
                    return RedirectToAction("Index", "Feed");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Неверный псевдоним или пароль!");
                }
            }
            return View("Index", model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}