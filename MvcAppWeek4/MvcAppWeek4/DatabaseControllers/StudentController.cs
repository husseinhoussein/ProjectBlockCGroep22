using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcAppWeek4.Models;
using MySql.Data.MySqlClient;

namespace MvcAppWeek4.DatabaseControllers
{
    public class StudentController : DatabaseController
    {
        public List<Student> getAllStudentsByAchternaam(String achternaam)
        {
            List<Student> studenten = new List<Student>();

            conn.Open();
            try
            {
                string query = @"select * 
                                  from student 
                                 where studentnaam like @studnaam";

                MySqlParameter paramStudNaam = new MySqlParameter("@studnaam", MySqlDbType.VarChar);
                paramStudNaam.Value = "%" + achternaam + "%";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(paramStudNaam);
                cmd.Prepare();

                MySqlDataReader rs = cmd.ExecuteReader();
                while (rs.Read())
                {
                    Student stud = new Student();
                    stud.id = rs.GetInt32("student_id");
                    stud.studentnaam = rs.GetString("studentnaam");

                    
                    /*
                    int game_id = rs.GetInt32("game_id");
                    GameController gc = new GameController();
                    stud.game = gc.getGame(game_id);
                    */
                    studenten.Add(stud);
                }
            }
                /*
            catch (Exception e)
            {
                //Exception .Write("Studenten niet opgehaald: " + e);
            }
                 */
            finally
            {
                conn.Close();
            }

            return studenten;


            //MySqlCommand cmd = new MySqlCommand(query, conn);
            //cmd.ExecuteNonQuery();
            //long nieuwId = cmd.LastInsertedId;

            //return nieuwId;
        }
        public List<Student> getAll() 
        {
            List<Student> studenten = new List<Student>();
                        //select bladibla
            return studenten;
        }
    }
}