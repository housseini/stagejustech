using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.ENTITIES
{
    public class Patient_Dossier_
    {
        public int Id { get; set; }
        public string Cin { get; set; }
        public string IssuedOn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Dataofbirth { get; set; }
        public string Placeofbirth { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string InsuranceAgency { get; set; }
        public string InsuranceID { get; set; }
        public string Nationality { get; set; }
        public string Civility { get; set; }
        public string State { get; set; }
        public DateTime Addedon { get; set; }
        public int Iddossier { get; set; }
        public string Reference { get; set; }
        public DateTime DateCreation { get; set; }  
        public string DateAdmission { get; set; }
        public string Type { get; set; }
        public string StateDossier { get; set; }
    }
}
