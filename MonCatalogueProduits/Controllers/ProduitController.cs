using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonCatalogueProduit.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonCatalogueProduit.Controllers
{
    public class ProduitController : Controller
    {

        public CatalogueDbContext dbContext { get; set; }

        public ProduitController(CatalogueDbContext db) 
        {
            this.dbContext = db;
        }


        // GET: /<controller>/
         public IActionResult Index(int page=0,int size=5,string motCle="")
        {
            int position = page * size;
            IEnumerable<Produit> produits = dbContext.Produits.Where(p=>p.Designation.Contains(motCle)).Skip(position).Take(size).Include(p=>p.Categorie).ToList();//c'est  la methode syntax link (on peut utiliser le query syntax)
            ViewBag.currentPage = page;
            int totalPages;
            int nbreProduit = dbContext.Produits.Where(p => p.Designation.Contains(motCle)).ToList().Count;
            if(nbreProduit % size ==0 ) { 
                 totalPages = nbreProduit/size;
            }else{
                totalPages = 1+ nbreProduit / size ;
            }
            ViewBag.totalPages = totalPages;
            ViewBag.motCle = motCle;
            return View("Produits",produits);
        }

        public IActionResult FormProduit()
        {
            Produit p = new Produit();
            IEnumerable<Categorie> cats = dbContext.Categories.ToList();
            ViewBag.categories = cats;
            return View("FormProduit",p);
        }

        [HttpPost]
        public IActionResult SaveProduit(Produit p)
        {
            IEnumerable<Categorie> cats = dbContext.Categories.ToList();
            ViewBag.categories = cats;

            if (ModelState.IsValid)
            {
                dbContext.Produits.Add(p);
                dbContext.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View("FormProduit", p);

        }

    }
}
