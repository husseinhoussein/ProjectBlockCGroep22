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
    public class BeheerderController : DatabaseController
    {


        //
        // GET: /BeheerderDB/



        public ActionResult Ingelogd()
        {
            return View();
        }

        public ActionResult ProductenToevoegen(String naam, String type, String lente, String zomer, String herfst, String winter, Double prijsPerEenheid,
                                       String eenheid, String omschrijving, int voorraadPerEenheid, String imageNaam, String aanbieding)
        {
            Product product = new Product();
            product.setNaam(naam);
            product.setType(type);
            product.setLente(lente);
            product.setZomer(zomer);
            product.setHerfst(herfst);
            product.setWinter(winter);
            product.setPrijsPerEenheid(prijsPerEenheid);
            product.setEenheid(eenheid);
            product.setOmschrijving(omschrijving);
            product.setVoorraadPerEenheid(voorraadPerEenheid);
            product.setImageNaam(imageNaam);
            product.setAanbieding(aanbieding);

            ProductDBController productToevoegenController = new ProductDBController();
            productToevoegenController.InsertProduct(product);

            return View();

        }

        public ActionResult ProductenBewerken()
        {
            return View();
        }

        public ActionResult PersoneelToevoegen(String voorletters, String tussenvoegsel, String achternaam, String type, String wachtwoord)
        {
            if (Session["LoggedInP"] != null)
            {
                Personeel p = Session["LoggedInP"] as Personeel;
                return View(p);
            }
            else
            {
                String urlLogin = "/Personeel/PersoneelLogIn";
                return Redirect(urlLogin);
            }
        }

        public ActionResult ProductenInzien()
        {
            return View();
        }

        public ActionResult PersoneelInzien(int? personeelnr)
        {
            PersoneelDBController pc = new PersoneelDBController();
            List<Personeel> personeel = pc.getAllPersoneel(personeelnr);
            return View(personeel);
        }

        public ActionResult PersoneelToegevoegd(String voorletters, String tussenvoegsel, String achternaam, String type, String wachtwoord)
        {
            if (Session["LoggedInP"] != null)
            {
                Personeel personeel = new Personeel();
                personeel.setVoorletters(voorletters);
                personeel.setTussenvoegsel(tussenvoegsel);
                personeel.setAchternaam(achternaam);
                personeel.setType(type);
                personeel.setWachtwoord(wachtwoord);
                Personeel p = Session["LoggedInP"] as Personeel;

                RegistrerenDBController registrerenController = new RegistrerenDBController();
                registrerenController.InsertPersoneel(personeel);

                return View(p);

            }
            else
            {
                String urlLogin = "/Personeel/PersoneelLogIn";
                return Redirect(urlLogin);
            }
          
        }

        

    }
}





