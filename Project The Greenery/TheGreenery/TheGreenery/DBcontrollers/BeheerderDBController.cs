using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult ProductenToevoegen()
        {
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
