namespace training_health_medical_app.Model
{
    public class Survey
    {
        public int ID { get; set; }
        public string Mood { get; set; }
        public string Appetite { get; set; }
        public string Feelings { get; set; }
        public string Interest { get; set; }
        public string Sleep { get; set; }
        public string PhysicalSymptom { get; set; }
        public string? Treatment { get; set; }
        public string? Diagnose { get; set; }
        public string PlayerID { get; set; }
        public string? CoachID { get; set; }
    }
}
