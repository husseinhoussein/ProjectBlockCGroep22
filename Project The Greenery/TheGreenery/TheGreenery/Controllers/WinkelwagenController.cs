using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TheGreenery.DBcontrollers;
using TheGreenery.Models;

namespace TheGreenery.Controllers
{
    public class WinkelwagenController : Controller
    {
        //
        // GET: /Winkelwagen/

        ProductDBController sc = new ProductDBController();
        Product product = new Product();

        public ActionResult Index()
        {
            return View();
        }

        private int isExisting(int productnr)
        {
            List<Product> productq = (List<Product>)Session["wagen"];
            for (int i = 0; i < productq.Count; i++)
                if (productq[i].productnr == productnr)
                    return i;
            return -1;
        }

        public ActionResult Delete(int productnr)
        {
            int index = isExisting(productnr);
            List<Product> productq = (List<Product>)Session["wagen"];
            productq.RemoveAt(index);
            Session["wagen"] = productq;
            return View("wagen");
        }

        public ActionResult Bestellingplaatsen(int productnr)
        {
            if (Session["wagen"] == null)
            {

              
                List<Product> productq = sc.getProductByProductNr(productnr);

                Session["wagen"] = productq;

            }
            else
            {
               List<Product> productq = sc.getProductByProductNr(productnr);
                int index = isExisting(productnr);
                if (index == -1) 
                    foreach (Product product in (List<Product>)Session["wagen"])
                    {
                        productq.Add(product);
                    }
                else
                    productq[index].voorraadPerEenheid++;
                Session["wagen"] = productq;

            }

            ////Product product = sc.getAllProducten();
            //wagen.Add(product);

            return View("wagen");
        }

        public ActionResult BestellingOverzicht()
        {
            if (Session["wagen"] == null)
            {
                return View("index");
            }
            else
            {
                List<Product> productq = (List<Product>)Session["wagen"];
            }
            return View("wagen");
        }


        public ActionResult definitieveBestellingplaatsen()
        {

            //List<Product> wagen = (List<Product>)Session["wagen"];
            //ViewBag.listProducts = wagen;

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("thegreenerymailtest@gmail.com"); // van welke email account je een bericht verstuurd
            mail.To.Add("thegreenerymailtest@gmail.com"); // naar welk email acount je een mail naar toe wilt sturen
            mail.Subject = "Test Mail"; // onderwerp email
            mail.IsBodyHtml = true;

            mail.Body = "Bestelling geplaatst op: " + DateTime.Now.ToLongDateString();  // body van mail


            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("thegreenerymailtest@gmail.com", "greenery2015"); // de email die een mail verstuurd inlog gegevens
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            return View("Index");
        }

    }
}
