using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TheGreenery.Models
{
    public class Personeel
    {
        public int personeelnr; // { get; set; }
        public int persoonID; // { get; set; }
        public String voorletters; // { get; set; }
        public String tussenvoegsel; // { get; set; }
        public String achternaam; // { get; set; }
        //public enum type; // { get; set; }

        public int getPersoneelnr()
        { return personeelnr; }

        public int getPersoonID()
        { return persoonID; }

        public void setPersoonID(int input)
        { persoonID = input; }

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

    }
}