using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using TheGreenery.Models;
using TheGreenery.Controllers;

namespace TheGreenery.DBcontrollers
{
    public class MijnGegevensDBController : DatabaseController
    {
        
        public Klant getKlantbyID(int? klantnr)
        {
            Klant klant = new Klant();
            MySqlTransaction trans = null;
            List<Klant> klanten = new List<Klant>();
                    
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                string selectQuery = @"select * from Klant";

                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlParameter klantnrParam = new MySqlParameter("@klantnr", MySqlDbType.Int32);
                cmd.Parameters.Add(klantnrParam);
                cmd.Prepare();
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    
                    klant.klantnr = dataReader.GetInt32("klantnr");
                    klant.voorletters = dataReader.GetString("voorletters");
                    klant.tussenvoegsel = dataReader.GetString("tussenvoegsel");
                    klant.achternaam = dataReader.GetString("achternaam");
                    klant.adres = dataReader.GetString("adres");
                    klant.postcode = dataReader.GetString("postcode");
                    klant.woonplaats = dataReader.GetString("woonplaats");
                    klant.telefoonnr = dataReader.GetString("telefoonnr");
                    klant.mail = dataReader.GetString("mail");

                    klanten.Add(klant);
                    Console.Write(klant.klantnr);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Mijn gegevens niet opgehaald: " + e);
            }
            finally
            {
                conn.Close();
            }
            return klant;
        }

        public void GegevensAanpassen(Klant klant)
        {
            MySqlTransaction trans = null;
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                string insertString = @"
                    UPDATE Klant      
                    SET  voorletters = @voorletters, tussenvoegsel = @tussenvoegsel, achternaam = @achternaam, 
                         adres = @adres, postcode = @postcode, woonplaats = @woonplaats, telefoonnr = @telefoonnr, 
                         mail = @mail           
                    WHERE klantnr = 1 
                    ;";

                MySqlCommand cmd = new MySqlCommand(insertString, conn);
                MySqlParameter voorlettersParam = new MySqlParameter("@voorletters", MySqlDbType.VarChar);
                MySqlParameter tussenvoegselParam = new MySqlParameter("@tussenvoegsel", MySqlDbType.VarChar);
                MySqlParameter achternaamParam = new MySqlParameter("@achternaam", MySqlDbType.VarChar);
                MySqlParameter adresParam = new MySqlParameter("@adres", MySqlDbType.VarChar);
                MySqlParameter postcodeParam = new MySqlParameter("@postcode", MySqlDbType.VarChar);
                MySqlParameter woonplaatsParam = new MySqlParameter("@woonplaats", MySqlDbType.VarChar);
                MySqlParameter telefoonnrParam = new MySqlParameter("@telefoonnr", MySqlDbType.VarChar);
                MySqlParameter mailParam = new MySqlParameter("@mail", MySqlDbType.VarChar);

                voorlettersParam.Value = klant.voorletters;
                tussenvoegselParam.Value = klant.tussenvoegsel;
                achternaamParam.Value = klant.achternaam;
                adresParam.Value = klant.adres;
                postcodeParam.Value = klant.postcode;
                woonplaatsParam.Value = klant.woonplaats;
                telefoonnrParam.Value = klant.telefoonnr;
                mailParam.Value = klant.mail;

                cmd.Parameters.Add(voorlettersParam);
                cmd.Parameters.Add(tussenvoegselParam);
                cmd.Parameters.Add(achternaamParam);
                cmd.Parameters.Add(adresParam);
                cmd.Parameters.Add(postcodeParam);
                cmd.Parameters.Add(woonplaatsParam);
                cmd.Parameters.Add(telefoonnrParam);
                cmd.Parameters.Add(mailParam);

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
