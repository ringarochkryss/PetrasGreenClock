namespace CampPlanner.Models
{
    // Booking.cs
    public class Booking
    {
        public int Id { get; set; } // Unique ID for the booking
        public string? BookingNumber { get; set; } // Unique booking number (can be a string like "ABC123")
        public int EventId { get; set; } // Associated event
        public Event? Event { get; set; } // The event the booking is for
        public DateTime StartDate { get; set; } // The start date for the stay
        public DateTime EndDate { get; set; } // The end date for the stay
        public List<BookingParticipant>? Participants { get; set; } // List of participants in the booking (including the main person and their friends)
    }

}
