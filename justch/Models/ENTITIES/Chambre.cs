using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class Chambre
    {
        public int Id { get; set; }
        public int IdIncubateur  { get; set; }

        public string  NomChambre  { get; set; }
    }
}
