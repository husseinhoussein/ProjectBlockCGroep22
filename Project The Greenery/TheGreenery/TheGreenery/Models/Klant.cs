using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGreenery.Models
{
    public class Klant
    {
        //public int persoonID { get; set; }
        public String voorletters;// { get; set; }
        public String tussenvoegsel;// { get; set; }
        public String achternaam;// { get; set; }
        public String adres;// { get; set; }
        public String postcode;// { get; set; }
        public String woonplaats;// { get; set; }
        public String telefoonnr;// { get; set; }
        public String mail;// { get; set; }
        public String wachtwoord;// { get; set; }
        public String wachtwoord_herhalen;// { get; set; }

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