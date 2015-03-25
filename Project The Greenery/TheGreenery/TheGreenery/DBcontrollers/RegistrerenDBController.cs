using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using TheGreenery.Models;


namespace TheGreenery.DBcontrollers
{
    class RegistrerenDBController : DatabaseController
    {
        //
        // GET: /Registeren/

        public void InsertRegistratie(Klant klant)
        {
            MySqlTransaction trans = null;
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {

                string insertString = @"insert into klant (voorletters, Tussenvoegsel, Achternaam, Adres, Postcode, Woonplaats, 
                                                   telefoonnummer, e-mail, wachtwoord, wachtwoord_herhalen)
                                                   values (@voorletters, @Tussenvoegsel, @Achternaam, @Adres, @Postcode, @Woonplaats, 
                                                   @telefoonnummer, @e-mail, @wachtwoord, @wachtwoord(herhalen)";

                MySqlCommand cmd = new MySqlCommand(insertString, conn);

                MySqlParameter voorlettersParam = new MySqlParameter("@voorletters", MySqlDbType.VarChar);
                MySqlParameter TussenvoegselParam = new MySqlParameter("@tussenvoegsek", MySqlDbType.VarChar);
                MySqlParameter AchternaamParam = new MySqlParameter("@achternaam", MySqlDbType.VarChar);
                MySqlParameter AdresParam = new MySqlParameter("@adres", MySqlDbType.VarChar);
                MySqlParameter PostcodeParam = new MySqlParameter("@postcode", MySqlDbType.VarChar);
                MySqlParameter WoonplaatsParam = new MySqlParameter("@woonplaats", MySqlDbType.VarChar);
                MySqlParameter telefoonnummerParam = new MySqlParameter("@telefoonnummer", MySqlDbType.VarChar);
                MySqlParameter emailParam = new MySqlParameter("@e-mail", MySqlDbType.VarChar);
                MySqlParameter WachtwoordParam = new MySqlParameter("@wachtwoord", MySqlDbType.VarChar);
                MySqlParameter Wachtwoord_herhalenParam = new MySqlParameter("@wachtwoord_herhalen)", MySqlDbType.VarChar);


                Klant klant1 = new Klant();
                voorlettersParam.Value = klant1.voorletters;
                TussenvoegselParam.Value = klant1.tussenvoegsel;
                AchternaamParam.Value = klant1.achternaam;
                AdresParam.Value = klant1.adres;
                PostcodeParam.Value = klant1.postcode;
                WoonplaatsParam.Value = klant1.woonplaats;
                telefoonnummerParam.Value = klant1.telefoonnummer;
                emailParam.Value = klant1.email;
                WachtwoordParam.Value = klant1.wachtwoord;
                Wachtwoord_herhalenParam.Value = klant1.wachtwoord_herhalen;

                cmd.Parameters.Add(voorlettersParam);
                cmd.Parameters.Add(TussenvoegselParam);
                cmd.Parameters.Add(AchternaamParam);
                cmd.Parameters.Add(AdresParam);
                cmd.Parameters.Add(PostcodeParam);
                cmd.Parameters.Add(WoonplaatsParam);
                cmd.Parameters.Add(telefoonnummerParam);
                cmd.Parameters.Add(emailParam);
                cmd.Parameters.Add(WachtwoordParam);
                cmd.Parameters.Add(Wachtwoord_herhalenParam);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
                trans.Commit();
            }


            catch (Exception e)
            {
                trans.Rollback();
                Console.Write("Klant niet toegevoegd: " + e);
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
