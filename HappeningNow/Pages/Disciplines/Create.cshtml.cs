using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HappeningNow.Data;
using HappeningNow.Models;

namespace HappeningNow.Pages.Disciplines
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
            return Page();
        }

        [BindProperty]
        public Discipline Discipline { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Disciplines == null || Discipline == null)
            {
                return Page();
            }

            _context.Disciplines.Add(Discipline);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
