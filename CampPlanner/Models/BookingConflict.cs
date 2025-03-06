using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CampPlanner.Models
{
    // BookingConflict.cs
    public class BookingConflict
    {
        public int Id { get; set; } // Unique ID for the conflict entry

        public int BookingParticipantId { get; set; } // Foreign key to BookingParticipant (Deltagaren som är bokad)
        public BookingParticipant? BookingParticipant { get; set; } // The participant who is booked

        public int AppointmentId { get; set; } // Foreign key to Appointment
        public Appointment? Appointment { get; set; } // The appointment (aktiviteten) the participant is booked for

        public int? RoomId { get; set; } // Foreign key to Room (Kan vara null om inget rum behövs)
        public Room? Room { get; set; } // The room the participant is booked for (kan vara null för vissa bokningar)

        public DateTime StartTime { get; set; } // Start time of the booking
        public DateTime EndTime { get; set; } // End time of the booking
    }

}
