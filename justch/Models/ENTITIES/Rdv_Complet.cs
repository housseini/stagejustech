using justch.Models.DAL;
using System.Collections.Generic;

namespace justch.Models.ENTITIES
{
    public class Rdv_Complet
    {
        public Appointment Appointment { get; set; }
        public List<Patient> patients { get; set; }
        public List<MedicalAct> medicicalActs { get;set; }
        public List<Room> rooms { get; set; }   
        public List<Doctor> doctors { get; set; }   

        public Rdv_Complet ( Appointment Appointment )
        {
            
            this.Appointment= Appointment; 
            this.patients = new List<Patient>();

            if (Appointment.IdPatient1 != 0)
            {
              
                this.patients.Add(DAL_Patient.getPatientById(Appointment.IdPatient1));

            }
            
            if (Appointment.IdPatient2 != 0)
            {
                this.patients.Add(DAL_Patient.getPatientById(Appointment.IdPatient2));

            }
           
            this.medicicalActs= new List<MedicalAct>();
            this.medicicalActs.Add(DAL_MedicalAct.getByID(Appointment.IdMedicalAct1)) ;
            if (Appointment.IdMedicalAct2 != 0)
            {
                this.medicicalActs.Add(DAL_MedicalAct.getByID(Appointment.IdMedicalAct2));
            }

                
            this.rooms = new List<Room>();
            this.rooms.Add(DAL_Room.GetByID(Appointment.IdRoom1));
            if (Appointment.IdRoom2 != 0)
            {
                this.rooms.Add(DAL_Room.GetByID(Appointment.IdRoom2));
            }
                
            this.doctors = new List<Doctor>();
            this.doctors.Add(DAL_Doctor.getBy(Appointment.IdPrescribingDoctor1)) ;


            if (Appointment.IdPrescribingDoctor2 != 0)
            {
                this.doctors.Add(DAL_Doctor.getBy(Appointment.IdPrescribingDoctor2));
            }
             





        }
        public Rdv_Complet (int id)
        {
            var ap = DAL_Appointment.GetbyIdappointement(id);
            if (ap != null) { 
                this.Appointment = ap;
            }

            this.patients = new List<Patient>();
            if (ap !=null && ap.IdPatient1 != 0 )
            {

                this.patients.Add(DAL_Patient.getPatientById(ap.IdPatient1));

            }

            if (ap.IdPatient2 != 0)
            {
                this.patients.Add(DAL_Patient.getPatientById(ap.IdPatient2));

            }

            this.medicicalActs = new List<MedicalAct>();
            this.medicicalActs.Add(DAL_MedicalAct.getByID(ap.IdMedicalAct1));
            if (ap.IdMedicalAct2 != 0)
            {
                this.medicicalActs.Add(DAL_MedicalAct.getByID(ap.IdMedicalAct2));
            }


            this.rooms = new List<Room>();
            this.rooms.Add(DAL_Room.GetByID(ap.IdRoom1));
            if (ap.IdRoom2 != 0)
            {
                this.rooms.Add(DAL_Room.GetByID(ap.IdRoom2));
            }

            this.doctors = new List<Doctor>();
            this.doctors.Add(DAL_Doctor.getBy(ap.IdPrescribingDoctor1));


            if (ap.IdPrescribingDoctor2 != 0)
            {
                this.doctors.Add(DAL_Doctor.getBy(ap.IdPrescribingDoctor2));
            }



        }

        public static List<Rdv_Complet> allRdv ( List<Appointment> AP )
        {
            List<Rdv_Complet> rdv_Complets = new List<Rdv_Complet>();
            if (AP!=null)
            {

                foreach (Appointment appointment in AP)
                {
                    rdv_Complets.Add(new Rdv_Complet(appointment));
                }

            }
          
              
            return rdv_Complets;

        }



    }
}
