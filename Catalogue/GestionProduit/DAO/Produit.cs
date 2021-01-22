using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.GestionProduit.NewFolder.DAO
{
    public class Produit
    {
        [Key]
        public int ProduitId { get; set; }
        [Required(ErrorMessage = "Please enter product Designation"), MinLength(5)]
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Please enter product Price")]
        [Display(Name = "Prix")]
        public double Prix { get; set; }
        [Required(ErrorMessage = "Please choose product image")]
        [Display(Name = "Category")]
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
