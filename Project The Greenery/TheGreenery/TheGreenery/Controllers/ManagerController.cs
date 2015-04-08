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
    public class ManagerController : DatabaseController
    {
        public ActionResult Ingelogd()
        {
            return View();
        }

        public ActionResult ProductenInzien(String naam)
        {
            ProduchtDBController sc = new ProduchtDBController();
            List<Product> producten = sc.getAllProducten(naam);
            return View(producten);
        }

        public ActionResult PersoneelInzien(int? personeelnr)
        {
            
            //return View(personeel);
            if (Session["LoggedInP"] != null)
            {
                PersoneelDBController pc = new PersoneelDBController();
                List<Personeel> personeel = pc.getAllPersoneel(personeelnr);
                Personeel p = Session["LoggedInP"] as Personeel;

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
