using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class ActDataDecoronisationOvocyteData
    {
       public int Id { get; set; }
        public int IdActDataDecoronisation { get; set; }
        public int DecoronisationOvocyteNumeroOvocyte { get; set; }
        public string DecoronisationOvocyteEtat { get; set; }

        public string DecoronisationOvocyteCommantaire { get; set; }


    }
}
