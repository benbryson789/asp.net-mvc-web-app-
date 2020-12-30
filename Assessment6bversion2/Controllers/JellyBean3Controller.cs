using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assessment6bversion2.Data;

namespace Assessment6bversion2.Controllers
{
    public class JellyBean3Controller : Controller
    {
        private readonly JellyBean3DbContext _context;

        public JellyBean3Controller(JellyBean3DbContext context)
        {
            _context = context;
        }

        // GET: JellyBean3
        public async Task<IActionResult> Index()
        {
            return View(await _context.JellyBean3.ToListAsync());
        }

        // GET: JellyBean3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jellyBean3 = await _context.JellyBean3
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jellyBean3 == null)
            {
                return NotFound();
            }

            return View(jellyBean3);
        }

        // GET: JellyBean3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JellyBean3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Style,Rating")] JellyBean3 jellyBean3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jellyBean3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jellyBean3);
        }

        // GET: JellyBean3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jellyBean3 = await _context.JellyBean3.FindAsync(id);
            if (jellyBean3 == null)
            {
                return NotFound();
            }
            return View(jellyBean3);
        }

        // POST: JellyBean3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Style,Rating")] JellyBean3 jellyBean3)
        {
            if (id != jellyBean3.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jellyBean3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JellyBean3Exists(jellyBean3.Id))
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
            return View(jellyBean3);
        }

        // GET: JellyBean3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jellyBean3 = await _context.JellyBean3
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jellyBean3 == null)
            {
                return NotFound();
            }

            return View(jellyBean3);
        }

        // POST: JellyBean3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jellyBean3 = await _context.JellyBean3.FindAsync(id);
            _context.JellyBean3.Remove(jellyBean3);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JellyBean3Exists(int id)
        {
            return _context.JellyBean3.Any(e => e.Id == id);
        }
    }
}
