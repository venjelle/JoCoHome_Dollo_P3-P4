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
    public class NieuwsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NieuwsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nieuws
        public async Task<IActionResult> Index(string searchString)
        {
            var Nieuws = from m in _context.Nieuws
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Nieuws = Nieuws.Where(s => s.Titel.Contains(searchString));
            }

            return View(await Nieuws.ToListAsync());
        }

        // GET: Nieuws/Details/5
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

        // GET: Nieuws/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nieuws/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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

        // GET: Nieuws/Edit/5
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

        // POST: Nieuws/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Nieuws/Delete/5
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

        // POST: Nieuws/Delete/5
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


        public async Task<IActionResult> Detailpagina(int? id)
        {
            MultipleNieuws multipleNieuws = new MultipleNieuws();
            if (id == null)
            {
                return NotFound();
            }

            var Nieuws = await _context.Nieuws
                  .FirstOrDefaultAsync(m => m.ID == id);



            List<Nieuws> RandomRelated = new List<Nieuws>();
            List<Nieuws> RandomRelatedCategory = new List<Nieuws>();

            int RelatedItems = 0;


            List<int> number = new List<int>();
            bool NumberCheck = false;
            int check = Nieuws.ID;
            number.Add(check);


            multipleNieuws.Nieuws = Nieuws;
            multipleNieuws.RelatedNieuws = RandomRelated;

            if (Nieuws == null)
            {
                return NotFound();
            }



            Console.WriteLine("Foreach " + number.Count);
            foreach (var item in number)
            {
                Console.WriteLine("Number in list : " + item);
            }

            return View(multipleNieuws);
        }
    }
}
