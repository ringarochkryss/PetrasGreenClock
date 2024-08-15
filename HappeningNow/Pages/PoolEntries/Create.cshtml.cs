using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HappeningNow.Data;
using HappeningNow.Models;

namespace HappeningNow.Pages.PoolEntries
{
    public class CreateModel : PageModel
    {
        private readonly HappeningNow.Data.ApplicationDbContext _context;

        public CreateModel(HappeningNow.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DisciplineId"] = new SelectList(_context.Disciplines, "Id", "Name");
            ViewData["PoolId"] = new SelectList(_context.Pools, "Id", "Name");
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public PoolEntry PoolEntry { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.PoolEntries == null || PoolEntry == null)
            {
                return Page();
            }

            _context.PoolEntries.Add(PoolEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}
