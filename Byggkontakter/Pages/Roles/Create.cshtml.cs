using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Byggkontakter.Data;
using Byggkontakter.Models;

namespace Byggkontakter.Pages.Roles
{
    public class CreateModel : PageModel
    {
        private readonly Byggkontakter.Data.ApplicationDbContext _context;

        public CreateModel(Byggkontakter.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Roles Roles { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CustomRoles.Add(Roles);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
