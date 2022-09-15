using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using EmployeeManagement.Models.DB;

namespace EmployeeManagement.Controllers
{
    public class TimeSheetsController : Controller
    {
        private readonly EmployeeManagementContext _context;

        public TimeSheetsController(EmployeeManagementContext context)
        {
            _context = context;
        }

        // GET: TimeSheets
        public async Task<IActionResult> Index()
        {
              return _context.TimeSheet != null ? 
                          View(await _context.TimeSheet.ToListAsync()) :
                          Problem("Entity set 'EmployeeManagementContext.TimeSheet'  is null.");
        }

        // GET: TimeSheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TimeSheet == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.TimeSheet
                .FirstOrDefaultAsync(m => m.TimeSheetID == id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            return View(timeSheet);
        }

        // GET: TimeSheets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeSheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeSheetID,date,Status")] TimeSheet timeSheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeSheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeSheet);
        }

        // GET: TimeSheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TimeSheet == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.TimeSheet.FindAsync(id);
            if (timeSheet == null)
            {
                return NotFound();
            }
            return View(timeSheet);
        }

        // POST: TimeSheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeSheetID,date,Status")] TimeSheet timeSheet)
        {
            if (id != timeSheet.TimeSheetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeSheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSheetExists(timeSheet.TimeSheetID))
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
            return View(timeSheet);
        }

        // GET: TimeSheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TimeSheet == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.TimeSheet
                .FirstOrDefaultAsync(m => m.TimeSheetID == id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            return View(timeSheet);
        }

        // POST: TimeSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TimeSheet == null)
            {
                return Problem("Entity set 'EmployeeManagementContext.TimeSheet'  is null.");
            }
            var timeSheet = await _context.TimeSheet.FindAsync(id);
            if (timeSheet != null)
            {
                _context.TimeSheet.Remove(timeSheet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSheetExists(int id)
        {
          return (_context.TimeSheet?.Any(e => e.TimeSheetID == id)).GetValueOrDefault();
        }
    }
}
