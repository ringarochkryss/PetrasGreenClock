using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HappeningNow.Data;
using HappeningNow.Models;

namespace HappeningNow.Pages.PoolEntries
{
    public class IndexModel : PageModel
    {
        private readonly HappeningNow.Data.ApplicationDbContext _context;

        public IndexModel(HappeningNow.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PoolEntry> PoolEntries { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedPoolId { get; set; }

        public SelectList PoolItems { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PoolOrder { get; set; }

        public async Task OnGetAsync()
        {
            var poolEntries = _context.PoolEntries
                .Include(p => p.Discipline)
                .Include(p => p.Pool)
                .Include(p => p.Team)
                .AsQueryable();

            if (SelectedPoolId.HasValue)
            {
                poolEntries = poolEntries.Where(p => p.PoolId == SelectedPoolId);
            }

            PoolEntries = await poolEntries
                .OrderBy(p => PoolOrder == "desc" ? p.Order : -p.Order)
                .ToListAsync();

            // Populate select list for dropdown
            PoolItems = new SelectList(_context.Pools, "Id", "Name", SelectedPoolId);
        }
    }
}
