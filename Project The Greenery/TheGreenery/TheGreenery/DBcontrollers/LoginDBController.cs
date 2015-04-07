using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using TheGreenery.Models;

namespace TheGreenery.DBcontrollers
{
    public class LoginDBController : DatabaseController
    {
        public Klant LogInSelect(String mail, String wachtwoord)
        {

            Klant klant = new Klant();
            MySqlTransaction trans = null;
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                string selectQuery = @"SELECT * FROM Klant WHERE mail = @mail AND wachtwoord = @wachtwoord;";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlParameter mailParam = new MySqlParameter("@mail", MySqlDbType.VarChar);
                MySqlParameter wachtwoordParam = new MySqlParameter("@wachtwoord", MySqlDbType.VarChar);

                mailParam.Value = mail;
                wachtwoordParam.Value = wachtwoord;

                cmd.Parameters.Add(mailParam);
                cmd.Parameters.Add(wachtwoordParam);
                cmd.Prepare();


                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {

                    int Klantnr = dataReader.GetInt32("klantnr");
                    String Mail = dataReader.GetString("mail");
                    String Wachtwoord = dataReader.GetString("wachtwoord");
                    String Voorletters = dataReader.GetString("voorletters");
                    String Tussenvoegsel = dataReader.GetString("tussenvoegsel");
                    String Achternaam = dataReader.GetString("achternaam");
                    String Adres = dataReader.GetString("adres");
                    String Postcode = dataReader.GetString("postcode");
                    String Woonplaats = dataReader.GetString("woonplaats");
                    String Telefoonnr = dataReader.GetString("telefoonnr");

                    klant.klantnr = Klantnr;
                    klant.mail = Mail;
                    klant.wachtwoord = wachtwoord;
                    klant.voorletters = Voorletters;
                    klant.tussenvoegsel = Tussenvoegsel;
                    klant.achternaam = Achternaam;
                    klant.adres = Adres;
                    klant.postcode = Postcode;
                    klant.woonplaats = Woonplaats;
                    klant.telefoonnr = Telefoonnr;

                }
            }

            finally
            {
                conn.Close();
            }

            return klant;
        }

        public Personeel LogInPersSelect(String achternaam, String wachtwoord, String type)
        {

            Personeel personeel = new Personeel();
            MySqlTransaction trans = null;
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                string selectQuery = @"SELECT * FROM Personeel WHERE achternaam = @achternaam AND wachtwoord = @wachtwoord;";

                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlParameter achternaamParam = new MySqlParameter("@achternaam", MySqlDbType.VarChar);
                MySqlParameter wachtwoordParam = new MySqlParameter("@wachtwoord", MySqlDbType.VarChar);

                achternaamParam.Value = achternaam;
                wachtwoordParam.Value = wachtwoord;

                cmd.Parameters.Add(achternaamParam);
                cmd.Parameters.Add(wachtwoordParam);

                cmd.Prepare();

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    int Personeelnr = dataReader.GetInt32("personeelnr");
                    String Voorletters = dataReader.GetString("voorletters");
                    String Tussenvoegsel = dataReader.GetString("tussenvoegsel");
                    String Achternaam = dataReader.GetString("achternaam");
                    String Type = dataReader.GetString("type");
                    String Wachtwoord = dataReader.GetString("wachtwoord");

                    personeel.personeelnr = Personeelnr;
                    personeel.voorletters = Voorletters;
                    personeel.tussenvoegsel = Tussenvoegsel;
                    personeel.achternaam = Achternaam;
                    personeel.type = Type;
                    personeel.wachtwoord = Wachtwoord;
                }

            }

            finally
            {
                conn.Close();
            }

            return personeel;
        }

    }
}
