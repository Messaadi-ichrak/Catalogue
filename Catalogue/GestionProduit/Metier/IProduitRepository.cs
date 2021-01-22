using Catalogue.GestionProduit.NewFolder.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.GestionProduit.Metier
{
    public interface IProduitRepository
    {
       IList<Produit> getAllProduits();
       IList<Produit> getProduits(string motcle);
        IList<Produit> getProduitsByCategorieId(int? CatId);

        Produit getProduitById(int id);
        void addProduit(Produit p);
        void updateProduit(Produit newProduit);
        void deleteProduit(Produit p);
    }
}

