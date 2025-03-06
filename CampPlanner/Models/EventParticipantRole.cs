namespace CampPlanner.Models
{

    public class EventParticipantRole
    {
        public int Id { get; set; } // Unique ID for the role
        public string? RoleName { get; set; } // Name of the role (e.g., "Speaker", "Attendee")
        public string? Description { get; set; } // Optional description for the role
        public string? RoleIcon{ get; set; }  //Icon
        
        // Relationer
        public List<BookingParticipantRole>? BookingParticipantRoles { get; set; } // De roller som är tilldelade deltagare
        public List<AppointmentRole>? AppointmentRoles { get; set; } // De roller som är tilldelade deltagare för appointments
    }


}
