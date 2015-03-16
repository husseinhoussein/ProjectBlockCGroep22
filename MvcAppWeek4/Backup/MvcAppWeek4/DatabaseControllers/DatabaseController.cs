using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MvcAppWeek4.DatabaseControllers
{
    public abstract class DatabaseController
    {
        protected MySqlConnection conn;

        public DatabaseController()
        {
            //Vul hier de juiste gegevens in!!
            conn = new MySqlConnection("Server=meru.hhs.nl;Database=lanparty;Uid=hpweenink;Pwd=eeGhahpaiz;");
        }
    }
}
