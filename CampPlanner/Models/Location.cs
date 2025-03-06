namespace CampPlanner.Models
{
    // Location.cs
    public class Location
    {
        public int Id { get; set; } // Unique ID for the location
        public required string Name { get; set; } // e.g., Stockholm, Gothenburg
        public string? Address { get; set; } // The address of the location
        public string? MapCode { get; set; } // Code or URL to display the location on a map (e.g., Google Maps embed code)
        public string? WeatherApiCode { get; set; } // The code or API identifier for weather data for this location
        public int OrganizationId { get; set; } // Related organization
        public Organization? Organization { get; set; } // A location is linked to an organization
        public List<LocationFeature>? Features { get; set; } // List of features (e.g., pool, grill)
        public List<Building>? Buildings { get; set; } // A location can have multiple buildings (offices, for example)
        public string? Note { get; set; } // Note about the location
        public List<Event>? Events { get; set; } // A Location can have many Events

    }


}
