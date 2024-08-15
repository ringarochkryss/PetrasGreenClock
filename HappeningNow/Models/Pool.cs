using System.ComponentModel.DataAnnotations;

namespace HappeningNow.Models
{
    public class Pool
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        // Navigation Property
        public List<PoolEntry>? Entries { get; set; }
    }
}
