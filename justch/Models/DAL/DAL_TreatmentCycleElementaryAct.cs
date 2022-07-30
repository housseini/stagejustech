
using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.DAL
{
    public class DAL_TreatmentCycleElementaryAct
    {
        public static Message ADD(int Idmedical ,int Idtraitement)
        {
            try
            {
                string query = "insert into TreatmentCycleElementact(IdMedicalAct,IdTraitementCycle)values(@IdMedicalAct,@IdTraitementCycle)";
            SqlConnection connection = DbConnection.GetConnection();
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.Text;
            if (string.IsNullOrEmpty(Idmedical.ToString()))
                 
                cmd.Parameters.AddWithValue("@IdMedicalAct", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@IdMedicalAct", Idmedical);

            if (string.IsNullOrEmpty(Idtraitement.ToString()))
                 
                cmd.Parameters.AddWithValue("@IdTraitementCycle", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@IdTraitementCycle", Idtraitement);

            cmd.ExecuteNonQuery();
            connection.Close();
   


               return new Message(true, "TreatmentCycleElementact ajouter");

        }
            catch (Exception e)
            {
                return new Message(false, "erreur" + e.Message);
    }


}
        public static TreatmentCycleElementaryAct get(DataRow row)
        {
            TreatmentCycleElementaryAct elementaryAct = new TreatmentCycleElementaryAct();
            elementaryAct.Id = Int32.Parse(row["Id"].ToString());
            elementaryAct.IdMedicalAct = Int32.Parse(row["IdMedicalAct"].ToString());
            elementaryAct.IdTreatmentCycle = Int32.Parse(row["IdTraitementCycle"].ToString());
            return elementaryAct;
        }
        public static List<TreatmentCycleElementaryAct> gets(DataTable rows)
        {
            List<TreatmentCycleElementaryAct> elementaryActs = new List<TreatmentCycleElementaryAct>();
            foreach (DataRow row in rows.Rows)
                elementaryActs.Add(get(row));
            return elementaryActs;
        }

        public static List<TreatmentCycleElementaryAct> gets()
        {
            string query = "select *from TreatmentCycleElementact ;";
            SqlConnection con = DbConnection.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            con.Close();
            return (gets(table));
        }
        /// <summary>
        /// retourne TCACM DONT ID DE ACT ELEMENTAIRE CYCLE EST PASSE EN PARAMMETRE 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static TCACM GetTCACMbyID(int Id)
        {
            try
            {
                string query = "select *from TreatmentCycleElementact where (Id=@Id) ;";
                SqlConnection con = DbConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(Id.ToString()))

                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(dr);
                con.Close();
                return new TCACM(get(table.Rows[0]));

            }
            catch
            {
                return null;
            }
        }

        public static Message Update(TreatmentCycleElementaryAct t)
        {
            try
            {
                string query = "update  TreatmentCycleElementact set IdMedicalAct=@Name where(Id=@Id)";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(t.IdMedicalAct.ToString()))
                    cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Name", t.IdMedicalAct);
                if (string.IsNullOrEmpty(t.Id.ToString()))
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Id", t.Id);
                cmd.ExecuteNonQuery();
                connection.Close();
                return new Message(true, "TreatmentCycleElementact modifié");

            }
            catch (Exception e)
            {
                return new Message(false, "erreur" + e.Message);
            }

        }


    }
}
