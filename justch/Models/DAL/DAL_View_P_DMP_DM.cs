using justch.Models.ENTITIES;
using justch.Models.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace justch.Models.DAL
{
    public class DAL_View_P_DMP_DM
    {
        public static DossierMedical GetDossierMedicale(DataRow row)
        {
            DossierMedical dossierMedical = new DossierMedical();
            dossierMedical.Id = Int32.Parse(row["Id"].ToString());
            dossierMedical.Reference = (row["Reference"].ToString());
            dossierMedical.DateAdmission = (row["DateAdmission"].ToString());
            dossierMedical.DateCreation = (DateTime)row["DateCreation"];
            dossierMedical.State = (string)row["State"];
            dossierMedical.Type = (string)row["Type"];

            return dossierMedical;
        }
        public static Patient GetPatient(DataRow row)
        {
            Patient patient = new Patient();
            patient.Id = Int32.Parse(row["Id"].ToString());
            patient.FirstName = (string)row["FirstName"];
            patient.LastName = (string)row["LastName"];
            patient.IssuedOn = (string)row["IssuedOn"];
            patient.Dataofbirth = (DateTime)row["Dataofbirth"];
            patient.Placeofbirth = (string)row["Placeofbirth"];
            patient.MaidenName = (string)row["MaidenName"];
            patient.Nationality = (string)row["Nationality"];
            patient.Phone = (string)row["Phone"];
            patient.Photo = (string)row["Photo"];
            patient.Address = (string)row["Address"];
            patient.Cin = (string)row["Cin"];
            patient.Country = (string)row["Country"];
            patient.Email = (string)row["Email"];
            patient.InsuranceAgency = (string)row["InsuranceAgency"];
            patient.InsuranceID = (string)row["InsuranceID"];
            patient.State = (string)row["State"];
            patient.City = (string)row["City"];
            patient.Civility = (string)row["Civility"];
            patient.Gender = (string)row["Gender"];
            patient.Addedon = (DateTime)row["Addedon"];

            return patient;
        }
        public static List<Patient> Get_list_Patients(DataTable table)
        {
            List<Patient> liste = new List<Patient>();
            foreach (DataRow row in table.Rows)
                liste.Add(GetPatient(row));
            return liste;
        }
        public static List<DossierMedical> GetDossierMedicales(DataTable table)
        {
            List<DossierMedical> list = new List<DossierMedical>();
            foreach (DataRow row in table.Rows)
                list.Add(GetDossierMedicale(row));
            return list;
        }
        public static List<DossierMedical> GetDossierMedicalesByIdPatient(int id)
        {
            try
            {
                string query = "SELECT   DM.Id,DM.Reference ,DM.DateAdmission ,DM.DateCreation,DM.State,DM.Type FROM DossierMedical DM,DossierMedicalPatient DPM WHERE(DPM.IdPatient=@id and DPM.IdDossierMedical=DM.Id);";
                SqlConnection conn = DbConnection.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(id.ToString()))
                    cmd.Parameters.AddWithValue("@id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);

                return GetDossierMedicales(table);




            }
            catch
            {
                return null;
            }
        }
        public static DataTable Get_list_Patient(int Reference)
        {
            try
            {
                string query = "SELECT p.Id,FirstName,LastName,Cin ,IssuedOn ,MaidenName,Gender,Photo, Profession,Email ,Phone,Dataofbirth,Placeofbirth,Address,PostalCode, City,Country,InsuranceAgency,InsuranceID ,Nationality,Civility,Reference,DateAdmission,Type,dm.State ,IdPatient,IdDossierMedical,Role,Observation  FROM  Patient p,DossierMedicalPatient dmp ,DossierMedical dm WHERE(dm.Id=@Reference and dm.Id= dmp.IdDossierMedical and dmp.IdPatient=p.Id);";
                SqlConnection conn = DbConnection.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(Reference.ToString()))
                    cmd.Parameters.AddWithValue("@Reference", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Reference", Reference);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);


                return ((table));




            }
            catch
            {
                return null;
            }

        }


        public static List<Patient> Get_list_Patient_forDossier (int Reference)
        {
            try
            {
                string query = "SELECT p.Id,FirstName,LastName,Cin ,IssuedOn ,MaidenName,Gender,Photo, Profession,Email ,Phone,Dataofbirth,Placeofbirth,Address,PostalCode, City,Country,InsuranceAgency,InsuranceID ,Nationality,Civility,Addedon,p.State  FROM  Patient p,DossierMedicalPatient dmp ,DossierMedical dm WHERE(dm.Id=@Reference and dm.Id= dmp.IdDossierMedical and dmp.IdPatient=p.Id);;";
                SqlConnection conn = DbConnection.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(Reference.ToString()))
                    cmd.Parameters.AddWithValue("@Reference", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Reference", Reference);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);


                return DAL_Patient.Get_list_Patients(table);




            }
            catch
            {
                return null;
            }

        }

        public static List<Patient_Dossier_> patient_Dossier_s (int RReference)
        {
            List<Patient_Dossier_> patient_s = new List<Patient_Dossier_>();
            var Patients = Get_list_Patient(RReference);
            if (Patients != null)
            {
                foreach (DataRow dataRow in Patients.Rows)
                    patient_s.Add(GetPatient_Dossier_(dataRow));
                        
            }

            return patient_s;

        }

        public static Patient_Dossier_ GetPatient_Dossier_(DataRow dataRow)
        {
           Patient_Dossier_ p =  new Patient_Dossier_();

        

            if (string.IsNullOrEmpty(dataRow["Id"].ToString()))
                p.Id = 0;
            else
            {
                p.Id = Int32.Parse(dataRow["Id"].ToString());
            }


            if (dataRow["Cin"] == DBNull.Value) { p.Cin = null; }
            else { p.Cin = CryptageEncryptage.decrypte((string)dataRow["Cin"]); }

            if (dataRow["IssuedOn"] == DBNull.Value) { p.IssuedOn = null; }
            else { p.IssuedOn = CryptageEncryptage.decrypte((string)dataRow["IssuedOn"]); }

            if (dataRow["FirstName"] == DBNull.Value) { p.FirstName = null; }
            else { p.FirstName = CryptageEncryptage.decrypte((string)dataRow["FirstName"]); }

            if (dataRow["LastName"] == DBNull.Value) { p.LastName = null; }
            else { p.LastName = CryptageEncryptage.decrypte((string)dataRow["LastName"]); }

            if (dataRow["MaidenName"] == DBNull.Value) { p.MaidenName = null; }
            else { p.MaidenName = CryptageEncryptage.decrypte((string)dataRow["MaidenName"]); }

            if (dataRow["Gender"] == DBNull.Value) { p.Gender = null; }
            else { p.Gender = CryptageEncryptage.decrypte((string)dataRow["Gender"]); }
         ;

            if (dataRow["Profession"] == DBNull.Value) { p.Profession = null; }
            else { p.Profession = CryptageEncryptage.decrypte((string)dataRow["Profession"]); }



            if (dataRow["Photo"] == DBNull.Value) { p.Photo = null; }
            else { p.Photo = CryptageEncryptage.decrypte((string)dataRow["Photo"]); }


            if (dataRow["Phone"] == DBNull.Value) { p.Phone = null; }
            else { p.Phone = CryptageEncryptage.decrypte((string)dataRow["Phone"]); }


            if (dataRow["Email"] == DBNull.Value) { p.Email = null; }
            else { p.Email = CryptageEncryptage.decrypte((string)dataRow["Email"]); }

            if (dataRow["Dataofbirth"] == DBNull.Value) { }
            else { p.Dataofbirth = DateTime.Parse(dataRow["Dataofbirth"].ToString()); }


            if (dataRow["Placeofbirth"] == DBNull.Value) { p.Placeofbirth = null; }
            else { p.Placeofbirth = CryptageEncryptage.decrypte((string)dataRow["Placeofbirth"]); }


            if (dataRow["Address"] == DBNull.Value) { p.Address = null; }
            else { p.Address = CryptageEncryptage.decrypte((string)dataRow["Address"]); }


            if (dataRow["PostalCode"] == DBNull.Value) { p.PostalCode = null; }
            else { p.PostalCode = CryptageEncryptage.decrypte((string)dataRow["PostalCode"]); }


            if (dataRow["City"] == DBNull.Value) { p.City = null; }
            else { p.City = CryptageEncryptage.decrypte((string)dataRow["City"]); }


            if (dataRow["Country"] == DBNull.Value) { p.Country = null; }
            else { p.Country = CryptageEncryptage.decrypte((string)dataRow["Country"]); }



            if (dataRow["InsuranceAgency"] == DBNull.Value) { p.InsuranceAgency = null; }
            else { p.InsuranceAgency = CryptageEncryptage.decrypte((string)dataRow["InsuranceAgency"]); }


            if (dataRow["InsuranceID"] == DBNull.Value) { p.InsuranceID = null; }
            else { p.InsuranceID = CryptageEncryptage.decrypte((string)dataRow["InsuranceID"]); }

            if (dataRow["Nationality"] == DBNull.Value) { p.Nationality = null; }
            else { p.Nationality = CryptageEncryptage.decrypte((string)dataRow["Nationality"]); }


            if (dataRow["Civility"] == DBNull.Value) { p.Civility = null; }
            else { p.Civility = CryptageEncryptage.decrypte((string)dataRow["Civility"]); }





            return p;


        
        }
    }
}
