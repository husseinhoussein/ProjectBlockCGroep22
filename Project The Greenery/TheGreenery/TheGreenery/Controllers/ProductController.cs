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
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowProduct(String naam)
        {
            ProduchtDBController sc = new ProduchtDBController();
            List<Product> producten = sc.getAllProductenByNaam(naam);
            return View(producten);
        }

        public ActionResult LentePage(String lente)
        {

            LenteDBController sc = new LenteDBController();
            List<Product> producten = sc.getAllProductenByLente(lente);
            return View(producten);
        }

        public ActionResult ZomerPage(String zomer)
        {

            ZomerDBController sc = new ZomerDBController();

            List<Product> producten = sc.getAllProductenByZomer(zomer);
<<<<<<< HEAD
=======

>>>>>>> origin/master
            return View(producten);
        }

        public ActionResult HerfstPage(String herfst)
        {

            HerfstDBController sc = new HerfstDBController();
<<<<<<< HEAD
            List<Product> producten = sc.getAllProductenByHerfst(herfst);

=======


            List<Product> producten = sc.getAllProductenByHerfst(herfst);

>>>>>>> origin/master
            return View(producten);
        }
        public ActionResult WinterPage(String winter)
        {

            WinterDBController sc = new WinterDBController();
<<<<<<< HEAD
            List<Product> producten = sc.getAllProductenByWinter(winter);
=======

            List<Product> producten = sc.getAllProductenByWinter(winter);

>>>>>>> origin/master
            return View(producten);
        }

    }
}
