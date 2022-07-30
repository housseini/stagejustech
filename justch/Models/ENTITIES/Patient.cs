using System;
using System.ComponentModel.DataAnnotations;


namespace  justch.Models.ENTITIES
{
    public class Patient

    {
        public int  Id { get; set; }
        [Required(ErrorMessage = "CIN is Required")]
        public string  Cin { get; set; }
        public string IssuedOn { get; set; }
        [Required(ErrorMessage = "First is Required")]
        public  string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName  { get; set; }  
        public string MaidenName     { get; set; }
        public string Gender { get; set; }
        public string Profession  { get; set; }
        public string Photo { get; set; }
        [Required(ErrorMessage = "phone number  is Required")]
        public  string  Phone { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Dataofbirth is Required")]
        public DateTime Dataofbirth { get; set; }
        [Required(ErrorMessage = "Placeofbirth is Required")]
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

        public Patient() { }

        
        public Patient(
            int Id, string cin, string IssuedOn, string FirstName
            , string LastName, string MaidenName
            , string Gender, string Profession, string photo, string phone
            , string email, DateTime dofb, string Placeofbirth, string Address, string PostalCode, string City, string Country
              ,string InsuranceAgency, string InsuranceID, string Nationality, string civlity,string state,
               DateTime addedon
            ) {
                            this.Id = Id;
                            this.Cin = cin;
                            this.IssuedOn = IssuedOn;
                            this.FirstName = FirstName;
                            this.LastName = LastName;
                            this.MaidenName = MaidenName;
                            this.Gender = Gender;
                            this.Profession = Profession;
                            this.Photo = photo;
                            this.Email = email;
                            this.Phone = phone;
                            this.Dataofbirth = dofb;
                            this.Placeofbirth = Placeofbirth;
                            this.Address = Address;
                            this.PostalCode = PostalCode;
                            this.City = City;
                            this.Country = Country;
                            this.InsuranceAgency= InsuranceAgency;
                            this.InsuranceID= InsuranceID;
                            this.Nationality= Nationality;
                            this.Civility= civlity;
                            this.State= state;
                            this.Addedon = addedon;

        }






    }
}
