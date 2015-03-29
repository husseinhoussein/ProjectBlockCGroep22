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



                
                string insertString = @"insert into Klant ( voorletters, tussenvoegsel, achternaam, adres, postcode, woonplaats, 
                                                    values (?voorletters, ?tussenvoegsel, ?achternaam, ?adres, ?postcode, ?woonplaats,
                                                             ?telefoonnr, ?mail, ?wachtwoord, ?wachtwoord_herhalen);";
//values (?voorletters, ?tussenvoegsel, ?achternaam, ?adres, ?postcode, ?woonplaats,  ?telefoonnr, ?mail, ?wachtwoord, ?wachtwoord_herhalen);";
                                                

                MySqlCommand cmd = new MySqlCommand(insertString, conn);
              //cmd.CommandText = "insert into Klant(voorletters, tussenvoegsel, achternaam, adres, postcode, woonplaats, values(@voorletters, @tussenvoegsel, @achternaam, @adres, @postcode, @woonplaats,  @telefoonnr, @mail, @wachtwoord, @wachtwoord_herhalen);";
              // cmd.Parameters.AddWithValue("?voorletters", MySqlDbType.VarChar).Value = klant.voorletters;
                MySqlParameter voorlettersParam = new MySqlParameter("?voorletters", MySqlDbType.VarChar);
              //  cmd.Parameters.AddWithValue("?tussenvoegsel", MySqlDbType.VarChar).Value = klant.tussenvoegsel;
                MySqlParameter tussenvoegselParam = new MySqlParameter("?tussenvoegsel", MySqlDbType.VarChar);
              //  cmd.Parameters.AddWithValue("?achternaam", MySqlDbType.VarChar).Value = klant.achternaam;
                MySqlParameter achternaamParam = new MySqlParameter("?achternaam", MySqlDbType.VarChar);
              //  cmd.Parameters.AddWithValue("?adres", MySqlDbType.VarChar).Value = klant.adres;
                MySqlParameter adresParam = new MySqlParameter("?adres", MySqlDbType.VarChar);
              //  cmd.Parameters.AddWithValue("?postcode", MySqlDbType.VarChar).Value = klant.postcode;
                MySqlParameter postcodeParam = new MySqlParameter("?postcode", MySqlDbType.VarChar);
              //  cmd.Parameters.AddWithValue("?woonplaats", MySqlDbType.VarChar).Value = klant.woonplaats;
                MySqlParameter woonplaatsParam = new MySqlParameter("?woonplaats", MySqlDbType.VarChar);
              //  cmd.Parameters.AddWithValue("?telefoonnr", MySqlDbType.VarChar).Value = klant.telefoonnr;
                MySqlParameter telefoonnrParam = new MySqlParameter("?telefoonnr", MySqlDbType.VarChar);
              //  cmd.Parameters.AddWithValue("?mail", MySqlDbType.VarChar).Value = klant.mail;
                MySqlParameter mailParam = new MySqlParameter("?mail", MySqlDbType.VarChar);
              //  cmd.Parameters.AddWithValue("?wachtwoord", MySqlDbType.VarChar).Value = klant.wachtwoord;
                MySqlParameter wachtwoordParam = new MySqlParameter("?wachtwoord", MySqlDbType.VarChar);
              //  cmd.Parameters.AddWithValue("?wachtwoord_herhalen", MySqlDbType.VarChar).Value = klant.wachtwoord_herhalen;
                MySqlParameter wachtwoord_herhalenParam = new MySqlParameter("?wachtwoord_herhalen)", MySqlDbType.VarChar);
                


                


               // Klant klant = new Klant();

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
                Console.Write("Klant niet toegevoegd: " + e);
            }
            finally
            {
                conn.Close();
            }
        }



        
    }
}
