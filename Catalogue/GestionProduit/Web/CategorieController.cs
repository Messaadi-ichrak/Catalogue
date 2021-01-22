using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogue.GestionProduit.Metier;
using Catalogue.GestionProduit.NewFolder.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogue.GestionProduit.Web
{
    public class CategorieController : Controller
    {
        readonly ICategorieRepository categorierepository;
        public CategorieController(ICategorieRepository categorierepository)
        {
            this.categorierepository = categorierepository;
        }

        // GET: CategorieController
        public ActionResult Index()
        {
            return View(categorierepository.GetAllCategories());
        }

        // GET: CategorieController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.CountProduits = categorierepository.CountProduits(id);
            var cat = categorierepository.GetCategorieById(id);
            return View(cat);
        }

        // GET: CategorieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategorieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorie c)
        {
            try
            {
                categorierepository.AddCategorie(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieController/Edit/5
        public ActionResult Edit(int id)
        {
            var cat = categorierepository.GetCategorieById(id);
            return View(cat);
        }

        // POST: CategorieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categorie c)
        {
            try
            {
                categorierepository.EditCategorie(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: CategorieController/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = categorierepository.GetCategorieById(id);
            return View(cat);
        }

        // POST: CategorieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categorie c)
        {
            try
            {
                categorierepository.DeleteCategorie(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
