using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonCatalogueProduit.Service
{
    public class CatalogueDbContext: DbContext
    {
        public DbSet<Produit> Produits { set; get; }
        public DbSet<Categorie> Categories { set; get; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Cat_DB_8;Trusted_Connection=True");
        }
    }
}
