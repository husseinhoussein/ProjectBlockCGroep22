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

        public ActionResult Ingelogd()
        {
            return View();
        }

        public ActionResult ProductenToevoegen(String naam, String type, String lente, String zomer, String herfst, String winter, int prijsPerEenheid,
                                       String eenheid, String omschrijving, int voorraadPerEenheid, String imageNaam, String aanbieding)
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

        public ActionResult ProductToegevoegd(String naam, String type, String lente, String zomer, String herfst, String winter, int prijsPerEenheid,
                                       String eenheid, String omschrijving, int voorraadPerEenheid, String imageNaam, String aanbieding)
        {
            if (Session["LoggedInP"] != null)
            {
                Product product = Session["LoggedInP"] as Product;
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

                return View(p);

            }
            else
            {
                String urlLogin = "/Personeel/PersoneelLogIn";
                return Redirect(urlLogin);
            }

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

        public ActionResult ProductenInzien(String naam)
        {
            if (Session["LoggedInP"] != null)
            {

                ProductDBController sc = new ProductDBController();
                List<Product> producten = sc.getAllProducten(naam);
                return View(producten);
            }
            else
        {
                String urlLogin = "/Personeel/PersoneelLogIn";
                return Redirect(urlLogin);
            }
        }

        public ActionResult PersoneelInzien(int? personeelnr)
        {
            if (Session["LoggedInP"] != null)
            {

            PersoneelDBController pc = new PersoneelDBController();
            List<Personeel> personeel = pc.getAllPersoneel(personeelnr);
            return View(personeel);
        }
            else
            {
                String urlLogin = "/Personeel/PersoneelLogIn";
                return Redirect(urlLogin);
            }
        }

        public ActionResult PersoneelToegevoegd(String voorletters, String tussenvoegsel, String achternaam, String type, String wachtwoord)
        {
            if (Session["LoggedInP"] != null)
            {
                Personeel personeel = Session["LoggedInP"] as Personeel;
                personeel.setVoorletters(voorletters);
                personeel.setTussenvoegsel(tussenvoegsel);
                personeel.setAchternaam(achternaam);
                personeel.setType(type);
                personeel.setWachtwoord(wachtwoord);
                

                RegistrerenDBController registrerenController = new RegistrerenDBController();
                registrerenController.InsertPersoneel(personeel);

                return View(personeel);

            }
            else
            {
                String urlLogin = "/Personeel/PersoneelLogIn";
                return Redirect(urlLogin);
            }
          
        }

        

    }
}





