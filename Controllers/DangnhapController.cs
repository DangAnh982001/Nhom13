using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom13.Models;

namespace Nhom13.Controllers
{
    public class DangnhapController : Controller
    {
        private readonly ApplicationDbcontext _context;

        public DangnhapController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: Dangnhap
        public async Task<IActionResult> Index()
        {
              return _context.Dangnhap != null ? 
                          View(await _context.Dangnhap.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbcontext.Dangnhap'  is null.");
        }

        // GET: Dangnhap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dangnhap == null)
            {
                return NotFound();
            }

            var dangnhap = await _context.Dangnhap
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (dangnhap == null)
            {
                return NotFound();
            }

            return View(dangnhap);
        }

        // GET: Dangnhap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dangnhap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,userName,Password")] Dangnhap dangnhap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangnhap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dangnhap);
        }

        // GET: Dangnhap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dangnhap == null)
            {
                return NotFound();
            }

            var dangnhap = await _context.Dangnhap.FindAsync(id);
            if (dangnhap == null)
            {
                return NotFound();
            }
            return View(dangnhap);
        }

        // POST: Dangnhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,userName,Password")] Dangnhap dangnhap)
        {
            if (id != dangnhap.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangnhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangnhapExists(dangnhap.UserID))
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
            return View(dangnhap);
        }

        // GET: Dangnhap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dangnhap == null)
            {
                return NotFound();
            }

            var dangnhap = await _context.Dangnhap
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (dangnhap == null)
            {
                return NotFound();
            }

            return View(dangnhap);
        }

        // POST: Dangnhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dangnhap == null)
            {
                return Problem("Entity set 'ApplicationDbcontext.Dangnhap'  is null.");
            }
            var dangnhap = await _context.Dangnhap.FindAsync(id);
            if (dangnhap != null)
            {
                _context.Dangnhap.Remove(dangnhap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangnhapExists(int id)
        {
          return (_context.Dangnhap?.Any(e => e.UserID == id)).GetValueOrDefault();
        }
    }
}
