using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class Serologie
    {
        public int Id { get; set; }
        public int IdRenseignementClinique { get; set; }
        public string TypeSerologie { get; set; }
        public string Date { get; set; }
        public string Hiv { get; set; }
        public string Hvb { get; set; }
        public string Hvc { get; set; }
        public string Syphilis { get; set; }
        public string Chlamydia { get; set; }
        public string Mycoplasmes { get; set; }
        public string Autres { get; set; }
    }
}
