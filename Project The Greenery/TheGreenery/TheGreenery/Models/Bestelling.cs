using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGreenery.Models
{
    public class Bestelling
    {
        public int bestellingnr;

        public int klantnr;

        public double totaalbedrag;

        public String status;

        public void setStatus(String input)
        { status = input; }

        public string getStatus()
        { return status; }

    }
}