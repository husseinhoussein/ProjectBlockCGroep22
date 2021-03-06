﻿using System;
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
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowProduct(String naam)
        {
            ProductDBController sc = new ProductDBController();
            List<Product> producten = sc.getAllProductenByNaam(naam);
            return View(producten);
        }

        public ActionResult LentePage(String lente)
        {

            LenteDBController sc = new LenteDBController();
            List<Product> producten = sc.getAllProductenByLente(lente);
            return View(producten);
        }

        public ActionResult ZomerPage(String zomer)
        {

            ZomerDBController sc = new ZomerDBController();

            List<Product> producten = sc.getAllProductenByZomer(zomer);
            return View(producten);
        }

        public ActionResult HerfstPage(String herfst)
        {

            HerfstDBController sc = new HerfstDBController();
            List<Product> producten = sc.getAllProductenByHerfst(herfst);

            return View(producten);
        }
        public ActionResult WinterPage(String winter)
        {

            WinterDBController sc = new WinterDBController();
            List<Product> producten = sc.getAllProductenByWinter(winter);

            return View(producten);
        }

    }
}
