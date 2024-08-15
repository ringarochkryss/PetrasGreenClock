using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HappeningNow.Data;
using HappeningNow.Models;

namespace HappeningNow.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly HappeningNow.Data.ApplicationDbContext _context;

        public IndexModel(HappeningNow.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Team> Team { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Teams != null)
            {
                Team = await _context.Teams.ToListAsync();
            }
        }
    }
}
