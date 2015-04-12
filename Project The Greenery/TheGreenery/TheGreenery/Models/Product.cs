using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGreenery.Models
{
    public class Product
    {
        public int productnr;
        public String naam;
        public String type;
        public String lente;
        public String zomer;
        public String herfst;
        public String winter;
        public double? prijsPerEenheid;
        public String eenheid;
        public String omschrijving;
        public int? voorraadPerEenheid;
        public String imageNaam;
        public String aanbieding;
     
        public int getProductnr()
        { return productnr; }

        public void setProductnr(int input)
        { productnr = input; }

        public String getNaam()
        { return naam; }

        public void setNaam(String input)
        { naam = input; }

        public String getType()
        { return type; }

        public void setType(String input)
        { type = input; }

        public string getLente()
        { return lente; }

        public void setLente(String input)
        { lente = input; }

        public string getZomer()
        { return zomer; }

        public void setZomer(String input)
        { zomer = input; }

        public string getHerfst()
        { return herfst; }

        public void setHerfst(String input)
        { herfst = input; }

        public void setWinter(String input)
        { winter = input; }

        public string getWinter()
        { return winter; }

        public double? getPrijsPerEenheid()
        { return prijsPerEenheid; }

        public void setPrijsPerEenheid(double? input)
        { prijsPerEenheid = input; }  

        public string getEenheid()
        { return eenheid; }

        public void setEenheid(String input)
        { eenheid = input; }

        public string getOmschrijving()
        { return omschrijving; }

        public void setOmschrijving(String input)
        { omschrijving = input; }

        public int? getVoorraadPerEenheid()
        { return voorraadPerEenheid; }

        public void setVoorraadPerEenheid(int? input)
        { voorraadPerEenheid = input; }

        public string getImageNaam()
        { return imageNaam; }

        public void setImageNaam(String input)
        { imageNaam = input; }

        public string getAanbieding()
        { return aanbieding; }

        public void setAanbieding(String input)
        { aanbieding = input; }
    }

}
