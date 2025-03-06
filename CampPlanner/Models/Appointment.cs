namespace CampPlanner.Models
{
    public class Appointment
    {
        public int Id { get; set; } // Unique ID for the appointment
        public string? Activity { get; set; } // Activity name (e.g., "AI Workshop")
        public List<Room>? Rooms { get; set; } // Om flera rum används för samma appointment
        public DateTime Day { get; set; } // Date for the appointment
        public TimeSpan TimeFrom { get; set; } // Start time
        public TimeSpan TimeTo { get; set; } // End time
        public string? Note { get; set; } // Additional notes

        // Relation till Event
        public int EventId { get; set; } // Foreign key to Event
        public Event? Event { get; set; } // The event this appointment belongs to

        // Relation till AppointmentRole
        public List<AppointmentRole>? AppointmentRoles { get; set; } // Roles for this appointment
    }




}
