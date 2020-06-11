using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JoCoHome_Dollo.Data;
using JoCoHome_Dollo.Models;

namespace JoCoHome_Dollo.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class ProductAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ProductAdmin
        [Route("Admin/ProductAdmin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Admin/ProductAdmin/Details/5
        [Route("Admin/ProductAdmin/Details")]
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

        // GET: Admin/ProductAdmin/Create
        //[Route("Admin/ProductAdmin/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Admin/ProductAdmin/Create")]
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

        // GET: Admin/ProductAdmin/Edit/5
      
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

        // POST: Admin/ProductAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("admin/ProductAdmin/Edit")]
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

        // GET: Admin/ProductAdmin/Delete/5
        
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

        // POST: Admin/ProductAdmin/Delete/5
        [Route("Admin/ProductAdmin/Delete")]
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
    }
}
