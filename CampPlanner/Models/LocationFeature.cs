namespace CampPlanner.Models
{
    // LocationFeature.cs
    public class LocationFeature
    {
        public int Id { get; set; } // Unique ID for the feature
        public string? Name { get; set; } // Name of the feature (e.g., "Grill", "Pool", "Minigolf")
        public string? Icon { get; set; } // String representing the icon to display (e.g., an icon class or URL)
        public int LocationId { get; set; } // Foreign key to Location
        public Location? Location { get; set; } // The location where this feature exists
    }

}
