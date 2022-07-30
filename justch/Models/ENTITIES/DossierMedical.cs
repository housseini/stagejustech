using System;
using System.ComponentModel.DataAnnotations;

namespace justch.Models.ENTITIES
{
    public class DossierMedical
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Reference is Required")]
        public string Reference { get; set; }
        public DateTime DateCreation { get; set; }
        [Required(ErrorMessage = "DateAdmission is Required")]
        public string DateAdmission { get; set; }
        [Required(ErrorMessage = "Type is Required")]
        public string Type { get; set; } 
        public string State { get; set; } 
        public DossierMedical() { }
        public DossierMedical(int Id,String REF,DateTime DACRE, string admi,string type, string state)
        {
            this.Id = Id;    
            this.Reference = REF;
            DateCreation = DACRE;
            DateAdmission = admi;
            Type = type;
            State = state;
        }
    }
}
