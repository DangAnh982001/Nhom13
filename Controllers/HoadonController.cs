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
    public class HoadonController : Controller
    {
        private readonly ApplicationDbcontext _context;
        private StringProcess strPro = new StringProcess();

        public HoadonController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: Hoadon
        public async Task<IActionResult> Index()
        {
            var applicationDbcontext = _context.Hoadon.Include(h => h.Khachhang).Include(h => h.Sanpham);
            return View(await applicationDbcontext.ToListAsync());
        }

        // GET: Hoadon/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Hoadon == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadon
                .Include(h => h.Khachhang)
                .Include(h => h.Sanpham)
                .FirstOrDefaultAsync(m => m.MaHD == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // GET: Hoadon/Create
        public IActionResult Create()
        {
            ViewData["TenKH"] = new SelectList(_context.Khachhang, "MaKH", "TenKH");
            ViewData["TenSP"] = new SelectList(_context.Sanpham, "MaSP", "TenSP");

            var IDdautien = "HD01";
            var countAnh = _context.Hoadon.Count();
            if (countAnh > 0)
            {
                var MaHD = _context.Hoadon.OrderByDescending(m => m.MaHD).First().MaHD;
                IDdautien = strPro.AutoGenerateCode(MaHD);
            }
            ViewBag.newID = IDdautien;
            return View();
        }

        // POST: Hoadon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHD,TenKH,TenSP,SoluongHD")] Hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                hoadon.Ngayban = DateTime.Now;
                _context.Add(hoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenKH"] = new SelectList(_context.Khachhang, "MaKH", "TenKH", hoadon.TenKH);
            ViewData["TenSP"] = new SelectList(_context.Sanpham, "MaSP", "TenSP", hoadon.TenSP);
            return View(hoadon);
        }

        // GET: Hoadon/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Hoadon == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadon.FindAsync(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            ViewData["TenKH"] = new SelectList(_context.Khachhang, "MaKH", "TenKH", hoadon.TenKH);
            ViewData["TenSP"] = new SelectList(_context.Sanpham, "MaSP", "TenSP", hoadon.TenSP);
            return View(hoadon);
        }

        // POST: Hoadon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHD,TenKH,TenSP,SoluongHD,Ngayban")] Hoadon hoadon)
        {
            if (id != hoadon.MaHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoadonExists(hoadon.MaHD))
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
            ViewData["TenKH"] = new SelectList(_context.Khachhang, "MaKH", "TenKH", hoadon.TenKH);
            ViewData["TenSP"] = new SelectList(_context.Sanpham, "MaSP", "TenSP", hoadon.TenSP);
            return View(hoadon);
        }

        // GET: Hoadon/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Hoadon == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadon
                .Include(h => h.Khachhang)
                .Include(h => h.Sanpham)
                .FirstOrDefaultAsync(m => m.MaHD == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // POST: Hoadon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Hoadon == null)
            {
                return Problem("Entity set 'ApplicationDbcontext.Hoadon'  is null.");
            }
            var hoadon = await _context.Hoadon.FindAsync(id);
            if (hoadon != null)
            {
                _context.Hoadon.Remove(hoadon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoadonExists(string id)
        {
          return (_context.Hoadon?.Any(e => e.MaHD == id)).GetValueOrDefault();
        }
    }
}
