using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class Utilisateur
    {
        public Int32 Id { get; set; }
        public string UserName { get; set;  }
        public string Email { get; set; }
        public string Password { get; set;  }
        public string Type { get; set; }
    }
}
