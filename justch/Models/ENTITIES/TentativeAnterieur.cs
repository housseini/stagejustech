using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class TentativeAnterieur
    {
        public int Id { get; set; }
        public int IdRenseignementClinique { get; set; }
        public string Acte { get; set; }
        public string Remarques { get; set; }
        public string Resultats { get; set; }
        public string Date { get; set; }
    }
}
