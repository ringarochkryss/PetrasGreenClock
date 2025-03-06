namespace CampPlanner.Models
{
    // Room.cs
    public class Room
    {
        public int Id { get; set; } // Unique ID for the room
        public required string Name { get; set; } // e.g., Room 101, 102
        public int BuildingId { get; set; } // Related building
        public Building? Building { get; set; } // A room is linked to a building
        public List<Furniture>? Furniture { get; set; } // A room can have multiple pieces of furniture

        // Additional boolean properties
        public int NumberOfSeats { get; set; } // Number of available seats in the room
        public int NumberOfBeds { get; set; } // Number of available seats in the room
        public bool IsHandicapAccessible { get; set; } // Is the room handicap accessible?
        public bool AllowsDogs { get; set; } // Is the room dog-friendly?
        public bool AllowsSmoking { get; set; } // Is smoking allowed in the room?
        public bool HasToilet { get; set; } // Does the room have a toilet?
        public bool HasShower { get; set; } // Does the room have a shower?
        public bool IsMeetingRoom { get; set; } // Is this a meeting room?
        public bool IsWorkspace { get; set; } // Is this a workspace?
        public bool IsBedroom { get; set; } // Is this a bedroom?
    }

}
