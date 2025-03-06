using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CampPlanner.Models;


namespace CampPlanner.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CalendarView> CalendarViews { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<LocationFeature> LocationFeatures { get; set; }
        public DbSet<AppointmentRole> AppointmentRoles { get; set; }
        public DbSet<BookingParticipant> BookingParticipants { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Cascade: Används när den relaterade posten är beroende av den överordnade posten och bör tas bort automatiskt när den överordnade posten tas bort.
            // Restrict: Används när du vill förhindra att den överordnade posten tas bort om det finns relaterade poster.
            // Ingen åtgärd utförs på de relaterade posterna när den överordnade posten tas bort. Du måste hantera borttagningen av relaterade poster manuellt.
            
            // Specify OnDelete behavior for Event -> Organization relationship
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Events)
                .HasForeignKey(e => e.OrganizationId)
                .OnDelete(DeleteBehavior.NoAction);

            // Specify OnDelete behavior for Event -> Location relationship
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Location)
                .WithMany(l => l.Events)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE RESTRICT

            // Specify OnDelete behavior for Location -> Organization relationship
            modelBuilder.Entity<Location>()
                .HasOne(l => l.Organization)
                .WithMany(o => o.Locations)
                .HasForeignKey(l => l.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // Specify ON DELETE RESTRICT

            // Specify OnDelete behavior for Appointment -> Event relationship
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Event)
                .WithMany(e => e.Appointments)
                .HasForeignKey(a => a.EventId)
                .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE CASCADE.

            // Specify OnDelete behavior for Booking -> Event relationship
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.EventId)
                .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE CASCADE

            // Specify OnDelete behavior for CalendarView -> Event relationship
            modelBuilder.Entity<CalendarView>()
                .HasOne(cv => cv.Event)
                .WithMany(e => e.CalendarViews)
                .HasForeignKey(cv => cv.EventId)
                .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE CASCADE

            // Specify OnDelete behavior for Building -> Location relationship
            modelBuilder.Entity<Building>()
                .HasOne(b => b.Location)
                .WithMany(l => l.Buildings)
                .HasForeignKey(b => b.LocationId)
                .OnDelete(DeleteBehavior.Cascade); // Specify ON DELETE CASCADE

            // Specify OnDelete behavior for LocationFeature -> Location relationship
            modelBuilder.Entity<LocationFeature>()
                .HasOne(lf => lf.Location)
                .WithMany(l => l.Features)
                .HasForeignKey(lf => lf.LocationId)
                .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE CASCADE

            // Specify OnDelete behavior for AppointmentRole -> Appointment relationship
            modelBuilder.Entity<AppointmentRole>()
                .HasOne(ar => ar.Appointment)
                .WithMany(a => a.AppointmentRoles)
                .HasForeignKey(ar => ar.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE CASCADE

            // Specify OnDelete behavior for BookingParticipant -> Booking relationship
            modelBuilder.Entity<BookingParticipant>()
                .HasOne(bp => bp.Booking)
                .WithMany(b => b.Participants)
                .HasForeignKey(bp => bp.BookingId)
                .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE CASCADE

            // Specify OnDelete behavior for Room -> Building relationship
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Building)
                .WithMany(b => b.Rooms)
                .HasForeignKey(r => r.BuildingId)
                .OnDelete(DeleteBehavior.Cascade); // Specify ON DELETE CASCADE
        }
    }
}