namespace AserAgence.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string? RegionName { get; set; }

        public List<Village>? Villages { get; set; }
    }
}
