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
        [HttpPost]
        public ActionResult Registreer(FormCollection formcolletion)
        {
            foreach (String key in formcolletion.AllKeys)
            {
                Klant klant = new Klant();
                klant.voorletters = formcolletion["voorletters"];
                klant.tussenvoegsel = formcolletion["tussenvoegsel"];
                klant.achternaam = formcolletion["achternaam"];
                klant.adres = formcolletion["adres"];
                klant.postcode = formcolletion["postcode"];
                klant.woonplaats = formcolletion["woonplaats"];
                klant.telefoonnummer = formcolletion["telefoonnummer"];
                klant.email = formcolletion["email"];
                klant.wachtwoord = formcolletion["wachtwoord"];
                klant.wachtwoord_herhalen = formcolletion["wachtwoord_herhalen"];

                RegistrerenDBController registrerencontroller = new RegistrerenDBController();
                registrerencontroller.InsertRegistratie(klant);


            }
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

    }
}
