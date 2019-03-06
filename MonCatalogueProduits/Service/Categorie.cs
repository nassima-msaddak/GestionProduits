using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MonCatalogueProduit.Service
{
    [Table ("CATEGORIES")]
    public class Categorie
    {
        [Key]
        public int CategorieID { get; set; }
        [StringLength(30)]
        public string NomCategorie { get; set; }
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
