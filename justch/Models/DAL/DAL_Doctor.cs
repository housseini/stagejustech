using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace justch.Models.DAL
{
    public class DAL_Doctor
    {
        public static Doctor get(DataRow row)
        {
            Doctor doctor = new Doctor();
            doctor.Id = Int32.Parse(row["Id"].ToString());
            if (string.IsNullOrEmpty(row["FirstName"].ToString()))
            { }
            else
                doctor.FirstName = (string)row["FirstName"];

            if (string.IsNullOrEmpty(row["LastName"].ToString()))
            { }
            else
                doctor.LastName = (string)row["LastName"];

            if (string.IsNullOrEmpty(row["Speciality"].ToString()))
            { }
            else
                doctor.Speciality = (string)row["Speciality"];

            if (string.IsNullOrEmpty(row["Phone1"].ToString()))
            { }
            else
                doctor.Phone1 = (string)row["Phone1"];

            if (string.IsNullOrEmpty(row["Phone2"].ToString()))
            { }
            else
                doctor.Phone2 = (string)row["Phone2"];

            if (string.IsNullOrEmpty(row["Email"].ToString()))
            { }
            else
                doctor.Email = (string)row["Email"];

            if (string.IsNullOrEmpty(row["Adress"].ToString()))
            { }
            else
                doctor.Adress = (string)row["Adress"];

            if (string.IsNullOrEmpty(row["Affiliation"].ToString()))
            { }
            else
                doctor.Affiliation = (string)row["Affiliation"];

            if (string.IsNullOrEmpty(row["Type"].ToString()))
            { }
            else
                doctor.Type = (string)row["Type"];

            return doctor;
        }
        public static List<Doctor> gets(DataTable table) {
            List<Doctor> doctors= new List<Doctor>();
          foreach (DataRow dr in table.Rows)
                doctors.Add(get(dr));
          return doctors;
        }
        public static Doctor getBy(int id)
        {

            try
            {
                string query = "select *from Doctor where(Id=@id);";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                mycon.Close();
                return get(table.Rows[0]);
            }
            catch
            {
                return null;
            }
        }
        public static List<Doctor> gets( )
        {
            string query = "select * from Doctor ; ";
            SqlConnection mycon = DbConnection.GetConnection();
            mycon.Open();
            SqlCommand cmd = new SqlCommand(query, mycon);
            cmd.CommandTimeout = 50;
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            mycon.Close();
            return gets(table);
        }
        public static Message add(Doctor doctor)
        {
            try
            {
                string query = "insert into Doctor (FirstName,LastName,Speciality,Phone1,Phone2,Email,Adress,Affiliation,Type)values(@FirstName,@LastName,@Speciality,@Phone1,@Phone2,@Email,@Adress,@Affiliation,@Type); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(doctor.FirstName))
                    cmd.Parameters.AddWithValue("@FirstName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);

                if (string.IsNullOrEmpty(doctor.LastName))
                    cmd.Parameters.AddWithValue("@LastName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@LastName", doctor.LastName);

                if (string.IsNullOrEmpty(doctor.Speciality))
                    cmd.Parameters.AddWithValue("@Speciality", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Speciality", doctor.Speciality);

                if (string.IsNullOrEmpty(doctor.Phone1))
                    cmd.Parameters.AddWithValue("@Phone1", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Phone1", doctor.Phone1);

                if (string.IsNullOrEmpty(doctor.Phone2))
                    cmd.Parameters.AddWithValue("@Phone2", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Phone2", doctor.Phone2);

                if (string.IsNullOrEmpty(doctor.Email))
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Email", doctor.Email);

                if (string.IsNullOrEmpty(doctor.Adress))
                    cmd.Parameters.AddWithValue("@Adress", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Adress", doctor.Adress);

                if (string.IsNullOrEmpty(doctor.Affiliation))
                    cmd.Parameters.AddWithValue("@Affiliation", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Affiliation", doctor.Affiliation);


                if (string.IsNullOrEmpty(doctor.Type))
                    cmd.Parameters.AddWithValue("@Type", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Type", doctor.Type);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Docteur   ajouté");

            }
            catch(Exception e)
            {
                if (e.Message.Contains("Violation of UNIQUE KEY"))
                    return new Message(false, "ce EMAIL EST Deja utilisé");
                else
                    return new Message(false, e.Message);


            }
        }
        public static Message update(Doctor doctor)
        {
            try
            {
                string query = "update Doctor  set FirstName=@FirstName,LastName=@LastName,Speciality=@Speciality,Phone1=@Phone1,Phone2=@Phone2,Email=@Email,Adress=@Adress,Affiliation=@Affiliation,Type=@Type where(Id=@Id); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(doctor.FirstName))
                    cmd.Parameters.AddWithValue("@FirstName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);

                if (string.IsNullOrEmpty(doctor.LastName))
                    cmd.Parameters.AddWithValue("@LastName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@LastName", doctor.LastName);

                if (string.IsNullOrEmpty(doctor.Speciality))
                    cmd.Parameters.AddWithValue("@Speciality", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Speciality", doctor.Speciality);

                if (string.IsNullOrEmpty(doctor.Phone1))
                    cmd.Parameters.AddWithValue("@Phone1", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Phone1", doctor.Phone1);

                if (string.IsNullOrEmpty(doctor.Phone2))
                    cmd.Parameters.AddWithValue("@Phone2", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Phone2", doctor.Phone2);

                if (string.IsNullOrEmpty(doctor.Email))
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Email", doctor.Email);

                if (string.IsNullOrEmpty(doctor.Adress))
                    cmd.Parameters.AddWithValue("@Adress", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Adress", doctor.Adress);

                if (string.IsNullOrEmpty(doctor.Affiliation))
                    cmd.Parameters.AddWithValue("@Affiliation", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Affiliation", doctor.Affiliation);


                if (string.IsNullOrEmpty(doctor.Type))
                    cmd.Parameters.AddWithValue("@Type", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Type", doctor.Type);

                if (string.IsNullOrEmpty(doctor.Id.ToString()))
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", doctor.Id);
                cmd.ExecuteNonQuery();
                mycon.Close();
                return new Message(true, "Docteur   modifié");

            }
            catch (Exception e)
            {
               
                    return new Message(false, e.Message);


            }
        }
        public static Message Delete(int id)
        {
            try
            {
                string query = "delete Doctor where(Id=@value); ";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;


                cmd.Parameters.AddWithValue("@value", id);
                cmd.ExecuteNonQuery();
                mycon.Close();
                DAL_MedicalRecordAct.deletebYdoctorId(id);
                DAL_Appointment.deletebyidDoctor(id);
                return new Message(true, "Doctor delete");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
        }


    }
}
