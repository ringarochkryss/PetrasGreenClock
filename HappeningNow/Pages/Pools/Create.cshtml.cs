using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HappeningNow.Data;
using HappeningNow.Models;

namespace HappeningNow.Pages.Pools
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
        public Pool Pool { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Pools == null || Pool == null)
            {
                return Page();
            }

            _context.Pools.Add(Pool);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
