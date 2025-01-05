using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Byggkontakter.Data;
using Byggkontakter.Models;

namespace Byggkontakter.Pages.Roles
{
    public class EditModel : PageModel
    {
        private readonly Byggkontakter.Data.ApplicationDbContext _context;

        public EditModel(Byggkontakter.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Roles Roles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles =  await _context.CustomRoles.FirstOrDefaultAsync(m => m.Id == id);
            if (roles == null)
            {
                return NotFound();
            }
            Roles = roles;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Roles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesExists(Roles.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RolesExists(int id)
        {
            return _context.CustomRoles.Any(e => e.Id == id);
        }
    }
}
