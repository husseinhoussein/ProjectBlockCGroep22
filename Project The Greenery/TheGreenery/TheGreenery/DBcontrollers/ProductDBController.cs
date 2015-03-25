using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using TheGreenery.Models;


namespace TheGreenery.DBcontrollers
{
    public class ProduchtDBController : DatabaseController
    {
        public List<Product> getAllProductenByNaam(String naam)
        {
            MySqlTransaction trans = null;
            List<Product> producten = new List<Product>();

       
       
        //BLOB oplsaan, naam ook, header

            //conn.Open();
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                string selectQuery = @"select * from Product where naam like @naam";

                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlParameter naamParam = new MySqlParameter("@naam", MySqlDbType.VarChar);
                naamParam.Value = "%" + naam + "%";
                cmd.Parameters.Add(naamParam);
                cmd.Prepare();


                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.productnr = dataReader.GetInt32("productnr");
                    product.naam = dataReader.GetString("naam");
                    product.type = dataReader.GetInt32("type");
                    product.lente = dataReader.GetString("lente");
                    product.zomer = dataReader.GetString("zomer");
                    product.herfst = dataReader.GetString("herfst");
                    product.winter = dataReader.GetString("winter");
                    product.prijsPerEenheid = dataReader.GetDouble("prijsPerEenheid");
                    product.eenheid = dataReader.GetString("eenheid");
                    product.omschrijving = dataReader.GetString("omschrijving");
                    product.voorraadPerEenheid = dataReader.GetInt32("voorraadpereenheid");
                    product.imageNaam = dataReader.GetString("imageNaam");
                    product.aanbieding = dataReader.GetString("aanbieding");

                    producten.Add(product);
                    Console.Write(product.naam);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Studenten niet opgehaald: " + e);
            }

            finally
            {
                conn.Close();
            }

            return producten;
        }

//        public void InsertProduct(Product product)
//        {
//            MySqlTransaction trans = null;
//            try
//            {
//                conn.Open();
//                trans = conn.BeginTransaction();
//                string insertString = @"insert into the_greenery.product (idproduct, naam, soort, seizoen, prijs, voorraad) 
//                                               values (@idproduct, @naam, @soort, @seizoen, prijs, voorraad)";
//                MySqlCommand cmd = new MySqlCommand(insertString, conn);
//                MySqlParameter idproductParam = new MySqlParameter("@idproduct", MySqlDbType.Int32);
//                MySqlParameter naamParam = new MySqlParameter("@naam", MySqlDbType.VarChar);
//                MySqlParameter soortParam = new MySqlParameter("@soort", MySqlDbType.VarChar);
//                MySqlParameter seizoenParam = new MySqlParameter("@seizoen", MySqlDbType.Int32);
//                MySqlParameter prijsParam = new MySqlParameter("@prijs", MySqlDbType.Double);
//                MySqlParameter voorraadParam = new MySqlParameter("@voorraad", MySqlDbType.Int32);

//                idproductParam.Value = product.productnr;
//                naamParam.Value = product.naam;
//                soortParam.Value = product.type;
//                seizoenParam.Value = product.seizoen;
//                prijsParam.Value = product.prijs;
//                voorraadParam.Value = product.voorraad;

//                cmd.Parameters.Add(idproductParam);
//                cmd.Parameters.Add(naamParam);
//                cmd.Parameters.Add(soortParam);
//                cmd.Parameters.Add(seizoenParam);
//                cmd.Parameters.Add(prijsParam);
//                cmd.Parameters.Add(voorraadParam);

//                cmd.Prepare();

//                cmd.ExecuteNonQuery();

//                trans.Commit();

//            }
//            catch (Exception e)
//            {
//                trans.Rollback();
//                Console.Write("Product niet toegevoegd: " + e);
//            }
//            finally
//            {
//                conn.Close();
//            }
//        }

        public void DeleteAllProducts()
        {
            MySqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                string deleteString = @"delete from the_greenery.product WHERE  idproduct = "" ;";

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
    }
}

