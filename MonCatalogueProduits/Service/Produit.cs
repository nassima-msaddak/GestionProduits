using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MonCatalogueProduit.Service
{
    [Table("PRODUITS")]
    public class Produit
    {
        [Key] 
        public int ProduitID { get; set; }  
        [Required,MinLength(6),MaxLength(70)]
        [StringLength(70)]
        public string Designation { get; set; }
        [Required,Range(10,500000)]
        public double Prix { get; set; }
        public int Quantite { get; set; }

        public int CategorieID { get; set; }
        [ForeignKey("CategorieID")]

        public virtual Categorie Categorie { get; set;  }



    }
}
