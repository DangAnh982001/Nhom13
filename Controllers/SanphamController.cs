using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom13.Models;
using Nhom13.Models.Process;

namespace Nhom13.Controllers
{
    public class SanphamController : Controller
    {
        private readonly ApplicationDbcontext _context;
        private StringProcess strPro = new StringProcess();

        public SanphamController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: Sanpham
        // public async Task<IActionResult> Index()
        // {
        //       return _context.Sanpham != null ? 
        //                   View(await _context.Sanpham.ToListAsync()) :
        //                   Problem("Entity set 'ApplicationDbcontext.Sanpham'  is null.");
        // }
        public async Task<IActionResult> Index(string searchString)
        {
            var Sanpham = from m in _context.Sanpham
                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Sanpham = Sanpham.Where(s => s.TenSP!.Contains(searchString));
                }
            return View(await Sanpham.ToListAsync());
        }

        // GET: Sanpham/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Sanpham/Create
        public IActionResult Create()
        {
            var IDdautien = "SP01";
            var countAnh = _context.Sanpham.Count();
            if (countAnh > 0)
            {
                var MaSP = _context.Sanpham.OrderByDescending(m => m.MaSP).First().MaSP;
                IDdautien = strPro.AutoGenerateCode(MaSP);
            }
            ViewBag.newID = IDdautien;
            return View();
        }

        // POST: Sanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSP,TenSP,GiaSP")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanpham);
        }

        // GET: Sanpham/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            return View(sanpham);
        }

        // POST: Sanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSP,TenSP,GiaSP")] Sanpham sanpham)
        {
            if (id != sanpham.MaSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.MaSP))
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
            return View(sanpham);
        }

        // GET: Sanpham/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Sanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Sanpham == null)
            {
                return Problem("Entity set 'ApplicationDbcontext.Sanpham'  is null.");
            }
            var sanpham = await _context.Sanpham.FindAsync(id);
            if (sanpham != null)
            {
                _context.Sanpham.Remove(sanpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(string id)
        {
          return (_context.Sanpham?.Any(e => e.MaSP == id)).GetValueOrDefault();
        }
    }
}
