using Catalogue.GestionProduit.NewFolder.DAO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.GestionProduit.Metier
{
    public class ProduitRepository : IProduitRepository
    {
        readonly CatalogueDbContext catalogue;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProduitRepository(CatalogueDbContext catalogue, IWebHostEnvironment webHostEnvironment)
        {
            this.catalogue = catalogue;
            this.webHostEnvironment = webHostEnvironment;
        }
        public void addProduit(Produit p)
        {
            string wwwRootPath = webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(p.ImageFile.FileName);
            string extension = Path.GetExtension(p.ImageFile.FileName);
            p.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                p.ImageFile.CopyTo(fileStream);
            }
            catalogue.Produits.Add(p);
            catalogue.SaveChanges();

        }

        public void deleteProduit(Produit p)
        {
            Produit toDelete = catalogue.Produits.Find(p.ProduitId);
            if(toDelete != null)
            {
                catalogue.Produits.Remove(toDelete);
                catalogue.SaveChanges();

            }
            

        }

        public Produit getProduitById(int id)
        {
            return catalogue.Produits.Find(id);
        }

        public IList<Produit> getAllProduits()
        {
            return catalogue.Produits.OrderBy(x=>x.Designation).Include(x => x.Categorie).ToList();
        }

        public IList<Produit> getProduits(string motcle)
        {
            return catalogue.Produits.Where(s => s.Designation.Contains(motcle)).Include(std => std.Categorie).ToList();
        }


        public void updateProduit(Produit newProduit)
        {
            string wwwRootPath = webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(newProduit.ImageFile.FileName);
            string extension = Path.GetExtension(newProduit.ImageFile.FileName);
            newProduit.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                newProduit.ImageFile.CopyTo(fileStream);
            }

            Produit oldProduit = catalogue.Produits.Find(newProduit.ProduitId);
            if(oldProduit != null)
            {
                oldProduit.Designation = newProduit.Designation;
                oldProduit.Prix = newProduit.Prix;
                oldProduit.CategorieId = newProduit.CategorieId;
                oldProduit.Image = newProduit.Image;
                catalogue.SaveChanges();

            }
        }
        public IList<Produit> getProduitsByCategorieId(int? CatId)
        { 
            return catalogue.Produits.Where(s => s.CategorieId.Equals(CatId))
                .OrderBy(s => s.Designation).Include(std => std.Categorie).ToList();
        }
    }
}
