using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGreenery.DBcontrollers;
using TheGreenery.Models;
using MySql.Data.MySqlClient;

namespace TheGreenery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(String aanbieding)
        {

            AanbiedingDBController sc = new AanbiedingDBController();
            List<Product> producten = sc.getAllProductenByAanbieding(aanbieding);
            return View(producten);
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

        public ActionResult FAQ()
        {
            return View();

        }

        public ActionResult Winkelwagen()
        {
            return View();
        }


        


        public ActionResult Beheerder()
        {
            return View();
        }




    }
}
