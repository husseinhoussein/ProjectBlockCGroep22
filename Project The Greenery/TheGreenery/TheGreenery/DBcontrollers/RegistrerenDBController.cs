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
                string insertString = @"
                    insert into Klant 
                        (voorletters, tussenvoegsel, achternaam, 
                         adres, postcode, woonplaats, telefoonnr, 
                         mail,  wachtwoord, wachtwoord_herhalen) 
                        values 
                        (@voorletters, @tussenvoegsel, @achternaam, 
                         @adres, @postcode, @woonplaats, @telefoonnr, 
                         @mail, @wachtwoord, @wachtwoord_herhalen);
                ";

                MySqlCommand cmd = new MySqlCommand(insertString, conn);
                MySqlParameter voorlettersParam = new MySqlParameter("@voorletters", MySqlDbType.VarChar);
                MySqlParameter tussenvoegselParam = new MySqlParameter("@tussenvoegsel", MySqlDbType.VarChar);
                MySqlParameter achternaamParam = new MySqlParameter("@achternaam", MySqlDbType.VarChar);
                MySqlParameter adresParam = new MySqlParameter("@adres", MySqlDbType.VarChar);
                MySqlParameter postcodeParam = new MySqlParameter("@postcode", MySqlDbType.VarChar);
                MySqlParameter woonplaatsParam = new MySqlParameter("@woonplaats", MySqlDbType.VarChar);
                MySqlParameter telefoonnrParam = new MySqlParameter("@telefoonnr", MySqlDbType.VarChar);
                MySqlParameter mailParam = new MySqlParameter("@mail", MySqlDbType.VarChar);
                MySqlParameter wachtwoordParam = new MySqlParameter("@wachtwoord", MySqlDbType.VarChar);
                MySqlParameter wachtwoord_herhalenParam = new MySqlParameter("@wachtwoord_herhalen", MySqlDbType.VarChar);

                voorlettersParam.Value = klant.voorletters;
                tussenvoegselParam.Value = klant.tussenvoegsel;
                achternaamParam.Value = klant.achternaam;
                adresParam.Value = klant.adres;
                postcodeParam.Value = klant.postcode;
                woonplaatsParam.Value = klant.woonplaats;
                telefoonnrParam.Value = klant.telefoonnr;
                mailParam.Value = klant.mail;
                 wachtwoordParam.Value = klant.wachtwoord;
                wachtwoord_herhalenParam.Value = klant.wachtwoord_herhalen;

                cmd.Parameters.Add(voorlettersParam);
                cmd.Parameters.Add(tussenvoegselParam);
                cmd.Parameters.Add(achternaamParam);
                cmd.Parameters.Add(adresParam);
                cmd.Parameters.Add(postcodeParam);
                cmd.Parameters.Add(woonplaatsParam);
                cmd.Parameters.Add(telefoonnrParam);
                cmd.Parameters.Add(mailParam);
                cmd.Parameters.Add(wachtwoordParam);
                cmd.Parameters.Add(wachtwoord_herhalenParam);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new Exception("Klant niet toegevoegd: " + e);
            }
            finally
            {
                conn.Close();
            }
        }

        public void InsertPersoneel(Personeel personeel)
        {
            MySqlTransaction trans = null;
            conn.Open();
            trans = conn.BeginTransaction();

            try
            {
                string insertString = @"
                    insert into Personeel 
                        (personeelnr, voorletters, tussenvoegsel, achternaam, 
                         type, wachtwoord) 
                        values 
                        (@personeelnr, @voorletters, @tussenvoegsel, @achternaam, 
                         @type, @wachtwoord)
                ;";

                MySqlCommand cmd = new MySqlCommand(insertString, conn);
                MySqlParameter personeelnrParam = new MySqlParameter("@personeelnr", MySqlDbType.Int32);
                MySqlParameter voorlettersParam = new MySqlParameter("@voorletters", MySqlDbType.VarChar);
                MySqlParameter tussenvoegselParam = new MySqlParameter("@tussenvoegsel", MySqlDbType.VarChar);
                MySqlParameter achternaamParam = new MySqlParameter("@achternaam", MySqlDbType.VarChar);
                MySqlParameter typeParam = new MySqlParameter("@type", MySqlDbType.VarChar);
                MySqlParameter wachtwoordParam = new MySqlParameter("@wachtwoord", MySqlDbType.VarChar);
               
                personeelnrParam.Value = personeel.personeelnr;
                voorlettersParam.Value = personeel.voorletters;
                tussenvoegselParam.Value = personeel.tussenvoegsel;
                achternaamParam.Value = personeel.achternaam;
                typeParam.Value = personeel.type;
                wachtwoordParam.Value = personeel.wachtwoord;
                

                cmd.Parameters.Add(voorlettersParam);
                cmd.Parameters.Add(tussenvoegselParam);
                cmd.Parameters.Add(achternaamParam);
                cmd.Parameters.Add(typeParam);
                cmd.Parameters.Add(wachtwoordParam);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new Exception("Klant niet toegevoegd: " + e);
            }
            finally
            {
                conn.Close();
            }
        }



    }
}
