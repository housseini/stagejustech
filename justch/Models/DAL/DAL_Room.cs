using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace justch.Models.DAL
{
    public class DAL_Room
    {
        public static Room Get(DataRow row)
        {
            Room room = new Room(); 
            room.Id = Int32.Parse( row["Id"].ToString());
            room.Name = (string) row["Name"];
            room.IdRoomType = Int32.Parse( row["IdRoomType"].ToString());

            return room;
        }

        public static List<Room> Gets(DataTable table)
        {
            List<Room> list = new List<Room>();
            foreach (DataRow row in table.Rows)
                list.Add(Get(row));
            return list;
        }
        public static List<Room> Gets()
        {
            try
            {

                string query = "select * from Room ;";
                SqlConnection cnn=DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                DataTable table= new DataTable();   
                SqlDataReader reader=cmd.ExecuteReader();
                table.Load(reader);
                return Gets(table);
            }
            catch
            {
                return null;
            }
            
            
        }
        public static List<Room> GetsBy(string Field ,string Value)
        {
            try
            {

                string query = "select * from Room where(@Field=@Value);";
                SqlConnection cnn = DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(Field))
                    cmd.Parameters.AddWithValue("@Field", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Field", Field);
                        
                if (string.IsNullOrEmpty(Value))
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
        public static Room GetByID(int Id )
        {
            try
            {

                string query = "select * from Room where(Id=@Id);";
                SqlConnection cnn = DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
              

                if (string.IsNullOrEmpty(Id.ToString()))
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", Id);

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
        public static Message Add(Room room)
        {
            try
            {
                string query = "insert into Room(IdRoomType,Name) values(@IdRoomType,@Name);";
                SqlConnection cnn=DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd= new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(room.IdRoomType.ToString()))
                    cmd.Parameters.AddWithValue("@IdRoomType", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdRoomType", room.IdRoomType);

                if (string.IsNullOrEmpty(room.Name))
                    cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Name", room.Name);

                cmd.ExecuteNonQuery();
                cnn.Close();

                return new Message(true, "Room ajouté");

            }
            catch(Exception e)
            {
                return new Message(false, e.Message);
            }

        }
        public static Message Update(Room room)
        {
            try
            {
                string query = "update Room set IdRoomType=@IdRoomType,Name=@Name where(Id=@Id);";
                SqlConnection cnn = DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(room.IdRoomType.ToString()))
                    cmd.Parameters.AddWithValue("@IdRoomType", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdRoomType", room.IdRoomType);

                if (string.IsNullOrEmpty(room.Name))
                    cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Name", room.Name);

                if (string.IsNullOrEmpty(room.Id.ToString()))
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", room.Id);

                cmd.ExecuteNonQuery();

                return new Message(true, "Room modifié");

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
                string query = "delete  Room where(Id=@id) ;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                mycon.Close();
                DAL_Appointment.deletebyidROMs(id);
                return new Message(true, " Room supprimer");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }

        public static Message deletebyIdRomtype(int id)
        {
            try
            {
                string query = "delete  Room where(IdRoomType=@id) ;";
                SqlConnection mycon = DbConnection.GetConnection();
                mycon.Open();
                SqlCommand cmd = new SqlCommand(query, mycon);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                mycon.Close();
                DAL_Appointment.deletebyidROMs(id);
                return new Message(true, " Room supprimer");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }



    }
}
