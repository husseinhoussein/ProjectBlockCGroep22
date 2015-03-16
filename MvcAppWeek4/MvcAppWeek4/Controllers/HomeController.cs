using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAppWeek4.Models;
using MvcAppWeek4.DatabaseControllers;

namespace MvcAppWeek4.Controllers
{
    public class HomeController : Controller
    {
        // tralala
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchStudent()
        {
            return View();
        }

        public ActionResult ShowStudents(String achternaam)
        {
            StudentController sc = new StudentController();
            List<Student> studenten = 
                sc.getAllStudentsByAchternaam(achternaam);
            
            return View(studenten);
        }

    }
}
