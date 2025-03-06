namespace CampPlanner.Models
{
    public class Building
    {
        public int Id { get; set; } // Unique ID for the building
        public required string Name { get; set; } // e.g., Building A, Building B
        public int LocationId { get; set; } // Related location
        public Location? Location { get; set; } // A building is linked to a location
        public List<Room>? Rooms { get; set; } // A building can have multiple rooms
        public bool HasToilet { get; set; } // Does the building have a toilet?
        public bool HasShower { get; set; } // Does the building have a shower?
        public bool HasFridge { get; set; } // Does the building have a fridge?
        public bool HasFreezer { get; set; } // Does the building have a freezer?
        public bool HasWashingMachine { get; set; } // Does the building have a washing Machine?
        public bool HasDishwasher { get; set; } // Does the building have a dishwasher?
        public bool HasKitchen { get; set; } // Does the building have a kitchen?
        public bool HasWifi { get; set; } // Does the building have a wifi?
        public string? WifiCode { get; set; } // Access the wifi with this code
        public int NumberOfBeds { get; set; } // Number of beds in the building
        public int NumberOfDesks { get; set; } // Number of desks in the building
        public int NumberOfSeats { get; set; } // Number of seats in the building
        public bool IsHandicapAccessible { get; set; } // Is the building handicap accessible?
        public bool AllowsDogs { get; set; } // Is the building dog-friendly?
        public bool AllowsSmoking { get; set; } // Is smoking allowed in the building?
        public string? Note { get; set; } // Note about the building
    }

}
