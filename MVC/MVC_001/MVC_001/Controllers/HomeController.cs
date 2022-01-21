using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_001.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // ViewData ile View'e veri taşıma
            ViewData["studentID"] = 10;
            ViewData["studentName"] = "Jane";
            ViewData["studentSurname"] = "Doe";

            List<int> sayilar = new List<int>() { 15, 25, 35, 67, 89 };
            ViewData["numbers"] = sayilar;

            // ViewBag ile View'e veri taşıma
            ViewBag.teacherID = 1;
            ViewBag.teacherName = "Serdar";

            // TempData ile View'e ve Action'a veri taşıma!!!!
            TempData["degisken"] = "Tempdatadan herkese selamlar.";

            return View(); // /Views/Home/Index.cshtml'i çalıştır.
        }

        public ActionResult Logout()
        {
            ViewBag.exitvb = "ViewBag ile Action'a veri gitmeeeeez!!!";
            ViewData["exitvd"] = "ViewBag ile Action'a veri gitmeeeeez!!!";

            TempData["exit"] = "ÇIKIŞ YAPILDI!!!";
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View(); // /Views/Home/About.cshtml'i çalıştır.
        }
    }
}