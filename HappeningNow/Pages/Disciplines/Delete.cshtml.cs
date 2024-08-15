using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HappeningNow.Data;
using HappeningNow.Models;

namespace HappeningNow.Pages.Disciplines
{
    public class DeleteModel : PageModel
    {
        private readonly HappeningNow.Data.ApplicationDbContext _context;

        public DeleteModel(HappeningNow.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Discipline Discipline { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Disciplines == null)
            {
                return NotFound();
            }

            var discipline = await _context.Disciplines.FirstOrDefaultAsync(m => m.Id == id);

            if (discipline == null)
            {
                return NotFound();
            }
            else 
            {
                Discipline = discipline;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Disciplines == null)
            {
                return NotFound();
            }
            var discipline = await _context.Disciplines.FindAsync(id);

            if (discipline != null)
            {
                Discipline = discipline;
                _context.Disciplines.Remove(Discipline);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
