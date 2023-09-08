namespace AserAgence.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? DepartmentName { get; set; }

        public List<Village>? Villages { get; set; }
    }
}
