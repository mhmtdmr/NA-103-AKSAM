using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_001.DataAccess;
using MVC_001.ModelBase;
using MVC_001.Models;   // Models altındaki sınıfları kullanacağız.
using MVC_001.Security;

namespace MVC_001.Controllers
{
    public class StudentController : Controller
    {        
        //public ActionResult Index_Old()
        //{   // model yolu ile View'e veri gönderme

        //    Student stdnt = new Student()
        //    {
        //        ID = 99,
        //        Name = "Burak",
        //        Surname = "Yılmaz"
        //    };

        //    return View(stdnt);// /Views/Student/Index.cshtml'i çalıştır.
        //}
        public ActionResult Index()
        {
            List<Student> students = StudentDAL.Methods.List();

            return View(students);
        }

        public ActionResult About()
        {
            return RedirectToAction("Index"); // Yukarıdaki Index controller'ına yönlendir.
        }


        // Yeni öğrenci kayıt formunu göster.
        
        [CustomAuthorize(Roles="teacher")]
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
        public ActionResult Edit(int id)
        {
            return View(StudentDAL.Methods.GetByID(id));
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            int affectedRows = StudentDAL.Methods.Update(student);
            if (affectedRows > 0)
                TempData["editmessage"] = "Edit successfull!!!";
            else    
                TempData["editmessage"] = "Error on edit!!!";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(StudentDAL.Methods.GetByID(id));
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(StudentDAL.Methods.GetByID(id));
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            int affectedRows = StudentDAL.Methods.Delete(student.ID);
            if (affectedRows > 0)
                TempData["deletemessage"] = "Delete successfull!!!";
            else
                TempData["deletemessage"] = "Error on delete!!!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(string searchterm)
        {
            List<Student> searchedStudents = StudentDAL.Methods.Search(searchterm);
            return View(searchedStudents);
        }


        public ActionResult Login(string returnUrl="/Student/Index")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password,string returnUrl)
        {
            Student std = StudentDAL.Methods.Login(email, password);
            //FormsAuthentication.SetAuthCookie("userlogin", false);
            Role rl = std.Role;
            
            if(std.ID==0) // nesne boş ise
            {
                ViewBag.Error = "Login failed.";
                return View("Login");
            }
            SessionPersister.Email = std.Email;
            return Redirect(returnUrl);
        }
    }
}