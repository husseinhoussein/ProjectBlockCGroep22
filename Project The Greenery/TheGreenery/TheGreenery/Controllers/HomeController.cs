using System;
using System.Collections.Generic;
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
        //
        // GET: /Home/

        public ActionResult ShowProduct(String naam)
        {
            ProduchtDBController sc = new ProduchtDBController();
            List<Product> producten = sc.getAllProductenByNaam(naam);
            return View(producten);
        }

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
        
        
       //[HttpGet]
        public ActionResult Registreer(Klant klant)
        {
            //RegistrerenDBController registrerenController = new RegistrerenDBController();
            //registrerenController.InsertRegistratie(klant);
            return View();
        }
       
           

      
        public ActionResult geregistreerd(Klant klant)
        {
            RegistrerenDBController registrerenController = new RegistrerenDBController();
            registrerenController.InsertRegistratie(klant);
            
            return View();
        }
        

        public ActionResult FAQ()
        {
            return View();

        }
        public ActionResult LentePage(String lente)
        {

            LenteDBController sc = new LenteDBController();
            List<Product> producten = sc.getAllProductenBylente(lente);
            return View(producten);
        }

        public ActionResult ZomerPage(String zomer)
        {

            ZomerDBController sc = new ZomerDBController();
            List<Product> producten = sc.getAllProductenBylente(zomer);
            return View(producten);
        }

        public ActionResult HerfstPage(String herfst)
        {

            HerfstDBController sc = new HerfstDBController();
            List<Product> producten = sc.getAllProductenBylente(herfst);
            return View(producten);
        }
        public ActionResult WinterPage(String winter)
        {

            WinterDBController sc = new WinterDBController();
            List<Product> producten = sc.getAllProductenBylente(winter);
            return View(producten);
        }

        public ActionResult Winkelwagen()
        {
            return View();
        }



        public ActionResult MijnGegevens(int? bestellingnr)
        {
            MijnGegevensDBController sc = new MijnGegevensDBController();
            List<Bestelling> bestellingen = sc.getAllBestellingenByDate(bestellingnr);
            return View(bestellingen);



        }


        public ActionResult Pakketten()
        {
            return View();
        }


    }
}
