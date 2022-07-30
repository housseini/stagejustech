using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class ExamenComplementaire
    {
        public int Id { get; set; }
        public int IdRenseignementClinique { get; set; }
        public string Echo { get; set; }
        public string Hsg { get; set; }
        public string Hsg_Hs { get; set; }
        public string Tpc { get; set; }
        public string Cytogenetique { get; set; }
    }
}
