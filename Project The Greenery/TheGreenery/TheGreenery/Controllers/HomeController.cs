using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGreenery.DBcontrollers;
using TheGreenery.Models;

namespace TheGreenery.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult ShowProduct(String naam)
        {
            ProductController sc = new ProductController();
            List<Product> producten = sc.getAllProductenByNaam(naam);
            return View(producten);
        }

        public ActionResult Index()
        {
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
