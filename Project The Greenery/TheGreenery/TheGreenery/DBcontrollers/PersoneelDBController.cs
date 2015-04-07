using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using TheGreenery.Models;

namespace TheGreenery.DBcontrollers
{
    public class PersoneelDBController : DatabaseController
    {
        
        public List<Personeel> getAllPersoneel(int? personeelnr)
        {
            MySqlTransaction trans = null;
            List<Personeel> personeellijst = new List<Personeel>();
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                string selectQuery = @"select * from Personeel;";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlParameter personeelnrParam = new MySqlParameter("@personeelnr", MySqlDbType.Int32);
                cmd.Parameters.Add(personeelnrParam);
                cmd.Prepare();
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Personeel personeel = new Personeel();
                    personeel.personeelnr = dataReader.GetInt32("personeelnr");
                    personeel.voorletters = dataReader.GetString("voorletters");
                    personeel.tussenvoegsel = dataReader.GetString("tussenvoegsel");
                    personeel.achternaam = dataReader.GetString("achternaam");

                    personeellijst.Add(personeel);
                    Console.Write(personeel.personeelnr);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Personeel niet opgehaald: " + e);
            }
            finally
            {
                conn.Close();
            }
            return personeellijst;
        }

    }
}
