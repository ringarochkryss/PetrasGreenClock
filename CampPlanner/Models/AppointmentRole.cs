namespace CampPlanner.Models
{
    // AppointmentRole.cs
    public class AppointmentRole
    {
        public int Id { get; set; } // Unique ID for the appointment role
        public int AppointmentId { get; set; } // Foreign key to Appointment
        public Appointment? Appointment { get; set; } // The appointment for which the role is assigned

        public int BookingParticipantId { get; set; } // Foreign key to BookingParticipant
        public BookingParticipant? BookingParticipant { get; set; } // The participant assigned to this role for the appointment

        public int EventParticipantRoleId { get; set; } // Foreign key to EventParticipantRole
        public EventParticipantRole? EventParticipantRole { get; set; } // The role the participant has for the appointment
    }

}
