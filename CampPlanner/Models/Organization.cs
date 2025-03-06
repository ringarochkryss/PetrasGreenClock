namespace CampPlanner.Models
{

    public class Organization
    {
        public int Id { get; set; } // Unique ID for the organization
        public required string Name { get; set; } // e.g., Company AB
        public string? ContactPerson { get; set; } // Name of the contact person
        public string? Email { get; set; } // Contact person's email address
        public string? PhoneNumber { get; set; } // Contact person's phone number
        public byte[]? Logotype { get; set; } // Logotype as a byte array (image)
        public List<Event>? Events { get; set; } // An organization can have multiple events
        public List<Location>? Locations { get; set; } // An organization can have multiple locations (e.g., offices or buildings)
    }


}
