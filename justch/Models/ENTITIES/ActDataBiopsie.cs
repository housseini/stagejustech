using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class ActDataBiopsie
    {
        public int Id { get; set; }
        public int IdMedicalRecordAct { get; set; }
        public int IdTreatingDoctor { get; set; }
        public int IdEmbryologisteDoctor { get; set; }
        public string EmbryologisteDoctorType { get; set; }
        public string Date { get; set; }
        public string Heure { get; set; }
        public string TypeBiopsieTesticulaire { get; set; }
        public string ExamenAnatomopathologique { get; set; }
        public int TGPoleSupNombreFragments { get; set; }
        public string TGPoleSupDilaceration { get; set; }
        public string TGPoleSupResultat { get; set; }
        public int TGPoleMedNombreFragments { get; set; }
        public string TGPoleMedDilaceration { get; set; }
        public string TGPoleMedResultat { get; set; }
        public int TGPoleInfNombreFragments { get; set; }
        public string TGPoleInfDilaceration { get; set; }
        public string TGPoleInfResultat { get; set; }
        public int TDPoleSupNombreFragments { get; set; }
        public string TDPoleSupDilaceration { get; set; }
        public string TDPoleSupResultat { get; set; }
        public int TDPoleMedNombreFragments { get; set; }
        public string TDPoleMedDilaceration { get; set; }
        public string TDPoleMedResultat { get; set; }
        public int TDPoleInfNombreFragments { get; set; }
        public string TDPoleInfDilaceration { get; set; }
        public string TDPoleInfResultat { get; set; }
    }
}
