namespace Byggkontakter.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }
        public string? Icon { get; set; }
        public string? ColorCssClass { get; set; }
        public int SortOrder { get; set; }
    }
}
