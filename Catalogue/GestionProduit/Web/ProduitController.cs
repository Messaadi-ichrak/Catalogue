using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogue.GestionProduit.Metier;
using Catalogue.GestionProduit.NewFolder.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Catalogue.GestionProduit.Web
{
    public class ProduitController : Controller
    {
        readonly IProduitRepository produitrepository;
        readonly ICategorieRepository categorierepository;
        
        public ProduitController(IProduitRepository produitrepository, ICategorieRepository categorierepository)
        {
            this.produitrepository = produitrepository;
            this.categorierepository = categorierepository;
        }
        // GET: ProduitController
        public ActionResult Index()
        {
            ViewBag.CategorietId = new SelectList(categorierepository.GetAllCategories(), "CategorietId", "Intitule");
            return View(produitrepository.getAllProduits());
        }


        public ActionResult Search(string name, int? catid)
        {
            var result = produitrepository.getAllProduits();
            if (!string.IsNullOrEmpty(name))
                result = produitrepository.getProduits(name);
            else
            if (catid != null)
                result = produitrepository.getProduitsByCategorieId(catid);
            ViewBag.CategorietId = new SelectList(categorierepository.GetAllCategories(), "CategorietId", "Intitule");
            return View("Index", result);
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            return View(produitrepository.getProduitById(id));
        }

        // GET: ProduitController/Create
        public ActionResult Create()
        {
            ViewBag.CategorietId = new SelectList(categorierepository.GetAllCategories(), "CategorietId", "Intitule");
            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produit p)
        {
            try
            {
                ViewBag.CategorietId = new SelectList(categorierepository.GetAllCategories(), "CategorietId", "Intitule", p.CategorieId);
                produitrepository.addProduit(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategorietId = new SelectList(categorierepository.GetAllCategories(), "CategorietId", "Intitule");
            return View(produitrepository.getProduitById(id));
        }

        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produit p)
        {
            try
            {
                ViewBag.CategorietId = new SelectList(categorierepository.GetAllCategories(), "CategorietId", "Intitule", p.CategorieId);
                produitrepository.updateProduit(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(produitrepository.getProduitById(id));
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Produit p)
        {
            try
            {
                produitrepository.deleteProduit(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
