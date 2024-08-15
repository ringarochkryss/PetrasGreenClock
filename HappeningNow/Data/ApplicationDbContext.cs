using HappeningNow.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HappeningNow.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pool> Pools { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PoolEntry> PoolEntries { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
    }
}