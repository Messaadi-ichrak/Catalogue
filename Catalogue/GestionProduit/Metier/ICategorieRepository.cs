using Catalogue.GestionProduit.NewFolder.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.GestionProduit.Metier
{
    public interface ICategorieRepository
    {

        IList<Categorie> GetAllCategories();
        Categorie GetCategorieById(int id);
        void AddCategorie(Categorie c);
        void EditCategorie(Categorie c);
        void DeleteCategorie(Categorie c);
        int CountProduits(int CatId);
    }
}
