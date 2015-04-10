using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGreenery.Models;
using TheGreenery.DBcontrollers;

namespace TheGreenery.DBcontrollers
{
    public class BestellenDBController : DatabaseController
    {
        //
        // GET: /BestellenDB/

        public ActionResult Index()
        {
            return View();
        }

        public Klant insertLegeBestelling(int klantnr)
        {

            
            Klant klant = new Klant();

                MySqlTransaction trans = null;
                conn.Open();
                trans = conn.BeginTransaction();
                try
                {
                    string insertString = @"
                    insert into Bestelling 
                        (klantnr, totaalbedrag, status)
                        values 
                        (@klantnr, 0, 'in behandeling')
                ;";
                    

                    MySqlCommand cmd = new MySqlCommand(insertString, conn);

                    MySqlParameter klantnrParam = new MySqlParameter("@klantnr", MySqlDbType.Int32);
                    klantnrParam.Value = klantnr;
                    cmd.Parameters.Add(klantnrParam);

                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    throw new Exception("Bestelling niet toegevoegd: " + e);
                }
                finally
                {
                    conn.Close();
                }
            return (klant);
        }

        public Bestelling insertBestellingRegel(int bestellingnr, int productnr, int aantalEenheden, double regelprijs)
        {

            Bestelling bestelling = new Bestelling();

            MySqlTransaction trans = null;
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                string insertString = @"
                    insert into Bestelregel 
                        (bestellingnr, productnr, aantalEenheden, regelprijs)
                        values 
                        (@bestellingnr, @productnr, @aantalEenheden, @regelprijs)
                ;";


                MySqlCommand cmd = new MySqlCommand(insertString, conn);

                MySqlParameter bestellingnrParam = new MySqlParameter("@bestellingnr", MySqlDbType.Int32);
                MySqlParameter productnrParam = new MySqlParameter("@productnr", MySqlDbType.Int32);
                MySqlParameter aantalEenhedenParam = new MySqlParameter("@aantalEenheden", MySqlDbType.Int32);
                MySqlParameter regelprijsParam = new MySqlParameter("@regelprijs", MySqlDbType.Double);


                bestellingnrParam.Value = bestellingnr;
                productnrParam.Value = productnr;
                aantalEenhedenParam.Value = aantalEenheden;
                regelprijsParam.Value = regelprijs;


                cmd.Parameters.Add(bestellingnrParam);
                cmd.Parameters.Add(productnrParam);
                cmd.Parameters.Add(aantalEenhedenParam);
                cmd.Parameters.Add(regelprijsParam);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new Exception("Bestelling niet toegevoegd: " + e);
            }
            finally
            {
                conn.Close();
            }
            return (bestelling);
        }

        public List<Bestelling> getBestellingByKlantNr(int klantnr)
        {
            List<Bestelling> bestelling = new List<Bestelling>();

            conn.Open();
            try
            {


                string selectQuery = @"select MAX(bestellingnr) as bestellingnr from Bestelling where klantnr like @klantnr";

                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlParameter klantnrParam = new MySqlParameter("@klantnr", MySqlDbType.VarChar);
                klantnrParam.Value = "%" + klantnr + "%";
                cmd.Parameters.Add(klantnrParam);
                cmd.Prepare();

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Bestelling bestell = new Bestelling();
                    bestell.bestellingnr = dataReader.GetInt32("bestellingnr");
                    //bestelling.bestellingnr
                    bestelling.Add(bestell);
                    Console.Write(bestell.bestellingnr);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Producten niet opgehaald: " + e);
            }

            finally
            {
                conn.Close();
            }

            return bestelling;
        }

    }
}
