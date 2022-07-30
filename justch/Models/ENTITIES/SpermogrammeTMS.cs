using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class SpermogrammeTMS
    {
        public int Id { get; set; }
        public int IdRenseignementClinique { get; set; }
        public string Date { get; set; }
        public string Vol { get; set; }
        public string Num { get; set; }
        public string Mobilite { get; set; }
        public string Vita { get; set; }
        public string Ft { get; set; }
        public string Leuco { get; set; }
    }
}
