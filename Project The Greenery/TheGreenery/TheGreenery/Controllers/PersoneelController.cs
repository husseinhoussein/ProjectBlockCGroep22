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

        public ActionResult LoginResult(int personeelnr, String wachtwoord, String type)
        {
            LoginDBController gebruiker = new LoginDBController();
            Session["LoggedInP"] = null;
            Personeel gPers = gebruiker.LogInPersSelect(personeelnr, wachtwoord, type);
            try
            {
                if (gPers != null)
                {
                    if (gPers.personeelnr == @personeelnr && gPers.wachtwoord == @wachtwoord)
                    {
                        if (gPers.type == "beheerder")
                        {
                            Session["LoggedInP"] = gPers;
                            String url = "/Personeel/LoginResultB";
                            return Redirect(url);
                        }
                        else if (gPers.type == "manager")
                        {
                            Session["LoggedInP"] = gPers.Code_Personeel;
                            String url = "/Personeel/LoginResultM";
                            return Redirect(url);
                        }
                    }
                }
               
            }
            catch (FormatException)
            {
                ViewData["Ero"] = "you dun goofed";
                return View("PersoneelLogIn");
            }
            return View();

        }
    }
}






