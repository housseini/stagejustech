using justch.Models.DAL;
using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace justch.Models.ENTITIES {
    public class DAL_RoomType
    {
        public static RoomType Get(DataRow row)
        {
            RoomType RoomType = new RoomType();
            RoomType.Id = Int32.Parse( row["Id"].ToString());
            RoomType.Name = (string)row["Name"];


            return RoomType;
        }

        public static List<RoomType> Gets(DataTable table)
        {
            List<RoomType> list = new List<RoomType>();
            foreach (DataRow row in table.Rows)
                list.Add(Get(row));
            return list;
        }
        public static List<RoomType> Gets()
        {
            try
            {

                string query = "select * from RoomType ;";
                SqlConnection cnn = DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                DataTable table = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
                cnn.Close();
                return Gets(table);
            }
            catch
            {
                return null;
            }


        }
        public static List<RoomType> GetsBy( int Value)
        {
            try
            {

                string query = "select * from RoomType where(Id=@Value);";
                SqlConnection cnn = DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
               
                if (string.IsNullOrEmpty(Value.ToString()))
                    cmd.Parameters.AddWithValue("@Value", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Value", Value);

                DataTable table = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
                return Gets(table);
            }
            catch
            {
                return null;
            }


        }
        public static RoomType GetsByNom(string Value)
        {
            try
            {

                string query = "select * from RoomType where(Name=@Value);";
                SqlConnection cnn = DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;

                if (string.IsNullOrEmpty(Value.ToString()))
                    cmd.Parameters.AddWithValue("@Value", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Value", Value);

                DataTable table = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
                return Get(table.Rows[0]);
            }
            catch
            {
                return null;
            }


        }

        public static Message Add(RoomType RoomType)
        {
            try
            {
                string query = "insert into RoomType(Name) values(@Name);";
                SqlConnection cnn = DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
             

                if (string.IsNullOrEmpty(RoomType.Name))
                    cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Name", RoomType.Name);

                cmd.ExecuteNonQuery();
                cnn.Close();
                return new Message(true, "RoomType ajouté");

            }
            catch (Exception e)
            {
                if (e.Message.Contains("Violation of UNIQUE KEY constraint"))
                    return new Message(false,"ce type de salle exite deja");
                return new Message(false, e.Message);
            }

        }
        public static Message Update(RoomType RoomType)
        {
            try
            {
                string query = "update RoomType set Name=@Name where(Id=@Id);";
                SqlConnection cnn = DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
               
            

                if (string.IsNullOrEmpty(RoomType.Name))
                    cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Name", RoomType.Name);

                if (string.IsNullOrEmpty(RoomType.Id.ToString()))
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", RoomType.Id);

                cmd.ExecuteNonQuery();
                cnn.Close();


                return new Message(true, "RoomType modifié");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }
        public static Message delete ( int id )
        {
            try
            {
                string query = "delete  RoomType where(Id=@id) ;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                mycon.Close();
                DAL_Room.deletebyIdRomtype(id);
                    
                return new Message(true, " RoomType supprimer");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }

    }
}
