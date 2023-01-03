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
    public class NhaphangController : Controller
    {
        private readonly ApplicationDbcontext _context;

        public NhaphangController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: Nhaphang
        public async Task<IActionResult> Index()
        {
            var applicationDbcontext = _context.Nhaphang.Include(n => n.Nhacungcap).Include(n => n.Nhanvien).Include(n => n.Sanpham);
            return View(await applicationDbcontext.ToListAsync());
        }

        // GET: Nhaphang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhaphang == null)
            {
                return NotFound();
            }

            var nhaphang = await _context.Nhaphang
                .Include(n => n.Nhacungcap)
                .Include(n => n.Nhanvien)
                .Include(n => n.Sanpham)
                .FirstOrDefaultAsync(m => m.IDNH == id);
            if (nhaphang == null)
            {
                return NotFound();
            }

            return View(nhaphang);
        }

        // GET: Nhaphang/Create
        public IActionResult Create()
        {
            ViewData["TenNCC"] = new SelectList(_context.Nhacungcap, "MaNCC", "MaNCC");
            ViewData["TenNV"] = new SelectList(_context.Nhanvien, "MaNV", "MaNV");
            ViewData["TenSP"] = new SelectList(_context.Sanpham, "MaSP", "MaSP");
            return View();
        }

        // POST: Nhaphang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDNH,TenSP,SoluongSP,TenNCC,TenNV,NgaynhapSP")] Nhaphang nhaphang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaphang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenNCC"] = new SelectList(_context.Nhacungcap, "MaNCC", "MaNCC", nhaphang.TenNCC);
            ViewData["TenNV"] = new SelectList(_context.Nhanvien, "MaNV", "MaNV", nhaphang.TenNV);
            ViewData["TenSP"] = new SelectList(_context.Sanpham, "MaSP", "MaSP", nhaphang.TenSP);
            return View(nhaphang);
        }

        // GET: Nhaphang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhaphang == null)
            {
                return NotFound();
            }

            var nhaphang = await _context.Nhaphang.FindAsync(id);
            if (nhaphang == null)
            {
                return NotFound();
            }
            ViewData["TenNCC"] = new SelectList(_context.Nhacungcap, "MaNCC", "MaNCC", nhaphang.TenNCC);
            ViewData["TenNV"] = new SelectList(_context.Nhanvien, "MaNV", "MaNV", nhaphang.TenNV);
            ViewData["TenSP"] = new SelectList(_context.Sanpham, "MaSP", "MaSP", nhaphang.TenSP);
            return View(nhaphang);
        }

        // POST: Nhaphang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDNH,TenSP,SoluongSP,TenNCC,TenNV,NgaynhapSP")] Nhaphang nhaphang)
        {
            if (id != nhaphang.IDNH)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaphang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaphangExists(nhaphang.IDNH))
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
            ViewData["TenNCC"] = new SelectList(_context.Nhacungcap, "MaNCC", "MaNCC", nhaphang.TenNCC);
            ViewData["TenNV"] = new SelectList(_context.Nhanvien, "MaNV", "MaNV", nhaphang.TenNV);
            ViewData["TenSP"] = new SelectList(_context.Sanpham, "MaSP", "MaSP", nhaphang.TenSP);
            return View(nhaphang);
        }

        // GET: Nhaphang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nhaphang == null)
            {
                return NotFound();
            }

            var nhaphang = await _context.Nhaphang
                .Include(n => n.Nhacungcap)
                .Include(n => n.Nhanvien)
                .Include(n => n.Sanpham)
                .FirstOrDefaultAsync(m => m.IDNH == id);
            if (nhaphang == null)
            {
                return NotFound();
            }

            return View(nhaphang);
        }

        // POST: Nhaphang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nhaphang == null)
            {
                return Problem("Entity set 'ApplicationDbcontext.Nhaphang'  is null.");
            }
            var nhaphang = await _context.Nhaphang.FindAsync(id);
            if (nhaphang != null)
            {
                _context.Nhaphang.Remove(nhaphang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaphangExists(string id)
        {
          return (_context.Nhaphang?.Any(e => e.IDNH == id)).GetValueOrDefault();
        }
    }
}
