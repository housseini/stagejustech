using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class ActDataPonction
    {
        public int Id { get; set; }
        public int IdMedicalRecordAct { get; set; }
        public int IdTretingDoctor { get; set; }
        public int IdEnbryologisteDoctor { get; set; }
        public int IdIncubateur { get; set; }

        public string EmbryologisteDoctorType { get; set; }

        public string Chambre { get; set; }
        public string Date  { get; set; }
        public string Heure { get; set; }
        public int  NombreFollicules  { get; set; }
        public int NombreType { get; set; }
        
        public  int NombreOvocytesCollectes { get; set; }
        public int OvocytesDegeneres { get; set; }

        public string Commentaires { get; set; }







    }
}
