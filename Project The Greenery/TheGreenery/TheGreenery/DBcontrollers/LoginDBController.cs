using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using TheGreenery.Models;

namespace TheGreenery.DBcontrollers
{
    public class LoginDBController : DatabaseController
    {
        public Klant LogInSelect( String mail, String wachtwoord)
        {
            Klant klant = new Klant();
            MySqlTransaction trans = null;
            conn.Open();
            try
            {
                // conn.Open();
                trans = conn.BeginTransaction();
                string selectQuery = @"SELECT * FROM Klant WHERE mail = @mail AND wachtwoord = @wachtwoord;";

                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlParameter mailParam = new MySqlParameter("@mail", MySqlDbType.VarChar);
                MySqlParameter wachtwoordParam = new MySqlParameter("@wachtwoord", MySqlDbType.VarChar);
                
                mailParam.Value = mail;
                wachtwoordParam.Value = wachtwoord;

                cmd.Parameters.Add(mailParam);
                cmd.Parameters.Add(wachtwoordParam);

                cmd.Prepare();


                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {

                    klant.mail = dataReader.GetString("mail");
                    klant.wachtwoord = dataReader.GetString("wachtwoord");

                    
                }
                
            }

            //catch (Exception e)
            //{
            //    throw new Exception("Wachtwoord verkeerd: " + e);
            //}

            finally
            {
                conn.Close();
            }

            return klant;
        }
              
    }
}
