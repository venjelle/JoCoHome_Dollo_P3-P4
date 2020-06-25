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
    public class NieuwsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NieuwsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Nieuws
        [Route("Admin/Nieuws")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nieuws.ToListAsync());
        }

        // GET: Admin/Nieuws/Details/5
        [Route("Admin/Nieuws/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nieuws = await _context.Nieuws
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nieuws == null)
            {
                return NotFound();
            }

            return View(nieuws);
        }

        // GET: Admin/Nieuws/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Nieuws/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Admin/Nieuws/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titel,Inleiding,Schrijver,Datum,Inhoud,Foto")] Nieuws nieuws)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nieuws);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nieuws);
        }

        // GET: Admin/Nieuws/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nieuws = await _context.Nieuws.FindAsync(id);
            if (nieuws == null)
            {
                return NotFound();
            }
            return View(nieuws);
        }

        // POST: Admin/Nieuws/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Admin/Nieuws/Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titel,Inleiding,Schrijver,Datum,Inhoud,Foto")] Nieuws nieuws)
        {
            if (id != nieuws.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nieuws);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NieuwsExists(nieuws.ID))
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
            return View(nieuws);
        }

        // GET: Admin/Nieuws/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nieuws = await _context.Nieuws
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nieuws == null)
            {
                return NotFound();
            }

            return View(nieuws);
        }

        // POST: Admin/Nieuws/Delete/5
        [Route("Admin/Nieuws/Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nieuws = await _context.Nieuws.FindAsync(id);
            _context.Nieuws.Remove(nieuws);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NieuwsExists(int id)
        {
            return _context.Nieuws.Any(e => e.ID == id);
        }
    }
}
