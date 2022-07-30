using Core.Flash;
using justch.Models.DAL;
using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;

namespace justch.Models.BLL
{
    public class BLL_Patient
    {
        public static Patient getPatientsBy_EMAIL(string email)
        {
            return DAL_Patient.getPatientsBy_EMAIL(email);
        }
        public static List<Patient> GetPatients()


        {
            DalMigration.create_table_Patient();
            return DAL_Patient.Get_list_Patients(DAL_Patient.getPatients());

        }
        public static Patient getPatientById(int id)
        {
            return DAL_Patient.getPatientById(id);
        }
        public static Patient getPatientsByCIN(string cin)
        {
            return DAL_Patient.getPatientsByCIN(cin);
        }
        public static List<Patient> getPatientsBy_Fisrtname_LastName(string fisrtname, string lastname)
        {
            return DAL_Patient.getPatientsBy_Fisrtname_LastName(fisrtname, lastname);

        }
        public static List<Patient> getPatientsBy_EMAIL_Adress(string email, string adree)
        {
            return DAL_Patient.getPatientsBy_EMAIL_Adress(email, adree);
        }
        public static Message deletePatient(int id)
        {
            return DAL_Patient.deletePatient(id);
        }
        public static Message update(Patient p)
        {
            return DAL_Patient.update(p);
        }
        public static Message add(Patient p)
        {
            return DAL_Patient.Dal_patient_add(p);
        }


        public static List<Patient> Adven(string CIN, string FirstName, string LastName, string Phone, string Email, DateTime Addedon, string State, DateTime Dataofbirth ,int nombre)
        {

            return DAL_Patient.getPatientsBy(CIN, FirstName, LastName, Phone, Email, Addedon, State, Dataofbirth, nombre);



        }

        #region API Calls

        public static void addApi(Patient p, IFlasher f)
        {
            Message m = new Message(false, "");
            m = DAL_Patient.Dal_patient_add(p);
            if (m.status)
                f.Flash(Types.Success, m.message, dismissable: true);
            else
                f.Flash(Types.Danger, m.message, dismissable: true);



        }
        #endregion


    }
}
