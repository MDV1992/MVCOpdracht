using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCOpdracht.Models.DAL
{
    public class ComponentContext : DbContext
    {
     public ComponentContext() : base("ComponentContext")
    {
        
    }
         public DbSet<Component> Components { get; set;}

    }
}