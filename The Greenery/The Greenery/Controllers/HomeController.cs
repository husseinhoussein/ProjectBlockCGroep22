using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace The_Greenery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Message = "Oprecht en eerlijk en daarom gegarandeerd het EKO-keurmerk.";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult AlgemeneVoorwaarden()
        {
            return View();
        }

        public ActionResult Privacypolicy()
        {
            return View();
        }
        public ActionResult Registreer()
        {
            return View();
        }
        public ActionResult geregistreerd()
        {
            return View();
        }
        public ActionResult Zoekresultaten()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            return View();
        
        }
        public ActionResult LentePage()
        { 
        
            return View();
        }

        public ActionResult ZomerPage()
        {

            return View();
        }

        public ActionResult HerfstPage()
        {

            return View();
        }
        public ActionResult WinterPage()
        {

            return View();
        }

        public ActionResult Winkelwagen()
        {
            return View();
        }
    }
}
