using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.GestionProduit.NewFolder.DAO
{
    public class Categorie
    {   [Key]
        public int CategorietId { get; set; }
        [Required(ErrorMessage = "Please enter category Intitule"), MinLength(5)]
        [Display(Name = "Intitule")]
        public string Intitule { get; set; }
        [Required(ErrorMessage = "Please enter category Description"), MinLength(5)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public ICollection<Produit> Produits { get; set; }
    }
}
