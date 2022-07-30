using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace justch.Models.DAL
{
    public class DAL_MedicalAct
    {
        public static MedicalAct get(DataRow row)
        {
            MedicalAct medicalAct = new MedicalAct();   
            medicalAct.ID =Int32.Parse(row["ID"].ToString());
            medicalAct.IdRoom = Int32.Parse(row["IdRoom"].ToString());
            medicalAct.Name =(string) row["Name"];
            medicalAct.MedicalActType = (string)row["MedicalActType"];
            medicalAct.Duration= (string)row["Duration"];
            medicalAct.Category = (string)row["Category"];

            return medicalAct;
        }
        public static List<MedicalAct> gets(DataTable dataTable)
        {
            List<MedicalAct> ts = new List<MedicalAct>();
            foreach (DataRow row in dataTable.Rows)
                ts.Add(get(row));
            return ts;

        }
        public static List<MedicalAct> gets() {
            try
            {
                DalMigration.create_table_MedicalAct();
                string query = "select *from MedicalAct ;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable table =new DataTable();
                table.Load(reader);
                mycon.Close();
                return gets(table);

            }
            catch
            {
                return null;
            }
            
        
        }
        public static List<MedicalAct> getBy(string Field,string value)
        {
            try
            {
                string query = "select *from  MedicalAct where(@Field=@value)";
                SqlConnection connection=DbConnection.GetConnection();
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(Field))
                    command.Parameters.AddWithValue("@Field", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Field", Field);
                if (string.IsNullOrEmpty(value))
                    command.Parameters.AddWithValue("@value", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@value", value);


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
        public static Message add(MedicalAct medicalAct)
        {
            try
            {
                string query = "insert into MedicalAct(Name,MedicalActType,Duration,Category,IdRoom) values(@Name,@MedicalActType,@Duration,@Category,@IdRoom)";
                SqlConnection connection= DbConnection.GetConnection();
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(medicalAct.Name))
                    sqlCommand.Parameters.AddWithValue("@Name", DBNull.Value);
                else
                    sqlCommand.Parameters.AddWithValue("@Name", medicalAct.Name);

                sqlCommand.Parameters.AddWithValue("@IdRoom", medicalAct.IdRoom);
                if (string.IsNullOrEmpty(medicalAct.MedicalActType))
                    sqlCommand.Parameters.AddWithValue("@MedicalActType", DBNull.Value);
                else
                    sqlCommand.Parameters.AddWithValue("@MedicalActType", medicalAct.MedicalActType);

                if (string.IsNullOrEmpty(medicalAct.Duration))
                    sqlCommand.Parameters.AddWithValue("@Duration", DBNull.Value);
                else
                    sqlCommand.Parameters.AddWithValue("@Duration", medicalAct.Duration);

                if (string.IsNullOrEmpty(medicalAct.Category))
                    sqlCommand.Parameters.AddWithValue("@Category", DBNull.Value);
                else
                    sqlCommand.Parameters.AddWithValue("@Category", medicalAct.Category);

                sqlCommand.ExecuteNonQuery();
                connection.Close();
                return new Message(true, "MEDICAL ACT AJOUTé");

            }
            catch
            {
                return new Message(false,"cet ACTE EXISTE DEJA  ");
            }

        }
        public static Message update(MedicalAct medicalAct)
        {
            try
            {
                string query = "update  MedicalAct set Name=@Name,MedicalActType=@MedicalActType,Duration=@Duration,Category=@Category,IdRoom=@IdRoom   where(ID=@ID);";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@ID", medicalAct.ID);

                if (string.IsNullOrEmpty(medicalAct.Name))
                    sqlCommand.Parameters.AddWithValue("@Name", DBNull.Value);
                else
                    sqlCommand.Parameters.AddWithValue("@Name", medicalAct.Name);

                sqlCommand.Parameters.AddWithValue("@IdRoom", medicalAct.IdRoom);
                if (string.IsNullOrEmpty(medicalAct.MedicalActType))
                    sqlCommand.Parameters.AddWithValue("@MedicalActType", DBNull.Value);
                else
                    sqlCommand.Parameters.AddWithValue("@MedicalActType", medicalAct.MedicalActType);

                if (string.IsNullOrEmpty(medicalAct.Duration))
                    sqlCommand.Parameters.AddWithValue("@Duration", DBNull.Value);
                else
                    sqlCommand.Parameters.AddWithValue("@Duration", medicalAct.Duration);

                if (string.IsNullOrEmpty(medicalAct.Category))
                    sqlCommand.Parameters.AddWithValue("@Category", DBNull.Value);
                else
                    sqlCommand.Parameters.AddWithValue("@Category", medicalAct.Category);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                return new Message(true, "MEDICAL ACT modifié");

            }
            catch(Exception e)
            {
                return new Message(false,e.Message );
            }

        }
        public static Message delete(int id)
        {
            try
            {
                string query = "delete  MedicalAct where(ID=@id) ;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);

               cmd.ExecuteNonQuery();
                mycon.Close();
                DAL_MedicalRecordAct.deletebYMedicalACTId(id);
                DAL_Appointment.deletebyidMEdicalACTE(id);
                return new Message(true, "MEDICAL ACT supprimer");

            }
            catch(Exception e)
            {
                return new Message(false,e.Message); 
            }

        }
        public static MedicalAct getByID(int value)
        {
            try
            {
                string query = "select *from  MedicalAct where(ID=@value)";
                SqlConnection connection = DbConnection.GetConnection();
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.CommandType = CommandType.Text;
               
                command.Parameters.AddWithValue("@value", value);


                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                connection.Close();
                return get(table.Rows[0]) ;
            }
            catch
            {
                return null;
            }
        }







    }
}
