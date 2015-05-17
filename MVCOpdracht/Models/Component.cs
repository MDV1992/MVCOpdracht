using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCOpdracht.Models
{
    public class Component
    {
        int ID { get; set; }

        string Categorie { get; set; }

        string Naam { get; set; }
        string Link { get; set; }
        int Aantal { get; set; }
        double Prijs { get; set; }

    }
}