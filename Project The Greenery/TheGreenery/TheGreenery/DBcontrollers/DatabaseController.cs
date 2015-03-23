using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace TheGreenery.DBcontrollers
{
    public abstract class DatabaseController
    {
        protected MySqlConnection conn;

        public DatabaseController()
        {
            //Vul hier de juiste gegevens in!!
            conn = new MySqlConnection("Server=localhost;Database=the_greenery;Uid=root;Pwd=root;");
        }
    }

}

