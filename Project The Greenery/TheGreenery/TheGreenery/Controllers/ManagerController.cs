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
        //
        // GET: /ManagerDB/

        public ActionResult Ingelogd()
        {
            return View();
        }

        public ActionResult ProductenInzien()
        {
            ProduchtDBController sc = new ProduchtDBController();
            List<Product> producten = sc.getAllProducten();
            return View(producten);
        }

        public ActionResult PersoneelInzien(int? personeelnr)
        {
            PersoneelDBController pc = new PersoneelDBController();
            List<Personeel> personeel = pc.getAllPersoneel(personeelnr);
            return View(personeel);
        }

    }
}
