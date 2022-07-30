using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class DecoronisationOvocyteData
    {
        public int Id { get; set; }
        public int IdActDataDecoronisation { get; set; }
        public int DecoronisationOvocyteNumeroOvocyte { get; set; }
        public string DecoronisationOvocyteEtat { get; set; }
        public string DecoronisationOvocyteCommentaire { get; set; }
    }
}
