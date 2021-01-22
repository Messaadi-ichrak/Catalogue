using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Catalogue.Models;
using Catalogue.GestionProduit.Metier;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Catalogue.Controllers
{
    public class HomeController : Controller
    {
        readonly IProduitRepository produitrepository;
        readonly ICategorieRepository categorierepository;

        public HomeController(IProduitRepository produitrepository, ICategorieRepository categorierepository)
        {
            this.produitrepository = produitrepository;
            this.categorierepository = categorierepository;
        }

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
