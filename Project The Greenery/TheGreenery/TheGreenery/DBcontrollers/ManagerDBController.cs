using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheGreenery.DBcontrollers
{
    public class ManagerDBController : DatabaseController
    {
        //
        // GET: /ManagerDB/

        public ActionResult Ingelogd()
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
