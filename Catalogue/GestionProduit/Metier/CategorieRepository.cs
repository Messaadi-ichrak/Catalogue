using Catalogue.GestionProduit.NewFolder.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.GestionProduit.Metier
{
    public class CategorieRepository : ICategorieRepository
    {
        readonly CatalogueDbContext catalogue;

        public CategorieRepository (CatalogueDbContext catalogue)
        {
            this.catalogue = catalogue;
        }
        public void AddCategorie(Categorie c)
        {
            catalogue.Categories.Add(c);
            catalogue.SaveChanges();
        }

        public int CountProduits(int CatId)
        {
            return catalogue.Categories.Where(s => s.CategorietId == CatId).Count();
        }

        public void DeleteCategorie(Categorie c)
        {
            Categorie s1 = catalogue.Categories.Find(c.CategorietId);
            if (s1 != null)
            {
                catalogue.Categories.Remove(s1);
                catalogue.SaveChanges();
            }
        }

        public void EditCategorie(Categorie c)
        {
            Categorie s1 = catalogue.Categories.Find(c.CategorietId);
            if (s1 != null)
            {
                s1.Intitule = c.Intitule;
                s1.Description = c.Description;

                catalogue.SaveChanges();
            }
        }

        public IList<Categorie> GetAllCategories()
        {
            return catalogue.Categories.OrderBy(s => s.Intitule).ToList();
        }

        public Categorie GetCategorieById(int id)
        {
            return catalogue.Categories.Find(id);
        }
    }
}
