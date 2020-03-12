using Spectra.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spectra.Sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<User> users = new List<User>
            {
                new User{ID = 1, Name = "Ahmet", CreateDate = new DateTime(2019,5,15)},
                new User{ID = 2, Name = "Mehmet", CreateDate = new DateTime(2019,5,15)},
                new User{ID = 3, Name = "Ayşe", CreateDate = new DateTime(2019,5,15)}
            };
            return View(users);
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