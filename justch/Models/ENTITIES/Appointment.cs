using System;

namespace justch.Models.ENTITIES
{
    public class Appointment
    {
        public int Id { get; set; }
        public int IdPatient1 { get; set; }
        public int IdPatient2 { get; set; }
        public int IdRoom1 { get; set; }
        public int IdRoom2 { get; set; }
        public int IdPrescribingDoctor1 { get; set; }
        public int IdPrescribingDoctor2 { get; set; }
        public int IdMedicalAct1 { get; set; }
        public int IdMedicalAct2 { get; set; }
        public DateTime Date { get; set; }  
        public DateTime Hour1 { get; set; }
        public DateTime Hour2 { get; set; }
        public string Notes { get; set; }
        public string State { get; set; }



    }
}
