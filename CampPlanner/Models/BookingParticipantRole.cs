namespace CampPlanner.Models
{
    // BookingParticipantRole.cs
    public class BookingParticipantRole
    {
        public int Id { get; set; } // Unique ID for the booking participant role
        public int BookingParticipantId { get; set; } // Foreign key for the booking participant
        public BookingParticipant? BookingParticipant { get; set; } // The booking participant associated with this role
        public int EventParticipantRoleId { get; set; } // Foreign key for the event participant role (e.g., "Speaker", "Attendee")
        public EventParticipantRole? EventParticipantRole { get; set; } // The role assigned to the participant in this booking
    }

}
