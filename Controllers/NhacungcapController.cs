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
    public class NhacungcapController : Controller
    {
        private readonly ApplicationDbcontext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();


    private StringProcess strPro = new StringProcess();
        public NhacungcapController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: Nhacungcap
        // public async Task<IActionResult> Index()
        // {
        //       return _context.Nhacungcap != null ? 
        //                   View(await _context.Nhacungcap.ToListAsync()) :
        //                   Problem("Entity set 'ApplicationDbcontext.Nhacungcap'  is null.");
        // }
        public async Task<IActionResult> Index(string searchString)
        {
            var Nhacungcap = from m in _context.Nhacungcap
                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Nhacungcap = Nhacungcap.Where(s => s.TenNCC!.Contains(searchString));
                }

            return View(await Nhacungcap.ToListAsync());
        }

        // GET: Nhacungcap/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhacungcap == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcap
                .FirstOrDefaultAsync(m => m.MaNCC == id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // GET: Nhacungcap/Create
        public IActionResult Create()
        {
            var IDdautien = "NCC01";
            var countAnh = _context.Nhacungcap.Count();
            if (countAnh > 0)
            {
                var MaNCC = _context.Nhacungcap.OrderByDescending(m => m.MaNCC).First().MaNCC;
                IDdautien = strPro.AutoGenerateCode(MaNCC);
            }
            ViewBag.newID = IDdautien;
            return View();
        }

        // POST: Nhacungcap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNCC,TenNCC,SdtNCC,DiachiNCC,EmailNCC")] Nhacungcap nhacungcap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhacungcap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhacungcap);
        }

        // GET: Nhacungcap/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhacungcap == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcap.FindAsync(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            return View(nhacungcap);
        }

        // POST: Nhacungcap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNCC,TenNCC,SdtNCC,DiachiNCC,EmailNCC")] Nhacungcap nhacungcap)
        {
            if (id != nhacungcap.MaNCC)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhacungcap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhacungcapExists(nhacungcap.MaNCC))
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
            return View(nhacungcap);
        }

        // GET: Nhacungcap/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nhacungcap == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcap
                .FirstOrDefaultAsync(m => m.MaNCC == id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // POST: Nhacungcap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nhacungcap == null)
            {
                return Problem("Entity set 'ApplicationDbcontext.Nhacungcap'  is null.");
            }
            var nhacungcap = await _context.Nhacungcap.FindAsync(id);
            if (nhacungcap != null)
            {
                _context.Nhacungcap.Remove(nhacungcap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhacungcapExists(string id)
        {
          return (_context.Nhacungcap?.Any(e => e.MaNCC == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    var FileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", FileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to sever
                        await file.CopyToAsync(stream);
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            var dakh = new Nhacungcap();

                            dakh.MaNCC = dt.Rows[i][0].ToString();
                            dakh.TenNCC = dt.Rows[i][1].ToString();
                            dakh.SdtNCC = dt.Rows[i][2].ToString();
                            dakh.DiachiNCC = dt.Rows[i][3].ToString();
                           

                            _context.Nhacungcap.Add(dakh);
                        }
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
    }
    }}