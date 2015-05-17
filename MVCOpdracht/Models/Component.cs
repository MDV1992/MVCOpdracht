using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCOpdracht.Models
{
    public class Component
    {
       public int ID { get; set; }

       public string Categorie { get; set; }

       public string Naam { get; set; }
       public string Link { get; set; }
       public int Aantal { get; set; }
       public double Prijs { get; set; }
       public double Aankoop { get; set; }

    }
}