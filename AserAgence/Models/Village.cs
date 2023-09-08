namespace AserAgence.Models
{
    public class Village
    {
        public int VillageID { get; set; }
        public string? VillageCode { get; set; }
        public int ElectrifiedHouseholds { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool IsElelctrify { get; set; }

        public int RegionID { get; set; } 
        public Region? Region { get; set; } 

        public int DepartmentID { get; set; } 
        public Department? Department { get; set; } 

        public int CommuneID { get; set; } 
        public Commune? Commune { get; set; } 


        public List<Survey>? Surveys { get; set; }
    }
}
