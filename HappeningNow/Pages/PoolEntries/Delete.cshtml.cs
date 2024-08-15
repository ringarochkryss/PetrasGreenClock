using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HappeningNow.Data;
using HappeningNow.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HappeningNow.Pages.PoolEntries
{
    public class DeleteModel : PageModel
    {
        private readonly HappeningNow.Data.ApplicationDbContext _context;

        public DeleteModel(HappeningNow.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PoolEntry PoolEntry { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PoolEntry = _context.PoolEntries.FirstOrDefault(m => m.Id == id);

            if (PoolEntry == null)
            {
                return NotFound();
            }

            ViewData["DisciplineId"] = new SelectList(_context.Disciplines, "Id", "Name");
            ViewData["PoolId"] = new SelectList(_context.Pools, "Id", "Name");
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.PoolEntries == null || PoolEntry == null)
            {
                return NotFound();
            }

            _context.PoolEntries.Remove(PoolEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
