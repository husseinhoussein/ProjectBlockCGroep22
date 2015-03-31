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

        
      
        public ActionResult Registreer()
        {
            return View();
        }

        
        public ActionResult Login()
        {
            return View();
        }

        
        
            
     
        public ActionResult geregistreerd( String voorletters, String tussenvoegsel ,  String achternaam, String adres , String postcode, String woonplaats, String telefoonnr, String mail, String wachtwoord, String wachtwoord_herhalen)
            {
            
            
            Klant klant = new Klant();

                klant.setVoorletters(voorletters);
                klant.setTussenvoegsel(tussenvoegsel);
                klant.setAdres(adres);
                klant.setAchternaam(achternaam);
                klant.setPostocde(postcode);
                klant.setWoonplaats(woonplaats);
                klant.setTelefoonnr(telefoonnr);
                klant.setMail(mail);
                klant.setWachtwoord(wachtwoord);
                klant.setWachtwoordHerhalen(wachtwoord_herhalen);

         


            if (mail != null && !mail.Equals(""))
            {
                RegistrerenDBController registrerenController = new RegistrerenDBController();
                registrerenController.InsertRegistratie(klant);

        }
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
