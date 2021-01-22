using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.GestionProduit.NewFolder.DAO
{
    public class CatalogueDbContext: DbContext
    {
        public CatalogueDbContext(DbContextOptions<CatalogueDbContext> options) : base(options)
        {

        }


        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }

    }
}
