using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class ActDataInseminationIAC
    {
        public int Id { get; set; }
        public int IdMedicalRecordAct { get; set; }
        public int IdEnbryologisteDoctor { get; set; }
        public string EmbryologisteDoctorType { get; set; }
        public int VolumeInsemine { get; set; }
        public int NombreSpermatozoidesInsemines { get; set; }
        public string catheter { get; set; }
        public string Transerfer { get; set; }
        public string Sang { get; set; }
        public string Glaire { get; set; }
        public string Heure { get; set; }
        public string Date { get; set; }
        public string Commentaires { get; set; }

    }
}
