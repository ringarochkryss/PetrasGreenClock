using System;

namespace CampPlanner.Models
{
    public class FurnitureReservation
    {
        public int Id { get; set; } // Unique ID for the reservation
        public int PersonId { get; set; } // Person associated with this reservation
        public Person? Person { get; set; } // The person who uses the furniture
        public int FurnitureId { get; set; } // Related furniture (e.g., a specific bed)
        public Furniture? Furniture { get; set; } // The specific piece of furniture being reserved
        public DateTime StartDate { get; set; } // The date the reservation starts
        public DateTime EndDate { get; set; } // The date the reservation ends (e.g., when the person checks out)
    }

}
