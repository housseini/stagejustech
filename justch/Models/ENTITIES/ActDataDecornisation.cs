using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class ActDataDecoronisation
    {
        public int Id { get; set; }
        public int IdMedicalRecordAct { get; set; }
 
        public int IdEnbryologisteDoctor { get; set; }
      

        public string EmbryologisteDoctorType { get; set; }

        public string Heure  { get; set; }
        public string Date { get; set; }
        public string Commentaires  { get; set; }
    }
}
