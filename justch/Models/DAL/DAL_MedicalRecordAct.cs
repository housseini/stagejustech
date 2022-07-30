using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace justch.Models.DAL
{
    public class DAL_MedicalRecordAct
    {
        public static MedicalRecordAct get(DataRow row)
        {

            MedicalRecordAct medicalRecordAct = new MedicalRecordAct();
            medicalRecordAct.Id= Int32.Parse(row["Id"].ToString());
            medicalRecordAct.IdMedicalRecord = Int32.Parse(row["IdMedicalRecord"].ToString());
            medicalRecordAct.IdPrescribingDoctorMedical = Int32.Parse(row["IdPrescribingDoctorMedical"].ToString());
            medicalRecordAct.IdMedicalAct = Int32.Parse(row["IdMedicalAct"].ToString());
            if (string.IsNullOrEmpty(row["Patients"].ToString())) { }
            else
                medicalRecordAct.Patients = (string)row["Patients"];

            if (string.IsNullOrEmpty(row["MedicalActType"].ToString())) { }
            else
                medicalRecordAct.MedicalActType = (string)row["MedicalActType"];

            if (string.IsNullOrEmpty(row["MedicalActName"].ToString())) { }
            else
                medicalRecordAct.MedicalActName = (string)row["MedicalActName"];
            if (string.IsNullOrEmpty(row["Rang"].ToString())) { }
            else
                medicalRecordAct.Rang = (string)row["Rang"];

            if (string.IsNullOrEmpty(row["State"].ToString())) { }
            else
                medicalRecordAct.State = (string)row["State"];


            return medicalRecordAct;
        }
        public static List<MedicalRecordAct> gets(DataTable dataTable)
        {
            List<MedicalRecordAct> medicalRecordActs = new List<MedicalRecordAct>();
            foreach (DataRow row in dataTable.Rows)
                medicalRecordActs.Add(get(row));
            return medicalRecordActs;
        }
        public static  List<MedicalRecordAct> gets(){
            try
            {
                string query = "select *from MedicalRecordAct; ";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query,connection);
                command.CommandTimeout = 50;
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                connection.Close();
                return gets(table);
            }
            catch
            {
                return null;

            }
        }
        public static List<MedicalRecordAct> getsBy(string Field ,string value)
        {
            try
            {
                string query = "select *from MedicalRecordAct where(@Field=@value);";
                SqlConnection  con= DbConnection.GetConnection();
                con.Open();
                SqlCommand command=new SqlCommand(query,con);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 50;
                if (string.IsNullOrEmpty(Field))
                    command.Parameters.AddWithValue("@Field", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Field", Field);

                if (string.IsNullOrEmpty(value))
                    command.Parameters.AddWithValue("@value", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@value", value);

                SqlDataReader reader=command.ExecuteReader();
                DataTable ta=new DataTable();
                ta.Load(reader);
                con.Close();
                return gets(ta);
            } catch
            {
                return null;
            }
        }
        public static List<MedicalRecordAct> getsByIdMedicalACT(int value)
        {
            try
            {
                string query = "select *from MedicalRecordAct where(IdMedicalAct=@value);";
                SqlConnection con = DbConnection.GetConnection();
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 50;

                if (string.IsNullOrEmpty(value.ToString()))
                    command.Parameters.AddWithValue("@value", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@value", value);

                SqlDataReader reader = command.ExecuteReader();
                DataTable ta = new DataTable();
                ta.Load(reader);
                con.Close();
                return gets(ta);
            }
            catch
            {
                return null;
            }
        }
        public static List<MedicalRecordAct> getsByIdMedicalRecord( int  value)
        {
            try
            {
                string query = "select *from MedicalRecordAct where(IdMedicalRecord=@value);";
                SqlConnection con = DbConnection.GetConnection();
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 50;

                if (string.IsNullOrEmpty(value.ToString()))
                    command.Parameters.AddWithValue("@value", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@value", value);

                SqlDataReader reader = command.ExecuteReader();
                DataTable ta = new DataTable();
                ta.Load(reader);
                con.Close();
                return gets(ta);
            }
            catch
            {
                return null;
            }
        }
        public static Message add(MedicalRecordAct medicalRecordAct) 
        {
            try
            {
                if (string.IsNullOrEmpty(medicalRecordAct.MedicalActType) && string.IsNullOrEmpty(medicalRecordAct.MedicalActName))
                {
                    medicalRecordAct.MedicalActType = DAL_MedicalAct.getByID(medicalRecordAct.IdMedicalAct).MedicalActType;
                    medicalRecordAct.MedicalActName = DAL_MedicalAct.getByID(medicalRecordAct.IdMedicalAct).Name;
                }
                 
                string query = " insert into MedicalRecordAct(IdMedicalRecord,IdPrescribingDoctorMedical,IdMedicalAct,Rang,State ,Patients,MedicalActType,MedicalActName)values(@IdMedicalRecord,@IdPrescribingDoctorMedical,@IdMedicalAct,@Rang,@State,@Patients,@MedicalActType,@MedicalActName);";
                SqlConnection conn= DbConnection.GetConnection();
                conn.Open();
                SqlCommand cmd=new SqlCommand(query,conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;

                cmd.Parameters.AddWithValue("@IdMedicalRecord", medicalRecordAct.IdMedicalRecord);
                cmd.Parameters.AddWithValue("@IdPrescribingDoctorMedical", medicalRecordAct.IdPrescribingDoctorMedical);
                cmd.Parameters.AddWithValue("@IdMedicalAct", medicalRecordAct.IdMedicalAct);
                if (string.IsNullOrEmpty(medicalRecordAct.Patients))
                    cmd.Parameters.AddWithValue("@Patients", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Patients", medicalRecordAct.Patients);

                if (string.IsNullOrEmpty(medicalRecordAct.MedicalActType))
                    cmd.Parameters.AddWithValue("@MedicalActType", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@MedicalActType", medicalRecordAct.MedicalActType);

                if (string.IsNullOrEmpty(medicalRecordAct.MedicalActName))
                    cmd.Parameters.AddWithValue("@MedicalActName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@MedicalActName", medicalRecordAct.MedicalActName);

                if (string.IsNullOrEmpty(medicalRecordAct.Rang))
                    cmd.Parameters.AddWithValue("@Rang", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Rang",1+ countMedicalrecordActbyIdactIddossier(medicalRecordAct.MedicalActName, medicalRecordAct.IdMedicalRecord, medicalRecordAct.Patients));

                if (string.IsNullOrEmpty(medicalRecordAct.State))
                    cmd.Parameters.AddWithValue("@State", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@State", medicalRecordAct.State);

                cmd.ExecuteNonQuery();
                conn.Close();
                return new Message(true, "MedicalRecordAct ajouté");
            }
            catch (Exception e)
            {
                return new Message(false,e.Message);
            
            }
        
        }
        public static Message update(MedicalRecordAct medicalRecordAct)
        {
            try
            {
                var t = medicalRecordAct;
                if (string.IsNullOrEmpty(medicalRecordAct.MedicalActType) && string.IsNullOrEmpty(medicalRecordAct.MedicalActName))
                {
                    medicalRecordAct.MedicalActType = DAL_MedicalAct.getByID(medicalRecordAct.IdMedicalAct).MedicalActType;
                    medicalRecordAct.MedicalActName = DAL_MedicalAct.getByID(medicalRecordAct.IdMedicalAct).Name;
                }

                string query = "update  MedicalRecordAct set Patients=@Patients, IdMedicalRecord=@IdMedicalRecord,MedicalActType=@MedicalActType,IdPrescribingDoctorMedical=@IdPrescribingDoctorMedical,IdMedicalAct=@IdMedicalAct,Rang=@Rang,State=@State where(Id=@Id);";
                SqlConnection conn = DbConnection.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;

                cmd.Parameters.AddWithValue("@IdMedicalRecord", medicalRecordAct.IdMedicalRecord);
                cmd.Parameters.AddWithValue("@IdPrescribingDoctorMedical", medicalRecordAct.IdPrescribingDoctorMedical);
                cmd.Parameters.AddWithValue("@IdMedicalAct", medicalRecordAct.IdMedicalAct);
                if (string.IsNullOrEmpty(medicalRecordAct.Patients))
                    cmd.Parameters.AddWithValue("@Patients", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Patients", medicalRecordAct.Patients);

                if (string.IsNullOrEmpty(medicalRecordAct.MedicalActType))
                    cmd.Parameters.AddWithValue("@MedicalActType", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@MedicalActType", medicalRecordAct.MedicalActType);

                if (string.IsNullOrEmpty(medicalRecordAct.MedicalActName))
                    cmd.Parameters.AddWithValue("@MedicalActName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@MedicalActName", medicalRecordAct.MedicalActName);

                if (string.IsNullOrEmpty(medicalRecordAct.Rang))
                    cmd.Parameters.AddWithValue("@Rang", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Rang", medicalRecordAct.Rang);

                if (string.IsNullOrEmpty(medicalRecordAct.State))
                    cmd.Parameters.AddWithValue("@State", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@State", medicalRecordAct.State);

                if (string.IsNullOrEmpty(medicalRecordAct.State))
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", medicalRecordAct.Id);

                cmd.ExecuteNonQuery();
                conn.Close();
                return new Message(true, "MedicalRecordAct modifié");
            }
            catch (Exception e)
            {
                return new Message(false,e.Message);

            }

        }
        public static Message terminer (int Id )
        {
            try
            {
                

                string query = "update  MedicalRecordAct set State='Terminer' where(Id=@Id);";
                SqlConnection conn = DbConnection.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;


                if (string.IsNullOrEmpty(Id.ToString()))
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", Id);

                cmd.ExecuteNonQuery();
                conn.Close();
                return new Message(true, "MedicalRecordAct terminer");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);

            }

        }


     
        public static Message delete(int id)
        {
            try
            {
                string query = "delete  MedicalRecordAct where(Id=@id) ;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "MedicalRecordAct supprimer");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }
        public static Message deletebYMedicalACTId(int id)
        {
            try
            {
                string query = "delete  MedicalRecordAct where(IdMedicalAct=@id) ;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "MedicalRecordAct supprimer");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }
        public static Message deleteDossierMedical(int id)
        {
            try
            {
                string query = "delete  MedicalRecordAct where(IdMedicalRecord=@id) ;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "MedicalRecordAct supprimer");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }
        public static Message deletebYdoctorId(int id)
        {
            try
            {
                string query = "delete  MedicalRecordAct where(IdPrescribingDoctorMedical=@id) ;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "MedicalRecordAct supprimer");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }

        public static MedicalRecordAct getBYiD (int id )
        {
            try
            {
                string query = "select *from MedicalRecordAct where(Id=@id) ; ";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 50;

                command.Parameters.AddWithValue("@id",id);
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                connection.Close();
                return get(table.Rows[0]);

            }
            catch
            {
                return null;

            }
        }

        public static int countMedicalrecordActbyIdactIddossier(string IdACT ,int IdDosssier,string Patients )
        {
            try
            {
                string query = "select COUNT (*)from MedicalRecordAct where(IdMedicalRecord=@IdDosssier and MedicalActName=@IdACT and MedicalActType='TRAITEMENT Cycle' and Patients =@Patients); ";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 50;

                command.Parameters.AddWithValue("@IdDosssier", IdDosssier);
                command.Parameters.AddWithValue("@IdACT", IdACT);
                command.Parameters.AddWithValue("@Patients", Patients);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return Int32.Parse(reader[0].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;

            }
        }


        
    }
}
