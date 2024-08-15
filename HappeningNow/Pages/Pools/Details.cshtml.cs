using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HappeningNow.Data;
using HappeningNow.Models;

namespace HappeningNow.Pages.Pools
{
    public class DetailsModel : PageModel
    {
        private readonly HappeningNow.Data.ApplicationDbContext _context;

        public DetailsModel(HappeningNow.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Pool Pool { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pools == null)
            {
                return NotFound();
            }

            var pool = await _context.Pools.FirstOrDefaultAsync(m => m.Id == id);
            if (pool == null)
            {
                return NotFound();
            }
            else 
            {
                Pool = pool;
            }
            return Page();
        }
    }
}
