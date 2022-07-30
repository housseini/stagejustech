using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class ActDataCulture
    {

        public int Id { get; set; }
        public int IdMedicalRecordAct { get; set; }
        public int IdJ1EmbryologisteDoctor { get; set; }
        public int IdJ2EmbryologisteDoctor { get; set; }
        public int IdJ3EmbryologisteDoctor { get; set; }
        public int IdJ4EmbryologisteDoctor { get; set; }
        public int IdJ5EmbryologisteDoctor { get; set; }
        public int IdJ6EmbryologisteDoctor { get; set; }
        public int IdJ1Incubateur { get; set; }
        public int IdJ2Incubateur { get; set; }
        public int IdJ3Incubateur { get; set; }
        public int IdJ4Incubateur { get; set; }
        public int IdJ5Incubateur { get; set; }
        public int IdJ6Incubateur { get; set; }
        public string J1Chambres { get; set; }
        public string J2Chambres { get; set; }
        public string J3Chambres { get; set; }
        public string J4Chambres { get; set; }
        public string J5Chambres { get; set; }
        public string J6Chambres { get; set; }
        public string J1EmbryologisteDoctorType { get; set; }
        public string J2EmbryologisteDoctorType { get; set; }
        public string J3EmbryologisteDoctorType { get; set; }
        public string J4EmbryologisteDoctorType { get; set; }
        public string J5EmbryologisteDoctorType { get; set; }
        public string J6EmbryologisteDoctorType { get; set; }
        public string J1Date { get; set; }
        public string J1Heure { get; set; }
        public string J2Date { get; set; }
        public string J2Heure { get; set; }
        public string J3Date { get; set; }
        public string J3Heure { get; set; }
        public string J4Date { get; set; }
        public string J4Heure { get; set; }
        public string J5Date { get; set; }
        public string J5Heure { get; set; }
        public string J6Date { get; set; }
        public string J6Heure { get; set; }
    }
}
