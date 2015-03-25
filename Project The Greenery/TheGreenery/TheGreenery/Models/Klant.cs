using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGreenery.Models
{
    public class Klant
    {
        public String voorletters { get; set; }
        public String tussenvoegsel { get; set; }
        public String achternaam { get; set; }
        public String adres { get; set; }
        public String postcode { get; set; }
        public String woonplaats { get; set; }
        public String telefoonnummer { get; set; }
        public String email { get; set; }
        public String wachtwoord { get; set; }
        public String wachtwoord_herhalen { get; set; }
    }
}