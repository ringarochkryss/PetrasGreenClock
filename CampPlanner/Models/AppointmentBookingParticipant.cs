namespace CampPlanner.Models
{
    public class AppointmentBookingParticipant
    {
        public int AppointmentId { get; set; } // Foreign key to Appointment
        public Appointment? Appointment { get; set; } // The appointment the participant is attending

        public int BookingParticipantId { get; set; } // Foreign key to BookingParticipant
        public BookingParticipant? BookingParticipant { get; set; } // The participant attending the appointment

        public int BookingParticipantRoleId { get; set; } // Foreign key to BookingParticipantRole
        public BookingParticipantRole? BookingParticipantRole { get; set; } // The role of the participant in this appointment
    }


}
