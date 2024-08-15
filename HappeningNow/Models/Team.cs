namespace HappeningNow.Models
{
    public class Team
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        // Navigation Property
        public List<PoolEntry>? Entries { get; set; }
    }
}
