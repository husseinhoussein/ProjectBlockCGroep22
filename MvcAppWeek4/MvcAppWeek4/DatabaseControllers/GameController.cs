using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

using MvcAppWeek4.Models;

namespace MvcAppWeek4.DatabaseControllers
{
    class GameController : DatabaseController
    {
        //dazvidanya
        //CRUD functionaliteiten voor Game

        public GameController() { }

        //TODO Implementeer de onderstaande methoden tijdens het practicum

        public void InsertGame(Game Game)
        {
           
        }

        public Game getGame(int gameID)
        {
            return null;
        }

        public void UpdateGame(Game Game)
        {
        
        }

        public void DeleteGame(Game Game)
        {
 
        }
        public void DeleteAllGames()
        {
          
        }


        public List<Game> GetGames()
        {
            return null;
        }
    }
}
