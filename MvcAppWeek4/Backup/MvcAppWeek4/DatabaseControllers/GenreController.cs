using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MvcAppWeek4.Models;


namespace MvcAppWeek4.DatabaseControllers
{
    class GenreController : DatabaseController
    {
        //CRUD functionaliteiten voor Genre

        public void InsertGenre(Genre genre)
        {
            MySqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                string insertString = @"insert into genre (genrenaam, verslavend) 
                                               values (@genrenaam, @verslavend)";
                MySqlCommand cmd = new MySqlCommand(insertString, conn);
                MySqlParameter genrenaamParam = new MySqlParameter("@genrenaam", MySqlDbType.VarChar);
                MySqlParameter verslavendParam = new MySqlParameter("@verslavend", MySqlDbType.Bit);

                genrenaamParam.Value = genre.Naam;
                verslavendParam.Value = genre.Verslavend;

                cmd.Parameters.Add(genrenaamParam);
                cmd.Parameters.Add(verslavendParam);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                trans.Commit();

            }
            catch (Exception e)
            {
                trans.Rollback();
                Console.Write("Genre niet toegevoegd: " + e);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>();
            try
            {
                conn.Open();

                string selectQuery = "select * from genre";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string genreNaam = dataReader.GetString("genrenaam");
                    int genreId = dataReader.GetInt32("genre_id");
                    bool verslavend = dataReader.GetBoolean("verslavend");
                    Genre genre = new Genre(genreId);
                    genre.Naam = genreNaam;
                    genre.Verslavend = verslavend;
                    genres.Add(genre);
                }
            }
            catch (Exception e)
            {
                Console.Write("Ophalen van genres mislukt " + e);
            }
            finally
            {
                conn.Close();
            }

            return genres;
        }

        public void DeleteAllGenres()
        {
            MySqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                string deleteString = @"delete from genre";

                MySqlCommand cmd = new MySqlCommand(deleteString, conn);
                cmd.ExecuteNonQuery();

                trans.Commit();

            }
            catch (Exception e)
            {
                trans.Rollback();
                Console.Write("Genres niet verwijderd: " + e);
            }
            finally
            {
                conn.Close();
            }
        }

        //TODO implementeren tijdens workshop
        public void UpdateGenre(Genre genre)
        {

        }

        //TODO implementeren tijdens workshop
        public void DeleteGenre(Genre genre)
        {

        }

        //TODO implementeren tijdens workshop

        public Genre SelectGenre(int genreId)
        {
            Genre genre = new Genre(genreId);
            try
            {
                conn.Open();

                string selectQuery = "select * from genre where genre_id =@genreId ";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlParameter genreIdParam = new MySqlParameter("@genreId", MySqlDbType.Int32);

                genreIdParam.Value = genre.ID;
                
                cmd.Parameters.Add(genreIdParam);
                
                cmd.Prepare();
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string genreNaam = dataReader.GetString("genrenaam");
                    bool verslavend = dataReader.GetBoolean("verslavend");
                    genre.Naam = genreNaam;
                    genre.Verslavend = verslavend;
                    Console.WriteLine("genre opgehaald");
                }
            }
            catch (Exception e)
            {
                Console.Write("Ophalen van genre mislukt " + e);
            }
            finally
            {
                conn.Close();
            }

            return genre;
       }
        
    }
    }



