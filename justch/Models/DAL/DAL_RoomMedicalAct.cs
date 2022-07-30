using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace justch.Models.DAL
{
    public class DAL_RoomMedicalAct
    {
        public static RoomMedicalAct Get(DataRow row)
        {
            RoomMedicalAct RoomMedicalAct = new RoomMedicalAct();
            RoomMedicalAct.Id = (int)row["Id"];
            RoomMedicalAct.IdMedicalAct = (int)row["IdMedicalAct"];
            RoomMedicalAct.idRoom = (int)row["idRoom"];

            return RoomMedicalAct;
        }

        public static List<RoomMedicalAct> Gets(DataTable table)
        {
            List<RoomMedicalAct> list = new List<RoomMedicalAct>();
            foreach (DataRow row in table.Rows)
                list.Add(Get(row));
            return list;
        }
        public static List<RoomMedicalAct> Gets()
        {
            try
            {

                string query = "select * from RoomMedicalAct ;";
                SqlConnection cnn = DbConnection.GetConnection();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
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
        public static List<RoomMedicalAct> GetsBy(string Field, string Value)
        {
            try
            {

                string query = "select * from RoomMedicalAct where(@Field=@Value);";
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
        public static Message Add(RoomMedicalAct room)
        {
            try
            {
                string query = "insert into RoomMedicalAct (IdMedicalAct,idRoom) value(@IdMedicalAct,@idRoom);";
                SqlConnection cnn = DbConnection.GetConnection();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(room.IdMedicalAct.ToString()))
                    cmd.Parameters.AddWithValue("@IdMedicalAct", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdMedicalAct", room.IdMedicalAct);

                if (string.IsNullOrEmpty(room.idRoom.ToString()))
                    cmd.Parameters.AddWithValue("@idRoom", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@idRoom", room.idRoom);

                cmd.ExecuteNonQuery();

                return new Message(true, "RoomMedicalAct ajouté");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }
        public static Message Update(RoomMedicalAct room)
        {
            try
            {
                string query = "update RoomMedicalAct set idRoom=@idRoom,IdMedicalAct=@IdMedicalAct where(Id=@Id);";
                SqlConnection cnn = DbConnection.GetConnection();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(room. idRoom.ToString()))
                    cmd.Parameters.AddWithValue("@idRoom", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@idRoom", room.idRoom);

                if (string.IsNullOrEmpty(room.IdMedicalAct.ToString()))
                    cmd.Parameters.AddWithValue("@IdMedicalAct", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdMedicalAct", room.IdMedicalAct);

                if (string.IsNullOrEmpty(room.Id.ToString()))
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", room.Id);

                cmd.ExecuteNonQuery();

                return new Message(true, "RoomMedicalAct  modifié");

            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }

        }
    }
}
