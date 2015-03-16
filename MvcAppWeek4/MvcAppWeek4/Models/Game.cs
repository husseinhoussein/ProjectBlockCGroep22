using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcAppWeek4.Models
{
    public class Game
    {
        private int id;

        public Game(int id)
        {
            this.id = id;
        }
        public Game() { }
        
        public String Naam { get; set; }
        public Genre Genre { get; set; }
        public int ID { get { return id; } }

        public override string ToString()
        {
            return String.Format("{0} (id = {1}) {2}", Naam, ID, Genre);////test
        }
    
    }
}


