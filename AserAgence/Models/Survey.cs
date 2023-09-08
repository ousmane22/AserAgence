namespace AserAgence.Models
{

    public class Survey
    {
        public int Id { get; set; }
        public DateTime SurveyDate { get; set; }
        public int ElectrifiedHouseholdsSurveyed { get; set; }
        public int VillageID { get; set; }

        public Village Village { get; set; }

        public Survey()
        {

            SurveyDate = DateTime.Now;
        }

    }
}
