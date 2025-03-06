namespace CampPlanner.Models
{
    public class Person
    {
        public int Id { get; set; } // Unique ID for the person
        public required string Name { get; set; } // Person's name
        public string? Email { get; set; } // Person's email address
        public string? Phone { get; set; } // Person's phone number
        public string? Allergy { get; set; } // Allergies information
        public string? Note { get; set; } // General note
        public string? AdminNote { get; set; } // Admin-specific note
        public int Cost { get; set; } // Cost related to the person (e.g., registration fee)
        public bool IsPaid { get; set; } // Whether the person has paid or not
        public List<BookingParticipant>? BookingParticipants { get; set; } // A person can be a participant in multiple bookings
    }


}
