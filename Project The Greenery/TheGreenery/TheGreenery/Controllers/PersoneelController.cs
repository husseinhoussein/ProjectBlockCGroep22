using System;
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
    public class PersoneelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PersoneelLogin()
        {
            return View();
        }

        public ActionResult LoginResultB()
        {
            return View();
        }
        public ActionResult LoginResultM()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoginResult(int? personeelnr, String wachtwoord, String type)
        {
            LoginDBController gebruiker = new LoginDBController();
            Session["LoggedIn"] = null;
            Personeel gUser = gebruiker.LogInPersSelect(personeelnr, wachtwoord, type);
            try
            {
                if (gUser != null)
                {
                    if (gUser.personeelnr == @personeelnr && gUser.wachtwoord == @wachtwoord)
                    {
                        if (gUser.type == "beheerder")
                        {
                            Session["LoggedIn"] = gUser.Code_Personeel;
                            String url = "/Personeel/LoginResultB";
                            return Redirect(url);
                        }
                        else if (gUser.type == "manager")
                        {
                            Session["LoggedIn"] = gUser.Code_Personeel;
                            String url = "/Personeel/LoginResultM";
                            return Redirect(url);
                        }
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

    }
}





