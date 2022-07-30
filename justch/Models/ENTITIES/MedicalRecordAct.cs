namespace justch.Models.ENTITIES
{
    public class MedicalRecordAct
    {
        public int Id { get; set; }
        public int IdMedicalRecord {  get; set; }
        public int IdPrescribingDoctorMedical { get; set; }
        public int IdMedicalAct { get; set; }
        public string Patients { get; set; }
        public string MedicalActType { get; set; }
        public string MedicalActName { get; set; }
        public string Rang { get; set; }
        public string State { get; set; }
    }
}
