﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_001.DataAccess;

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
        public ActionResult List()
        {
            List<Student> students = StudentDAL.Methods.List();

            return View(students);
        }

        public ActionResult About()
        {
            return RedirectToAction("Index"); // Yukarıdaki Index controller'ına yönlendir.
        }

        // Yeni öğrenci kayıt formunu göster.
        public ActionResult Add()
        {
            Student newStudent = new Student();
            return View(newStudent);
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            
            TempData["insertedID"] = StudentDAL.Methods.Add(student);
            return RedirectToAction("Index");
        }
    }
}