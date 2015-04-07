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


        public ActionResult ProductenToevoegen(String naam, int type, String lente, String zomer, String herfst, String winter, String prijsPerEenheid,
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





            return View();

        }


        public ActionResult ProductenBewerken()
        {
            return View();
        }

        public ActionResult PersoneelToevoegen()
        {
            return View();
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

        public ActionResult PersoneelToegevoegd(int? personeelnr, String voorletters, String tussenvoegsel, String achternaam, String type, String wachtwoord)
        {
            Personeel personeel = new Personeel();
            personeel.getPersoneelnr();
            personeel.setVoorletters(voorletters);
            personeel.setTussenvoegsel(tussenvoegsel);
            personeel.setAchternaam(achternaam);
            personeel.setType(type);
            personeel.setWachtwoord(wachtwoord);

            if (personeelnr != null && !personeelnr.Equals(""))

                {
                    RegistrerenDBController registrerenController = new RegistrerenDBController();
                    registrerenController.InsertPersoneel(personeel);
                }

        {
                RegistrerenDBController registrerenController = new RegistrerenDBController();
                registrerenController.InsertPersoneel(personeel);

            }
            return View();
        }

    }
}
        


