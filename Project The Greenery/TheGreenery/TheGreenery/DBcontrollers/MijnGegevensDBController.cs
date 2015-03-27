using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using TheGreenery.Models;

namespace TheGreenery.DBcontrollers
{
    public class MijnGegevensDBController : DatabaseController
    {
       public List<Bestelling> getAllBestellingenByDate(int? bestellingnr)
        {
            MySqlTransaction trans = null;
            List<Bestelling> bestellingen = new List<Bestelling>();




            //conn.Open();
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                string selectQuery = @"select * from Bestelling;";

                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlParameter klantnrParam = new MySqlParameter("@bestellingnr", MySqlDbType.Int32);
                //klantnrParam.Value = "%" + klantnr + "%";
                cmd.Parameters.Add(klantnrParam);
                cmd.Prepare();


                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Bestelling bestelling = new Bestelling();
                   
                    bestelling.bestellingnr = dataReader.GetInt32("bestellingnr");
                    bestelling.klantnr = dataReader.GetInt32("klantnr");
                    bestelling.totaalbedrag = dataReader.GetDouble("totaalbedrag");
                   

                    bestellingen.Add(bestelling);
                    Console.Write(bestelling.bestellingnr);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(" === niet opgehaald: " + e);
            }

            finally
            {
                conn.Close();
            }

            return bestellingen;
        }


       
    }
}
