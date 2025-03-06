namespace CampPlanner.Models
{
    public class Event
    {
        public int Id { get; set; } // Unikt ID för eventet
        public required string Name { get; set; } // Namnet på eventet
        public string? Description { get; set; } // Beskrivning av eventet
        public DateTime StartDate { get; set; } // Startdatum för eventet
        public DateTime EndDate { get; set; } // Slutdatum för eventet
        public DateTime CreatedAt { get; set; } // Datum och tid när eventet skapades
        public DateTime? UpdatedAt { get; set; } // Datum och tid när eventet senast uppdaterades
        public int LocationId { get; set; }  // Foreign key till Location
        public Location? Location { get; set; } // Relationen till Location-tabellen
        public string? EventImage { get; set; } // Länk eller byte för eventets bild (t.ex. för att visa på webbplatsen)
        public bool VisibleForAll { get; set; } // Anger om eventet är synligt för alla användare
        public string? BookingEventPassword { get; set; } // Lösenord som måste anges för att få registrera sig på eventet
        public bool BookingForParticipantsAllowedEvent { get; set; } // Anger om deltagarna själva får boka in sig på eventet
        public bool BookingForParticipantsAllowedRooms { get; set; } // Anger om deltagarna själva får boka in sig i Rum
        public bool BookingForParticipantsAllowedAppointments { get; set; } // Anger om deltagarna själva får boka in sig på aktiviteter
        public int OrganizationId { get; set; } // Kopplad till den organisation som arrangerar eventet
        public Organization? Organization { get; set; } // Navigation property till den tillhörande organisationen

        // Relaterade entiteter
        public ICollection<Booking>? Bookings { get; set; } // Bokningar för eventet (deltagare som anmäler sig)
        public ICollection<Appointment>? Appointments { get; set; } // Alla schemalagda aktiviteter under eventet (workshops, föreläsningar, etc.)
        public ICollection<CalendarView>? CalendarViews { get; set; } // De olika kalenderöversikterna som kan visas för eventet
    }


}
