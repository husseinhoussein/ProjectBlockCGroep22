using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using TheGreenery.Models;

namespace TheGreenery.DBcontrollers
{
    public class MijnBestellingenDBController : DatabaseController
    {

        public List<Bestelling> getAllBestellingenByDate(int? bestellingnr)
        {
            Bestelling bestelling = new Bestelling();
            MySqlTransaction trans = null;
            List<Bestelling> bestellingen = new List<Bestelling>();

            conn.Open();
            trans = conn.BeginTransaction();
            try

            {
                string selectQuery = @"select * from Bestelling;";

                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlParameter bestellingnrParam = new MySqlParameter("@bestellingnr", MySqlDbType.Int32);
                cmd.Parameters.Add(bestellingnrParam);

           

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    bestelling.bestellingnr = dataReader.GetInt32("bestellingnr");
                    bestelling.klantnr = dataReader.GetInt32("klantnr");
                    bestelling.totaalbedrag = dataReader.GetDouble("totaalbedrag");
                    bestelling.status = dataReader.GetString("status");

                    bestellingen.Add(bestelling);
                    Console.Write(bestelling.bestellingnr);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(" Bestellingen niet opgehaald: " + e);
            }
            finally
            {
                conn.Close();
            }
            return bestellingen;
        }

    }
}
