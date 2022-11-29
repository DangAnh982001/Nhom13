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
    public class NhanvienController : Controller
    {
        private readonly ApplicationDbcontext _context;

        public NhanvienController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: Nhanvien
        public async Task<IActionResult> Index()
        {
              return _context.Nhanvien != null ? 
                          View(await _context.Nhanvien.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbcontext.Nhanvien'  is null.");
        }

        // GET: Nhanvien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhanvien == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: Nhanvien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNV,TenNV,NgaysinhNV,SdtNV,DiachiNV,EmailNV")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanvien);
        }

        // GET: Nhanvien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhanvien == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }

        // POST: Nhanvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNV,TenNV,NgaysinhNV,SdtNV,DiachiNV,EmailNV")] Nhanvien nhanvien)
        {
            if (id != nhanvien.MaNV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.MaNV))
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
            return View(nhanvien);
        }

        // GET: Nhanvien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nhanvien == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: Nhanvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nhanvien == null)
            {
                return Problem("Entity set 'ApplicationDbcontext.Nhanvien'  is null.");
            }
            var nhanvien = await _context.Nhanvien.FindAsync(id);
            if (nhanvien != null)
            {
                _context.Nhanvien.Remove(nhanvien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(string id)
        {
          return (_context.Nhanvien?.Any(e => e.MaNV == id)).GetValueOrDefault();
        }
    }
}
