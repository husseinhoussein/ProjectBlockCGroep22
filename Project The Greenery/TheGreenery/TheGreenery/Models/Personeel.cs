using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TheGreenery.Models
{
    public class Personeel
    {

         public Personeel(int Code_Personeel)
        {
            this.Code_Personeel = Code_Personeel;
        }
        public Personeel() { }

        public int Code_Personeel;
        public int IdPersoneel
        {
            get { return Code_Personeel; }
            set { Code_Personeel = value; }
        }

        public int personeelnr; 
        public int persoonID; 
        public String voorletters; 
        public String tussenvoegsel; 
        public String achternaam; 
        public String type;
        public String wachtwoord;

        public int getPersoneelnr()
        { return personeelnr; }

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

        public string getType()
        { return type; }

        public void setType(String input)
        { type = input; }

        public string getWachtwoord()
        { return wachtwoord; }

        public void setWachtwoord(String input)
        { wachtwoord = input; }
        
    }
}