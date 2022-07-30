using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class Incubateur
    {
        public int Id { get; set; }
        public string NomIncubateur { get; set; }
        
        public int NombreChambre { get; set; }
    }
}
