using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace justch.Models.DAL
{
    public class DAL_DossierMedicalPatient
    {
        public static Message AddDossierMedicalPatient(DossierMedicalPatient DMP)
        {
            try
            {
                string query = "insert into DossierMedicalPatient(IdPatient,IdDossierMedical,Role,Observation)values(@IdPatient,@IdDossierMedical,@Role,@Observation);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(DMP.IdPatient.ToString()))
                    cmd.Parameters.AddWithValue("@IdPatient", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdPatient", DMP.IdPatient);
                if (string.IsNullOrEmpty(DMP.IdDossierMedical.ToString()))
                    cmd.Parameters.AddWithValue("@IdDossierMedical", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdDossierMedical", DMP.IdDossierMedical);
                if (string.IsNullOrEmpty(DMP.Role))
                    cmd.Parameters.AddWithValue("@Role", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Role", DMP.Role);
                if (string.IsNullOrEmpty(DMP.Observation))
                    cmd.Parameters.AddWithValue("@Observation", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Observation", DMP.Observation);
                cmd.ExecuteNonQuery();
                return new Message(true, "DOSSIER MEDICAL PATIENT AJOUTER");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);

            }

        }
        public static Message deleteDossierMedicalPatient(string Field, string value)
        {
            try
            {

               var T = Int64.Parse(value);
                string query = "delete from DossierMedicalPatient where(@Field=@value );";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(value))
                    cmd.Parameters.AddWithValue("@value", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@value", value);
                if (string.IsNullOrEmpty(Field))
                    cmd.Parameters.AddWithValue("@Field", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Field", T);

                cmd.ExecuteNonQuery();
                return new Message(true, "DOSSIER MEDICAL PATIENT SUPPRIMER");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);

            }

        }
        public static Message UpdateDossierMedicalPatient(DossierMedicalPatient DMP)
        {
            try
            {
                string query = "update  DossierMedicalPatient set Role=@Role,Observation=@Observation where(IdDossierMedical=@IdDossierMedical);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;

                if (string.IsNullOrEmpty(DMP.Role))
                    cmd.Parameters.AddWithValue("@Role", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Role", DMP.Role);
                if (string.IsNullOrEmpty(DMP.Observation))
                    cmd.Parameters.AddWithValue("@Observation", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Observation", DMP.Observation);
                if (string.IsNullOrEmpty(DMP.IdDossierMedical.ToString()))
                    cmd.Parameters.AddWithValue("@IdDossierMedical", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdDossierMedical", DMP.IdDossierMedical);
                cmd.ExecuteNonQuery();
                return new Message(true, "DOSSIER MEDICAL PATIENT modifier");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);

            }

        }
        public static DossierMedicalPatient GetDossierMedicalPatient(int IdDossierMedical)
        {
            string query ="select * from  DossierMedicalPatient where(IdDossierMedical=@IdDossierMedical);";
            SqlConnection mycon = DbConnection.GetConnection();
            mycon.Open();
            SqlCommand cmd = new SqlCommand(query, mycon);
            cmd.CommandType = CommandType.Text;
            if (string.IsNullOrEmpty(IdDossierMedical.ToString()))
                cmd.Parameters.AddWithValue("@IdDossierMedical", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@IdDossierMedical", IdDossierMedical);
            DataTable table = new DataTable();
            SqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);
            if (table.Rows.Count != 0)
                return get(table.Rows[0]);
            else
                return null;


        }

        public static DossierMedicalPatient GetDossierMedicalPatientByIDpatient(int idpatient)
        {
            string query = "select * from  DossierMedicalPatient where(IdPatient=@idpatient);";
            SqlConnection mycon = DbConnection.GetConnection();
            mycon.Open();
            SqlCommand cmd = new SqlCommand(query, mycon);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 50;
            if (string.IsNullOrEmpty(idpatient.ToString()))
                cmd.Parameters.AddWithValue("@idpatient", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@idpatient", idpatient);
            DataTable table = new DataTable();
            SqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);
            mycon.Close();
            if (table.Rows.Count != 0) { 
                System.Console.WriteLine(table.Rows[0]);
                return get(table.Rows[0]);
            }
            else
                return null;

        }

        public static DossierMedicalPatient GetDossierMedicalPatientByIdDossier(int idDossier)
        {
            string query = "select * from  DossierMedicalPatient where(IdDossierMedical=@idDossier);";
            SqlConnection mycon = DbConnection.GetConnection();
            mycon.Open();
            SqlCommand cmd = new SqlCommand(query, mycon);
            cmd.CommandType = CommandType.Text;
            if (string.IsNullOrEmpty(idDossier.ToString()))
                cmd.Parameters.AddWithValue("@idDossier", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@idDossier", idDossier);
            DataTable table = new DataTable();
            SqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);

            if (table.Rows.Count != 0)
            {
                System.Console.WriteLine(table.Rows[0]);
                return get(table.Rows[0]);
            }
            else
                return null;

        }
        public static List<DossierMedicalPatient> GetsbyIdPatient(int id)
        {
            try
            {
                List<DossierMedicalPatient> liste = new List<DossierMedicalPatient>();
                string query = "select * from  DossierMedicalPatient where(IdPatient=@idpatient);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(id.ToString()))
                    cmd.Parameters.AddWithValue("@idpatient", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@idpatient", id);
                DataTable table = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
                mycon.Close();
                if (table.Rows.Count != 0)
                {
                    foreach(DataRow row in table.Rows)
                    {
                        liste.Add(get(row));
                    }
                    return liste;
                  
                }
                else
                    return null;

            }
            catch
            {
                return null;
            }






        }
        public static DossierMedicalPatient get(DataRow dataRow) {
            DossierMedicalPatient dossier = new DossierMedicalPatient();
            dossier.Id = int.Parse(dataRow["Id"].ToString());
            if (dataRow["Role"] == DBNull.Value) { dossier.Role = null; }
            else { dossier.Role = (string)dataRow["Role"]; }
            if (dataRow["Observation"] == DBNull.Value) { }
            else { dossier.Observation = dataRow["Observation"].ToString(); }
            if (dataRow["IdPatient"] == DBNull.Value) { }
            else { dossier.IdPatient = int.Parse( dataRow["IdPatient"].ToString()); }
            if (dataRow["IdDossierMedical"] == DBNull.Value) { }
            else { dossier.IdDossierMedical = int.Parse(dataRow["IdDossierMedical"].ToString()); }
            return dossier; 
        }



    }
}
