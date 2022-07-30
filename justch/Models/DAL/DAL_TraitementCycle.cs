using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace justch.Models.DAL
{
    public class DAL_TraitementCycle
    {
        public static TraitementCycle Get(DataRow row)
        {

            TraitementCycle TraitementCycle = new TraitementCycle();
            TraitementCycle.Id = Int32.Parse(row["Id"].ToString());
            TraitementCycle.Name = (string)row["Name"];
            return TraitementCycle;
        }
        public static List<TraitementCycle> Gets(DataTable table)
        {
            List<TraitementCycle> TraitementCycles = new List<TraitementCycle>();
            foreach (DataRow row in table.Rows)
                TraitementCycles.Add(Get(row));
            return TraitementCycles;
        }
        public static List<TraitementCycle> Gets()
        {
            string query = "select *from TraitementCycle ;";
            SqlConnection con = DbConnection.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            con.Close();
            return (Gets(table));


        }
        public static List<TraitementCycle> GetsBy(string Value, string Field)
        {
            string query = "select *from TraitementCycle where(@Field=@Value) ;";
            SqlConnection con = DbConnection.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            if (string.IsNullOrEmpty(Value))
                cmd.Parameters.AddWithValue("@Value", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Value", Value);
            if (string.IsNullOrEmpty(Field))
                cmd.Parameters.AddWithValue("@Field", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Field", Field);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            con.Close();
            return (Gets(table));
        }


        public static int GetsByName(string Value)
        {
            string query = "select *from TraitementCycle where(Name=@Value) ;";
            SqlConnection con = DbConnection.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            if (string.IsNullOrEmpty(Value))
                cmd.Parameters.AddWithValue("@Value", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Value", Value);
           
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            con.Close();
            return ( Int32.Parse(table.Rows[0]["Id"].ToString()));
        }
        public static TraitementCycle GetsById(int Value)
        {
            string query = "select *from TraitementCycle where(Id=@Value) ;";
            SqlConnection con = DbConnection.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            if (string.IsNullOrEmpty(Value.ToString()))
                cmd.Parameters.AddWithValue("@Value", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Value", Value);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            con.Close();
            return (Get(table.Rows[0]));
        }



        public static Message deletById(int Value)
        {
            try
            {
                string query = "delete TraitementCycle where(Id=@Value) ;";
                SqlConnection con = DbConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(Value.ToString()))
                    cmd.Parameters.AddWithValue("@Value", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Value", Value);

               cmd.ExecuteNonQuery();
              
                con.Close();
               query = "delete TreatmentCycleElementact where(IdTraitementCycle=@Value) ;";
               con = DbConnection.GetConnection();
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(Value.ToString()))
                    cmd.Parameters.AddWithValue("@Value", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Value", Value);

                cmd.ExecuteNonQuery();

                con.Close();


                return new Message(true, " traitement cycle supprimer ");
            }
            catch(Exception e)
            {
                return new Message(false, " erreur "+ e.Message);
            }
           
        }



        public static Message Add(TraitementCycle t)
        {
            try
            {
                string query = "insert into TraitementCycle(Name)values(@Name)";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(t.Name))
                    cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Name", t.Name);

                cmd.ExecuteNonQuery();
                connection.Close();
                t.Id = GetsByName(t.Name);
                if (t.Id != 0)
                {
                    return DAL_TreatmentCycleElementaryAct.ADD(t.IdMedicalAct, t.Id);
                }
                else
                {
                    return new Message(false, "" + GetsByName(t.Name));


                }

              //  return new Message(false, "" + GetsByName(t.Name));





            }
            catch (Exception e)
            {
                if (e.Message.Contains("Violation of UNIQUE KEY"))
                    return new Message(false, "ce nom EXISTE DEJA");
                return new Message(false, "erreur" + e.Message);
            }

        }
        public static Message Update(TraitementCycle t,TreatmentCycleElementaryAct te)
        {
            try
            {
                string query = "update  TraitementCycle set Name=@Name where(Id=@Id)";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(t.Name))
                    cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Name", t.Name);
                if (string.IsNullOrEmpty(t.Name))
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", t.Id);
                cmd.ExecuteNonQuery();
                connection.Close();
                DAL_TreatmentCycleElementaryAct.Update(te);

                return new Message(true, "TraitementCycle modifié");

            }
            catch (Exception e)
            {
                return new Message(false, "erreur" + e.Message);
            }

        }
    }
    }
