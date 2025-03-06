namespace CampPlanner.Models
{
    // BookingParticipant.cs

    public class BookingParticipant
    {
        public int Id { get; set; } // Unique ID for the booking participant
        public int BookingId { get; set; } // Foreign key for the booking
        public Booking? Booking { get; set; } // The booking this participant is part of
        public int PersonId { get; set; } // Foreign key for the person
        public Person? Person { get; set; } // The person associated with this booking
        public bool IsMainParticipant { get; set; } // Whether the person is the main participant or not

        public string? RoomRequest { get; set; } // Any special requests for room (e.g., "single room")
        public string? FurnitureRequest { get; set; } // Any special requests for furniture (e.g., "single bed")
       
        // Koppling till rum och möbel
        public int? RoomId { get; set; } // Foreign key for the room (nullable if not assigned yet)
        public Room? Room { get; set; } // The room the participant is assigned to


        public int? FurnitureId { get; set; } // Foreign key for the furniture (nullable if not assigned yet)
        public Furniture? Furniture { get; set; } // The furniture (e.g., bed) assigned to the participant

        // Nytt: Roller i bokningen
        // Relationer
        public List<BookingParticipantRole>? BookingParticipantRoles { get; set; } // Roller som deltagaren kan ha i eventet
        public List<AppointmentRole>? AppointmentRoles { get; set; } // Roller som tilldelas för appointments
    }


}
