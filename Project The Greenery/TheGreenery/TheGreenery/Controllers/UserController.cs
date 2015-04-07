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
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoginResult(int? klantnr, String mail, String wachtwoord)
        {            
            LoginDBController gebruiker = new LoginDBController();
            Session["LoggedIn"] = null;
            Klant gUser = gebruiker.LogInSelect(klantnr, mail, wachtwoord);
            try
            {
                if (gUser != null)
                {
                    if (gUser.mail == @mail && gUser.wachtwoord == @wachtwoord)
                    {
                        Session["LoggedIn"] = gUser.Code_Klant;
                        String url = "/Home/Mijngegevens";
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

    }
}



