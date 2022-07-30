using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class AntecedentParticulier
    {
        public int Id { get; set; }
        public int IdRenseignementClinique { get; set; }
        public string TypeAntecedent { get; set; }
        public string Medicaux { get; set; }
        public string Chirurgicaux { get; set; }
        public string Familiaux { get; set; }
        public string Gynecologiques { get; set; }
        public string Tabac { get; set; }
        public string Alcool { get; set; }
        public string Autres { get; set; }
    }
}
