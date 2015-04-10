using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using TheGreenery.Models;

namespace TheGreenery.DBcontrollers
{
    public class BestellingenBeherenDBController : DatabaseController
    {
        //

        public List<Bestelling> getNietAfgerondeBes(int? bestellingnr)
        {
            MySqlTransaction trans = null;
            List<Bestelling> bestellingen = new List<Bestelling>();

            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                string selectQuery = @"select * from Bestelling;";

                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlParameter klantnrParam = new MySqlParameter("@bestellingnr", MySqlDbType.Int32);
                cmd.Parameters.Add(klantnrParam);
                cmd.Prepare();

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Bestelling bestelling = new Bestelling();
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

         public void statusAanpassen(Bestelling bestelling)
        {
            MySqlTransaction trans = null;
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                string insertString = @"
                    UPDATE Bestelling      
                    SET  status = @status;";

                    MySqlCommand cmd = new MySqlCommand(insertString, conn);

                    MySqlParameter statusParam = new MySqlParameter("@status", MySqlDbType.VarChar);
                    MySqlParameter bestellingnrParam = new MySqlParameter("@bestellingnr", MySqlDbType.VarChar);

                    statusParam.Value = bestelling.status;
                    bestellingnrParam.Value = bestelling.bestellingnr;

                    cmd.Parameters.Add(statusParam);
                    cmd.Parameters.Add(bestellingnrParam);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new Exception("Klantgegevens niet aangepast: " + e);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
