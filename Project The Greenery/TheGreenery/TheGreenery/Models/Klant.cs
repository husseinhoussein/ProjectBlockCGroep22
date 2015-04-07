using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TheGreenery.Models
{
    public class Klant
    {
        
        public Klant(int Code_Klant)
        {
            this.Code_Klant = Code_Klant;
        }
        
        public int Code_Klant;

        public int IdKlant
        {
            get { return Code_Klant; }
            set { Code_Klant = value; }
        }
        public int klantnr;
        public String voorletters;
        public String tussenvoegsel;
        public String achternaam;
        public String adres;
        public String postcode;
        public String woonplaats;
        public String telefoonnr;
        public String mail;
        public String wachtwoord;
        public String wachtwoord_herhalen;

        public int getKlantnr()
        { return klantnr; }

        public void setVoorletters(int input)
        { klantnr = input; }

        public string getVoorletters()
        { return voorletters; }

        public void setVoorletters(String input)
        { voorletters = input; }

        public string getTussenvoegsel()
        { return tussenvoegsel; }

        public void setTussenvoegsel(String input)
        { tussenvoegsel = input; }

        public string getAchternaam()
        { return achternaam; }

        public void setAchternaam(String input)
        { achternaam = input; }

        public string getAdres()
        { return adres; }

        public void setAdres(String input)
        { adres = input; }

        public string getPostcode()
        { return postcode; }

        public void setPostocde(String input)
        { postcode = input; }

        public string getWoonplaats()
        { return woonplaats; }

        public void setWoonplaats(String input)
        { woonplaats = input; }

        public string getTelefoonnr()
        { return telefoonnr; }

        public void setTelefoonnr(String input)
        { telefoonnr = input; }

        public string getMail()
        { return mail; }

        public void setMail(String input)
        { mail = input; }

        public string getWachtwoord()
        { return wachtwoord; }

        public void setWachtwoord(String input)
        { wachtwoord = input; }

        public string getWachtwoordHerhalen()
        { return wachtwoord_herhalen; }

        public void setWachtwoordHerhalen(String input)
        { wachtwoord_herhalen = input; }
    }

}
