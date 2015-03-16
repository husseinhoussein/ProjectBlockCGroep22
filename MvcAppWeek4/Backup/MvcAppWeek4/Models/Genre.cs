using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcAppWeek4.Models
{
    public class Genre
    {
        private int id;

        public Genre(int id)
        {
            this.id = id;
        }
        public Genre() { }

        public string Naam { get; set; }
        public bool Verslavend { get; set; }
        public int ID { get { return id; } }

        public override String ToString()
        {
            return String.Format("{0} (id={1}) {2}", 
                   Naam, ID, Verslavend ? "Verslavend" : "Niet verslavend");
        }
    }
}
