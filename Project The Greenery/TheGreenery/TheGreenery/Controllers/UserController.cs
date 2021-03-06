﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Web.Security;
using TheGreenery.Models;
using TheGreenery.DBcontrollers;

namespace TheGreenery.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoginResult(int? bestellingnr, String mail, String wachtwoord)
        {
            MijnBestellingenDBController bestellingen = new MijnBestellingenDBController();
            LoginDBController gebruiker = new LoginDBController();
            Session["LoggedIn"] = null;
            Klant gUser = gebruiker.LogInSelect(mail, wachtwoord);
            //Bestelling gBestelling = bestellingen.getAllBestellingenByDate(bestellingnr);

            try
            {
                if (gUser != null)
                {
                    if (gUser.mail == @mail && gUser.wachtwoord == @wachtwoord)
                    {
                        Session["LoggedIn"] = gUser;

                        int k = gUser.klantnr;
                        String d = Convert.ToString(k);

                        Session["inlogklantnr"] = (d);
                        String url = "/Home/Index";

                        BestellenDBController bd = new BestellenDBController();
                        bd.insertLegeBestelling(k);
                        return Redirect(url);
                    }

                }
            }

            catch (FormatException)
            {
                ViewData["Ero"] = "you dun goofed";
                return View("LogIn");
            }
            return View();
        }

        public ActionResult Registreer()
        {
            return View();
        }

        public ActionResult geregistreerd(String voorletters, String tussenvoegsel, String achternaam, String adres, String postcode, String woonplaats, String telefoonnr, String mail, String wachtwoord, String wachtwoord_herhalen)
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

        public ActionResult GegevensGewijzigd(String voorletters, String tussenvoegsel, String achternaam, String adres, String postcode, String woonplaats, String telefoonnr, String mail)
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

            MijnGegevensDBController MijnGegevens = new MijnGegevensDBController();
            MijnGegevens.GegevensAanpassen(klant);

            return View();

        }

        public ActionResult MijnGegevens()
        {
            if (Session["LoggedIn"] != null)
            {
                Klant k = Session["LoggedIn"] as Klant;

                return View(k);
            }
            else
            {
                String urlLogin = "/User/LogIn";
                return Redirect(urlLogin);
            }

        }

        public ActionResult MijnBestellingen(int? bestellingnr)
        {
            if (Session["LoggedIn"] != null)
            {
                         
            
                MijnBestellingenDBController sc = new MijnBestellingenDBController();
                List<Bestelling> bestelling = sc.getAllBestellingenByDate(bestellingnr);
                return View(bestelling);
            }
            
            else 
            {
                String urlLogin = "/User/LogIn";
                return Redirect(urlLogin);
            }

        }
    }
}



