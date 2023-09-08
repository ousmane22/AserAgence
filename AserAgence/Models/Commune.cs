namespace AserAgence.Models
{
    public class Commune
    {
        public int Id { get; set; }
        public string? CommuneName { get; set; }

        public List<Village> Villages { get; set; }
    }
}
