namespace CampPlanner.Models
{
    public class Furniture
    {
        public int Id { get; set; } // Unique ID for the furniture item
        public int FurnitureTypeId { get; set; } // Foreign key for FurnitureType
        public FurnitureType? FurnitureType { get; set; } // Navigation property to the FurnitureType
        public int Quantity { get; set; } // How many of this type of furniture exist in the room
        public int RoomId { get; set; } // Related room
        public Room? Room { get; set; } // A piece of furniture is linked to a room
        public List<FurnitureReservation>? FurnitureReservations { get; set; } // A piece of furniture can have multiple reservations
    }


    public class FurnitureType
    {
        public int Id { get; set; } // Unique ID for the furniture type
        public required string Name { get; set; } // Type of furniture (e.g., Double Bed, Single Bed)
        public string? FurnitureIcon { get; set; } // Icon representing the furniture type (e.g., bed, chair)
        public bool IsBed { get; set; } // Is this a bed?
        public bool IsDesk { get; set; } // Is this a desk?
        public bool IsSeat { get; set; } // Is this a seat in in a dining room or a conference room etc?
        public string? Description { get; set; } // Optional description of the furniture type (e.g., "A bed for two people")

    }


}
