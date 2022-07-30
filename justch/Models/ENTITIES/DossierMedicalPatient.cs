namespace justch.Models.ENTITIES
{
    public class DossierMedicalPatient
    {
        public int Id { get; set; } 
        public string Role { get; set; }
        public string Observation { get; set; }
        public int IdPatient { get; set; } 
        public int IdDossierMedical { get; set; }   
    }
}
