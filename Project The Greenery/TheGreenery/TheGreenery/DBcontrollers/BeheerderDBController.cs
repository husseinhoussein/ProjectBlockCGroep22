using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGreenery.DBcontrollers;
using TheGreenery.Models;
using MySql.Data.MySqlClient;


namespace TheGreenery.DBcontrollers
{
    public class BeheerderDBController : DatabaseController
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

        public ActionResult PersoneelInzien()
        {
            return View();
        }



       

    }
} 
        


