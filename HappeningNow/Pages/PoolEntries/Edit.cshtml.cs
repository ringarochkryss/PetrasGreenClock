using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HappeningNow.Data;
using HappeningNow.Models;

namespace HappeningNow.Pages.PoolEntries
{
    public class EditModel : PageModel
    {
        private readonly HappeningNow.Data.ApplicationDbContext _context;

        public EditModel(HappeningNow.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PoolEntry PoolEntry { get; set; }

        public SelectList PoolItems { get; set; }
        public SelectList TeamItems { get; set; }
        public SelectList DisciplineItems { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PoolEntry = await _context.PoolEntries
                .Include(p => p.Discipline)
                .Include(p => p.Pool)
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (PoolEntry == null)
            {
                return NotFound();
            }

            // Populate select lists for dropdowns
            PoolItems = new SelectList(_context.Pools, "Id", "Name", PoolEntry.PoolId);
            TeamItems = new SelectList(_context.Teams, "Id", "Name", PoolEntry.TeamId);
            DisciplineItems = new SelectList(_context.Disciplines, "Id", "Name", PoolEntry.DisciplineId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Populate select lists again for redisplaying the form with validation errors
                PoolItems = new SelectList(_context.Pools, "Id", "Name", PoolEntry.PoolId);
                TeamItems = new SelectList(_context.Teams, "Id", "Name", PoolEntry.TeamId);
                DisciplineItems = new SelectList(_context.Disciplines, "Id", "Name", PoolEntry.DisciplineId);

                return Page();
            }

            _context.Attach(PoolEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PoolEntries.Any(e => e.Id == PoolEntry.Id))
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
    }
}
