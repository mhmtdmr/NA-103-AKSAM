using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC_001.Models;   // Models altındaki sınıfları kullanacağız.

namespace MVC_001.Controllers
{
    public class StudentController : Controller
    {
        
        public ActionResult Index()
        {   // model yolu ile View'e veri gönderme

            Student stdnt = new Student()
            {
                ID = 99,
                Name = "Burak",
                Surname = "Yılmaz"
            };

            return View(stdnt);// /Views/Student/Index.cshtml'i çalıştır.
        }

        public ActionResult About()
        {
            return RedirectToAction("Index"); // Yukarıdaki Index controller'ına yönlendir.
        }
    }
}