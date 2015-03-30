using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace TheGreenery.DBcontrollers
{
    public abstract class DatabaseController : Controller
    {
        protected MySqlConnection conn;

        public DatabaseController()
        {
            //Vul hier de juiste gegevens in!!
            conn = new MySqlConnection("Server=meru.hhs.nl;Database=14062984;Uid=14062984;Pwd=fuxaejeiSe;");
        }
    }

}

