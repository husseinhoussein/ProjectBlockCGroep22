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

        [HttpGet]
        public ActionResult Registreer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registreer
            //(FormCollection formCollection)
            
            
            (String voorletters, String tussenvoegsel, String achternaam, String adres, String postcode, String woonplaats, String telefoonnr, String mail, String wachtwoord, String wachtwoord_herhalen )
            {
            
            Klant klant = new Klant();
            klant.voorletters = voorletters;
            klant.tussenvoegsel = tussenvoegsel;
            klant.achternaam = achternaam;
            klant.adres = adres;
            klant.postcode = postcode;
            klant.woonplaats = woonplaats;
            klant.telefoonnr = telefoonnr;
            klant.mail = mail;
            klant.wachtwoord = wachtwoord;
            klant.wachtwoord_herhalen = wachtwoord_herhalen;
            //klant.voorletters = formCollection["@voorletters"];
            //klant.tussenvoegsel = formCollection["@tussenvoegsel"];
            //klant.achternaam = formCollection["@achternaam"];
            //klant.adres =  formCollection["@adres"];
            //klant.postcode =  formCollection["@postcode"];
            //klant.woonplaats =  formCollection["@woonplaats"];
            //klant.telefoonnr =  formCollection["@telefoonnr"];
            //klant.mail =  formCollection["@mail"];
            //klant.wachtwoord =  formCollection["@wachtwoord"];
            //klant.wachtwoord_herhalen =  formCollection["wachtwoord_herhalen"];

            RegistrerenDBController registrerenController = new RegistrerenDBController();
            registrerenController.InsertRegistratie(klant);
           




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



        public ActionResult MijnGegevens(int klantnr)
        {
            MijnGegevensDBController sc = new MijnGegevensDBController();
            List<Bestelling> bestellingen = sc.getAllBestellingenByDate(klantnr);
            return View(bestellingen);
        }

        public ActionResult Pakketten()
        {
            return View();
        }

    }
}
