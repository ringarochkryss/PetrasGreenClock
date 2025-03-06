namespace CampPlanner.Models
{
    public class CalendarView
    {
        public int Id { get; set; } // Unikt ID för kalendern
        public required string Name { get; set; } // Kalendernamn, t.ex. "Konferenslokaler"
        public int EventId { get; set; } // Koppling till eventet
        public required Event Event { get; set; } // Eventet som denna kalender är kopplad till
        public bool VisibleForAll { get; set; } // Anger om kalendern är synlig för alla eller inte

        // En kalender kan ha flera rader (t.ex. rum eller personer)
        public required List<CalendarRow> CalendarRows { get; set; }
    }

    public class CalendarRow
    {
        public int Id { get; set; } // Unikt ID för raden
        public int CalendarViewId { get; set; } // Kalendern denna rad tillhör
        public required CalendarView CalendarView { get; set; }

        // En rad kan vara kopplad till ett rum eller en person
        public int? RoomId { get; set; } // Om raden är kopplad till ett rum
        public Room? Room { get; set; } // Rummet

        public int? BookingParticipantId { get; set; } // Om raden är kopplad till en person
        public BookingParticipant? BookingParticipant { get; set; } // Personen

        // Relationen till appointments som visas på denna rad
        public List<CalendarAppointment>? CalendarAppointments { get; set; }
    }

    public class CalendarAppointment
    {
        public int Id { get; set; } // Unikt ID för appointment
        public int CalendarRowId { get; set; } // Rad (rum eller person) som appointmenten tillhör
        public CalendarRow? CalendarRow { get; set; }

        public int AppointmentId { get; set; } // Kopplar till en appointment
        public Appointment? Appointment { get; set; } // Själva appointmenten (workshop, föreläsning etc.)

    }

}
