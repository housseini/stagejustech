using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace justch.Models.DAL
{
    public class DAL_TechnienEnbrylogiste
    {
        
        public static TechnienEnbrylogiste  Get(DataRow data )
        {

            TechnienEnbrylogiste technien= new TechnienEnbrylogiste();
            technien.Id = Int32.Parse( data["Id"].ToString());
            if (string.IsNullOrEmpty(data["FirsName"].ToString()))
            {
                technien.FirsName = " ";
            }
            else
                technien.FirsName = (string)data["FirsName"];
            if (string.IsNullOrEmpty(data["LastName"].ToString()))
                technien.LastName = "";
            else
                technien.LastName= (string)data["LastName"];

            return technien;


        }

        public static List<TechnienEnbrylogiste> Gets(DataTable table )
        {
            List<TechnienEnbrylogiste> techniens = new List<TechnienEnbrylogiste>();
            foreach (DataRow row in table.Rows)
                techniens.Add(Get(row));
            return techniens;
        }

        public static List<TechnienEnbrylogiste> Gets ( )
        {

            string query = "select *FROM TechnienEnbrylogiste;";
            SqlConnection cnn = DbConnection.GetConnection();
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query, cnn);

            SqlDataReader reader = cmd.ExecuteReader(); 
            DataTable table = new DataTable();
            table.Load(reader);
            return Gets(table);



        }


        public static TechnienEnbrylogiste GetsbyId ( int Id )
        {

            string query = "select *FROM TechnienEnbrylogiste where(Id=@Id);";
            SqlConnection cnn = DbConnection.GetConnection();
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return Get(table.Rows[0]);



        }

        public static Message Add ( TechnienEnbrylogiste enbrylogiste )
        {


            try
            {
                string query = "insert into TechnienEnbrylogiste(FirsName,LastName) values(@FirsName,@LastName);";
                SqlConnection cnn = DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(enbrylogiste.FirsName))
                    cmd.Parameters.AddWithValue("@FirsName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@FirsName", enbrylogiste.FirsName);

                if (string.IsNullOrEmpty(enbrylogiste.LastName))
                    cmd.Parameters.AddWithValue("@LastName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@LastName", enbrylogiste.LastName);

                cmd.ExecuteNonQuery();
                cnn.Close();

                return new Message(true, "enbrylogiste ajouté");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }

        public static Message Update ( TechnienEnbrylogiste enbrylogiste )
        {


            try
            {
                string query = "update  TechnienEnbrylogiste  set FirsName=@FirsName,LastName=@LastName where(Id=@Id);";
                SqlConnection cnn = DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", enbrylogiste.Id);
                if (string.IsNullOrEmpty(enbrylogiste.FirsName))
                    cmd.Parameters.AddWithValue("@FirsName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@FirsName", enbrylogiste.FirsName);

                if (string.IsNullOrEmpty(enbrylogiste.LastName))
                    cmd.Parameters.AddWithValue("@LastName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@LastName", enbrylogiste.LastName);

                cmd.ExecuteNonQuery();
                cnn.Close();

                return new Message(true, "enbrylogiste modifier");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }

        public static Message Delete ( int id )
        {


            try
            {
                string query = "delete  TechnienEnbrylogiste  where(Id=@Id);";
                SqlConnection cnn = DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", id);
                
                cmd.ExecuteNonQuery();
                cnn.Close();

                return new Message(true, "enbrylogiste supprimer");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }

    }

}
