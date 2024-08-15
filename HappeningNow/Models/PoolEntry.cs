namespace HappeningNow.Models
{
    public class PoolEntry
    {
        public int? Id { get; set; }

        // Foreign Key Relationships
        public int? PoolId { get; set; }
        public Pool? Pool { get; set; }

        public int? TeamId { get; set; }
        public Team? Team { get; set; }

        public int? DisciplineId { get; set; }
        public Discipline? Discipline { get; set; }

        public int? Order { get; set; }

        public string? Mp3FilePath { get; set; }
    }
}
