using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using TheGreenery.Models;
using TheGreenery.DBcontrollers;


namespace TheGreenery.DBcontrollers
{
    public class ProduchtDBController : DatabaseController
    {
        public List<Product> getAllProductenByNaam(String naam)
        {
            MySqlTransaction trans = null;
            List<Product> producten = new List<Product>();

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
                    product.prijsPerEenheid = dataReader.GetString("prijsPerEenheid");
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
                Console.WriteLine("Producten niet opgehaald: " + e);
            }

            finally
            {
                conn.Close();
            }

            return producten;
        }

        public void InsertProduct(Product product)
        {
            MySqlTransaction trans = null;
            conn.Open();
            trans = conn.BeginTransaction();

            try
            {

               
                string insertString = @"
                             INSERT INTO Product 
                              (naam, type, lente, zomer, herfst, winter, prijsPerEenheid, 
                              eenheid, omschrijving, voorraadPerEenheid, imageNaam, aanbieding) 
                              values 
                              (@naam, @type, @lente, @zomer, @herfst, @winter, @prijsPerEenheid, 
                              @eenheid, @omschrijving, @voorraadPerEenheid, @imageNaam, @aanbieding);
                 ";

                MySqlCommand cmd = new MySqlCommand(insertString, conn);
                MySqlParameter naamParam = new MySqlParameter("@naam", MySqlDbType.VarChar);
                MySqlParameter typeParam = new MySqlParameter("@type", MySqlDbType.VarChar);
                MySqlParameter lenteParam = new MySqlParameter("@lente", MySqlDbType.VarChar);
                MySqlParameter zomerParam = new MySqlParameter("@zomer", MySqlDbType.VarChar);
                MySqlParameter herfstParam = new MySqlParameter("@herfst", MySqlDbType.VarChar);
                MySqlParameter winterParam = new MySqlParameter("@winter", MySqlDbType.VarChar);
                MySqlParameter prijsPerEenheidParam = new MySqlParameter("@prijsPerEenheid", MySqlDbType.VarChar);
                MySqlParameter eenheidParam = new MySqlParameter("@eenheid", MySqlDbType.VarChar);
                MySqlParameter omschrijvingParam = new MySqlParameter("@omschrijving", MySqlDbType.VarChar);
                MySqlParameter voorraadPerEenheidParam = new MySqlParameter("@voorraadPerEenheid", MySqlDbType.VarChar);
                MySqlParameter imageNaamParam = new MySqlParameter("@imageNaam", MySqlDbType.VarChar);
                MySqlParameter aanbiedingParam = new MySqlParameter("@aanbieding", MySqlDbType.VarChar);


                naamParam.Value = product.naam;
                typeParam.Value = product.type;
                lenteParam.Value = product.lente;
                zomerParam.Value = product.zomer;
                herfstParam.Value = product.herfst;
                winterParam.Value = product.winter;
                prijsPerEenheidParam.Value = product.prijsPerEenheid;
                eenheidParam.Value = product.eenheid;
                omschrijvingParam.Value = product.omschrijving;
                voorraadPerEenheidParam.Value = product.voorraadPerEenheid;
                imageNaamParam.Value = product.imageNaam;
                aanbiedingParam.Value = product.aanbieding;


                cmd.Parameters.Add(naamParam);
                cmd.Parameters.Add(typeParam);
                cmd.Parameters.Add(lenteParam);
                cmd.Parameters.Add(zomerParam);
                cmd.Parameters.Add(herfstParam);
                cmd.Parameters.Add(winterParam);
                cmd.Parameters.Add(prijsPerEenheidParam);
                cmd.Parameters.Add(eenheidParam);
                cmd.Parameters.Add(omschrijvingParam);
                cmd.Parameters.Add(voorraadPerEenheidParam);
                cmd.Parameters.Add(imageNaamParam);
                cmd.Parameters.Add(aanbiedingParam);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                trans.Commit();

            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new Exception("Product niet toegevoegd: " + e);
            }
            finally
            {
                conn.Close();
            }
        }




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

        public List<Product> getAllProducten(String naam)
        {
            MySqlTransaction trans = null;
            List<Product> producten = new List<Product>();

            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                string selectQuery = @"select * from Product;";

                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                //MySqlParameter naamParam = new MySqlParameter("@naam", MySqlDbType.VarChar);
                //naamParam.Value = "%" + naam + "%";
                //cmd.Parameters.Add(naamParam);
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
                    product.prijsPerEenheid = dataReader.GetString("prijsPerEenheid");
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
                Console.WriteLine("Producten niet opgehaald: " + e);
            }

            finally
            {
                conn.Close();
            }

            return producten;
        }
       
    }
}

