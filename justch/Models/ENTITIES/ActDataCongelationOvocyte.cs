using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class ActDataCongelationOvocyte
    {
        public int Id { get; set; }
        public int IdMedicalRecordAct { get; set; }
        public string Commentaires { get; set; }
        public int NombreOvocyteCongeles { get; set; }
    }
}
