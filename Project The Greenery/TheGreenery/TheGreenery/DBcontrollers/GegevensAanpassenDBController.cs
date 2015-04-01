using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGreenery.Models;
using MySql.Data.MySqlClient;

namespace TheGreenery.DBcontrollers
{

        //
        // GET: /GegevensAanpassenDB/
        public class GegevensAanpassenDBController : DatabaseController
        {

            // GET: /GegevensAanpassenDB/
            public void GegevensAanpassen()
            {

                MySqlTransaction trans = null;
                conn.Open();

                trans = conn.BeginTransaction();
                try
                {
                    string updateQuery = @"UPDATE Klant SET voorletters= @voorletters, tussenvoegsel = @tussenvoegsel, achternaam = @achternaam, 
                         adres =@adres, postcode =@postcode, woonplaats =@woonplaats, telefoonnr =@telefoonnr, mail = @mail, klantnr= @klantnr
                         WHERE Klantnr = 1;"; 

                    Klant klant = new Klant();
                    MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                    MySqlParameter klantnrParam = new MySqlParameter("@klantnr", MySqlDbType.VarChar);
                    MySqlParameter voorlettersParam = new MySqlParameter("@voorletters", MySqlDbType.VarChar);
                    MySqlParameter tussenvoegselParam = new MySqlParameter("@tussenvoegsel", MySqlDbType.VarChar);
                    MySqlParameter achternaamParam = new MySqlParameter("@achternaam", MySqlDbType.VarChar);
                    MySqlParameter adresParam = new MySqlParameter("@adres", MySqlDbType.VarChar);
                    MySqlParameter postcodeParam = new MySqlParameter("@postcode", MySqlDbType.VarChar);
                    MySqlParameter woonplaatsParam = new MySqlParameter("@woonplaats", MySqlDbType.VarChar);
                    MySqlParameter telefoonnrParam = new MySqlParameter("@telefoonnr", MySqlDbType.VarChar);
                    MySqlParameter mailParam = new MySqlParameter("@mail", MySqlDbType.VarChar);

                    klantnrParam.Value = klant.klantnr;
                    voorlettersParam.Value = klant.voorletters;
                    tussenvoegselParam.Value = klant.tussenvoegsel;
                    achternaamParam.Value = klant.achternaam;
                    adresParam.Value = klant.adres;
                    postcodeParam.Value = klant.postcode;
                    woonplaatsParam.Value = klant.woonplaats;
                    telefoonnrParam.Value = klant.telefoonnr;
                    mailParam.Value = klant.mail;

                    cmd.Parameters.Add(klantnrParam);
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
                    throw new Exception("Klant niet toegevoegd: " + e);
                }
                finally
                {
                    conn.Close();
                }
            }


        }

    }
