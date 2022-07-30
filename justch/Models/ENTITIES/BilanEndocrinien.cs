using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class BilanEndocrinien
    {
        public int Id { get; set; }
        public int IdRenseignementClinique { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string Fsh { get; set; }
        public string Lh { get; set; }
        public string Prolactine { get; set; }
        public string Tsh { get; set; }
        public string E2 { get; set; }
        public string Progesterone { get; set; }
        public string Amh { get; set; }
        public string Autres { get; set; }
        public string Testosterone { get; set; }
    }
}
