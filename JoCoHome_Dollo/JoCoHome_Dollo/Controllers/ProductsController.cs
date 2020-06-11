using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JoCoHome_Dollo.Data;
using JoCoHome_Dollo.Models;

namespace JoCoHome_Dollo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(string searchString)
        {
            var Products = from m in _context.Product
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Products = Products.Where(s => s.Titel.Contains(searchString));
            }

            return View(await Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titel,Image,Land,Provincie,Plaats,Aantalpersonen,Slaapkamers,Typehuisje,Checkin,Checkout,Omschrijving")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titel,Image,Land,Provincie,Plaats,Aantalpersonen,Slaapkamers,Typehuisje,Checkin,Checkout,Omschrijving")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Detailpagina(int? id)
{
    MultipleProducts multipleProducts = new MultipleProducts();
    if (id == null)
    {
        return NotFound();
    }

    var product = await _context.Product
        .FirstOrDefaultAsync(m => m.ID == id);


  
    List<Product> RandomRelated = new List<Product>();
    List<Product> RandomRelatedCategory = new List<Product>();

    int RelatedItems = 0;
  

    List<int> number = new List<int>();
    bool NumberCheck = false;
    int check = product.ID;
    number.Add(check);
    

    multipleProducts.Product = product;
    multipleProducts.RelatedProducts = RandomRelated;

    if (product == null)
    {
        return NotFound();
    }

  

    Console.WriteLine("Foreach " + number.Count);
    foreach (var item in number)
    {
        Console.WriteLine("Number in list : " + item);
    }

    return View(multipleProducts);
}
    }
}


