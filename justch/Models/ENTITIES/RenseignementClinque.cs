using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class RenseignementClinque
    {
        public  int Id { get; set; }
        public int IdMedicalRecord { get; set; }
        public  string TypeDinfertilite { get; set; }
        public  int  DurerDinfertilite { get; set; }
        public  string Remarques { get; set; }
        public  string NombreGrossesses { get; set; }
        public  string DateGrossesses { get; set; }
        public  string NombreEnfants { get; set; }
        public  string DateEnfants { get; set; }
        public  string NombreGeu { get; set; }
        public  string  DateGeu { get; set; }
        public  string   NombreAvortement  { get; set; }
        public  string DateAvortement { get; set; }
        public  string PoidMonsieur { get; set; }
        public  string TailleMonsieur { get; set; }
        public  string BMIMMonsieur { get; set; }
        public  string PoidMadame { get; set; }
        public  string TailleMadame { get; set; }
        public  string BMIMMMadame { get; set; }
        public  string Techniques { get; set; }
        public  string Indications { get; set; }
        public  string Observation { get; set; }











    }
}
