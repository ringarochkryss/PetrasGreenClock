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
    public class IndexModel : PageModel
    {
        private readonly Byggkontakter.Data.ApplicationDbContext _context;

        public IndexModel(Byggkontakter.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Pages_Roles_Index> Roles { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Roles = (IList<Pages_Roles_Index>)await _context.CustomRoles.ToListAsync();
        }
    }
}
