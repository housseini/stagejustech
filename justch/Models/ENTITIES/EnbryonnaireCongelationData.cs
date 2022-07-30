using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class EnbryonnaireCongelationData
    {
        public int Id { get; set; }
        public int IdPaillette { get; set; }
        public int IdActDataCongelationEnbryonnaire { get; set; }
        public int IdEnbryologisteDoctor { get; set; }
        public string EmbryologisteDoctorType { get; set; }
        public int jourCongelation { get; set; }
        public int NumeroEnbroyon  { get; set; }

        public string Heure { get; set; }
        public string GradeEnbryon { get; set; }
        public string Date { get; set; }
        public string Commentaires { get; set; }
        public string Milieu { get; set; }
        public string Statu { get; set; }
    }
}
