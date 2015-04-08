using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGreenery.Models;

namespace TheGreenery.Controllers
{
    public class WinkelproductController : Controller
    {
        //
        // GET: /Winkelproduct/

        public ActionResult Index()
        {
            //ViewBag.listProducts = this.ViewBag;
            return View();
        }

    }
}
