using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class ActDataCongelationEnbryonnaire
    {
        public int Id { get; set; }
        public int IdMedicalRecordAct { get; set; }
        public string Commentaires { get; set; }
        public int  NombreEnbryonsCongeles { get; set; }
    }
}
