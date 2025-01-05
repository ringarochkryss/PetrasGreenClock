using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Byggkontakter.Data;
using Byggkontakter.Models;

namespace Byggkontakter.Pages.Roles
{
    public class DetailsModel : PageModel
    {
        private readonly Byggkontakter.Data.ApplicationDbContext _context;

        public DetailsModel(Byggkontakter.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Roles Roles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _context.CustomRoles.FirstOrDefaultAsync(m => m.Id == id);
            if (roles == null)
            {
                return NotFound();
            }
            else
            {
                Roles = roles;
            }
            return Page();
        }
    }
}
