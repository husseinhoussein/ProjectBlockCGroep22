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
                                                   telefoonnr, mail, wachtwoord, wachtwoord_herhalen)
                                                   values (@voorletters, @tussenvoegsel, @achternaam, @adres, @postcode, @woonplaats, 
                                                   @telefoonnr, @mail, @wachtwoord, @wachtwoord_herhalen);";

                //MySqlCommand cmd = new MySqlCommand(insertString, conn);
                //MySqlParameter voorlettersParam = new MySqlParameter("@voorletters", MySqlDbType.VarChar);
                //MySqlParameter TussenvoegselParam = new MySqlParameter("@tussenvoegsel", MySqlDbType.VarChar);
                //MySqlParameter AchternaamParam = new MySqlParameter("@achternaam", MySqlDbType.VarChar);
                //MySqlParameter AdresParam = new MySqlParameter("@adres", MySqlDbType.VarChar);
                //MySqlParameter PostcodeParam = new MySqlParameter("@postcode", MySqlDbType.VarChar);
                //MySqlParameter WoonplaatsParam = new MySqlParameter("@woonplaats", MySqlDbType.VarChar);
                //MySqlParameter telefoonnrParam = new MySqlParameter("@telefoonnummer", MySqlDbType.VarChar);
                //MySqlParameter mailParam = new MySqlParameter("@mail", MySqlDbType.VarChar);
                //MySqlParameter WachtwoordParam = new MySqlParameter("@wachtwoord", MySqlDbType.VarChar);
                //MySqlParameter Wachtwoord_herhalenParam = new MySqlParameter("@wachtwoord_herhalen)", MySqlDbType.VarChar);
                MySqlCommand cmd = new MySqlCommand(insertString, conn);
                MySqlParameter voorletters = new MySqlParameter("@voorletters", MySqlDbType.VarChar);
                MySqlParameter tussenvoegsel = new MySqlParameter("@tussenvoegsel", MySqlDbType.VarChar);
                MySqlParameter achternaam = new MySqlParameter("@achternaam", MySqlDbType.VarChar);
                MySqlParameter adres = new MySqlParameter("@adres", MySqlDbType.VarChar);
                MySqlParameter postcode = new MySqlParameter("@postcode", MySqlDbType.VarChar);
                MySqlParameter woonplaats = new MySqlParameter("@woonplaats", MySqlDbType.VarChar);
                MySqlParameter telefoonnr = new MySqlParameter("@telefoonnummer", MySqlDbType.VarChar);
                MySqlParameter mail = new MySqlParameter("@mail", MySqlDbType.VarChar);
                MySqlParameter wachtwoord = new MySqlParameter("@wachtwoord", MySqlDbType.VarChar);
                MySqlParameter wachtwoord_herhalen = new MySqlParameter("@wachtwoord_herhalen", MySqlDbType.VarChar);

//                string insertString = @"insert into Klant ( voorletters, tussenvoegsel, achternaam, adres, postcode, woonplaats, 
//                                                   telefoonnr, mail, wachtwoord, wachtwoord_herhalen)
//                                                   values ('"+ voorlettersParam+"', '"+TussenvoegselParam+"','"+AchternaamParam+"','"+AdresParam+"','"+PostcodeParam+"','"+WoonplaatsParam+"','"+telefoonnrParam+"','"+mailParam+"','"+WachtwoordParam+"','"+Wachtwoord_herhalenParam+"');";
                                                                
                                                                
                                                  
                //MySqlCommand cmd = new MySqlCommand(insertString, conn);
                //MySqlParameter persoonIDParam = new MySqlParameter("@persoonID", MySqlDbType.Int32);
                


                Klant klant1 = new Klant();
                //persoonIDParam.Value = klant1.persoonID;
                voorletters.Value = klant1.voorletters;
                tussenvoegsel.Value = klant1.tussenvoegsel;
                achternaam.Value = klant1.achternaam;
                adres.Value = klant1.adres;
                postcode.Value = klant1.postcode;
                woonplaats.Value = klant1.woonplaats;
                telefoonnr.Value = klant1.telefoonnr;
                mail.Value = klant1.mail;
                wachtwoord.Value = klant1.wachtwoord;
                wachtwoord_herhalen.Value = klant1.wachtwoord_herhalen;

                //cmd.Parameters.Add(persoonIDParam);
                cmd.Parameters.Add(voorletters);
                cmd.Parameters.Add(tussenvoegsel);
                cmd.Parameters.Add(achternaam);
                cmd.Parameters.Add(adres);
                cmd.Parameters.Add(postcode);
                cmd.Parameters.Add(woonplaats);
                cmd.Parameters.Add(telefoonnr);
                cmd.Parameters.Add(mail);
                cmd.Parameters.Add(wachtwoord);
                cmd.Parameters.Add(wachtwoord_herhalen);

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
