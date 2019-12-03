using Checkpoint4.DAL;
using Checkpoint4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Checkpoint4.Controllers
{
    public class HomeController : Controller
    {
        BlowOutContext db = new BlowOutContext();

        public ActionResult Login()
        {
            return View();
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String Username = form["Username"].ToString();
            String password = form["Password"].ToString();

            if (string.Equals(Username, "Missouri") && (string.Equals(password, "ShowMe")))
            {
                FormsAuthentication.SetAuthCookie(Username, rememberMe);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<Instrument> instruments = db.Database.SqlQuery<Instrument>("SELECT * FROM Instrument");
            return View(instruments);
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

        public ActionResult Rentals()
        {
            return View(db.Instruments.ToList());
        }
    }
}