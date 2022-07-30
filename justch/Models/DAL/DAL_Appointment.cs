using justch.Models.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace justch.Models.DAL
{
    public class DAL_Appointment
    {
        public static Appointment Get(DataRow row)
        {
            Appointment ap = new Appointment();
            ap.Id = Int32.Parse( row["Id"].ToString());
            ap.IdPatient1 = Int32.Parse(row["IdPatient1"].ToString());
            if (string.IsNullOrEmpty(row["IdPatient2"].ToString())) { }
            else
                ap.IdPatient2 = Int32.Parse(row["IdPatient2"].ToString()); ;

            ap.IdRoom1 = Int32.Parse(row["IdRoom1"].ToString());

            if (string.IsNullOrEmpty(row["IdRoom2"].ToString())) { }
            else
                ap.IdRoom2 = Int32.Parse(row["IdRoom2"].ToString());

            ap.IdPrescribingDoctor1 = Int32.Parse(row["IdPrescribingDoctor1"].ToString());

            if (string.IsNullOrEmpty(row["IdPrescribingDoctor2"].ToString())) { }
            else
                ap.IdPrescribingDoctor2 = Int32.Parse(row["IdPrescribingDoctor2"].ToString());

            ap.IdMedicalAct1 = Int32.Parse(row["IdMedicalAct1"].ToString());

            if (string.IsNullOrEmpty(row["IdMedicalAct2"].ToString())) { }
            else
                ap.IdMedicalAct2 = Int32.Parse(row["IdMedicalAct2"].ToString());

            ap.Date = (DateTime)row["Date"];

            ap.Hour1 = (DateTime)row["Hour1"];

            if (string.IsNullOrEmpty(row["Hour2"].ToString())) { }
            else
                ap.Hour2 = (DateTime)row["Hour2"];

            if (string.IsNullOrEmpty(row["Notes"].ToString())) { }
            else
                ap.Notes = (string)row["Notes"];


            if (string.IsNullOrEmpty(row["State"].ToString())) { }
            else
                ap.State = (string)row["State"];



            return ap;

        }
        public static List<Appointment> Gets(DataTable table)
        {
            List<Appointment> list = new List<Appointment>();
            foreach (DataRow row in table.Rows)
                list.Add(Get(row));
            return list;
            

        }
        public static List<Appointment> gets()
        {
            try
            {
                string query = "select *from Appointment; ";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                connection.Close();
                return Gets(table);
            }
            catch
            {
                return null;

            }
        }
        public static List<Appointment> getsBy(string Field ,string Value)
        {
            try
            {
                string query = "select *from Appointment where(@Field=@Value); ";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 50;
                if (string.IsNullOrEmpty(Value)) { command.Parameters.AddWithValue("@Value", DBNull.Value); }
                else { command.Parameters.AddWithValue("@Value",Value); }
                if (string.IsNullOrEmpty(Field)) { command.Parameters.AddWithValue("@Field", DBNull.Value); }
                else { command.Parameters.AddWithValue("@Field", Field); }

                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                connection.Close();
                return Gets(table);
            }
            catch
            {
                return null;

            }
        }

        public static List<Appointment> getsByID ( int IPITENT )
        {
            try
            {
                string query = "select *from Appointment where(IdPatient1=@IPITENT or IdPatient2=@IPITENT);";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 50;
                if (string.IsNullOrEmpty(IPITENT.ToString())) { command.Parameters.AddWithValue("@IPITENT", DBNull.Value); }
                else { command.Parameters.AddWithValue("@IPITENT", IPITENT); }

                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                connection.Close();
                return Gets(table);
            }
            catch
            {
                return null;

            }
        }
        public static List<Rdv_Complet> Rechercheravancer(int IPITENT ,int Room,DateTime jour ,int plage , int Idmedecin,int IdAct  )
        {
            try
            {

                DateTime datDIN = jour.AddDays(-plage);
                DateTime dat = jour.AddDays(plage);
                string query = "select *from Appointment where(IdPatient1=@IPITENT or IdPatient2=@IPITENT or IdRoom1=@Room or IdRoom2=@Room  or IdPrescribingDoctor1=@Idmedecin or IdPrescribingDoctor2=@Idmedecin  or IdMedicalAct1=@IdAct  or IdMedicalAct2=@IdAct  or ( Date between  @dataa and @dat)  );";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 50;
                string t = jour.ToString();
                if (t.Contains("01/01/0001"))
                    command.Parameters.AddWithValue("@dataa", "01-01-2000");
                else
                    command.Parameters.AddWithValue("@dataa", datDIN);
                if (t.Contains("01/01/0001"))
                    command.Parameters.AddWithValue("@dat", "01-01-2000");
                else
                    command.Parameters.AddWithValue("@dat", dat);
                if (Room == 0) { command.Parameters.AddWithValue("@Room", DBNull.Value); }
                else { command.Parameters.AddWithValue("@Room", Room); }


                if (Idmedecin == 0) { command.Parameters.AddWithValue("@Idmedecin", DBNull.Value); }
                else { command.Parameters.AddWithValue("@Idmedecin", Idmedecin); }


                if (IdAct == 0) { command.Parameters.AddWithValue("@IdAct", DBNull.Value); }
                else { command.Parameters.AddWithValue("@IdAct", IdAct); }

                if ((IPITENT==0)) { command.Parameters.AddWithValue("@IPITENT", DBNull.Value); }
                else { command.Parameters.AddWithValue("@IPITENT", IPITENT); }

                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                connection.Close();
                return Rdv_Complet.allRdv(Gets(table));
            }
            catch
            {
                return null;

            }
        }

        public static Appointment GetbyIdappointement ( int Id )
        {
            try
            {
                string query = "select *from Appointment where(Id=@Id);";
                SqlConnection connection = DbConnection.GetConnection();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 50;
                if (string.IsNullOrEmpty(Id.ToString())) { command.Parameters.AddWithValue("@Id", DBNull.Value); }
                else { command.Parameters.AddWithValue("@Id", Id); }

                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                connection.Close();
                return Get(table.Rows[0]);
            }
            catch
            {
                return null;

            }
        }
        public static Message add(Appointment ap)
        {
            try {
                string query = "insert into Appointment(IdPatient1,IdPatient2,IdRoom1,IdRoom2,IdPrescribingDoctor1,IdPrescribingDoctor2,IdMedicalAct1,IdMedicalAct2,Date,Hour1,Hour2,Notes,State)values(@IdPatient1,@IdPatient2,@IdRoom1,@IdRoom2,@IdPrescribingDoctor1,@IdPrescribingDoctor2,@IdMedicalAct1,@IdMedicalAct2,@Date,@Hour1,@Hour2,@Notes,@State);";
                SqlConnection con=DbConnection.GetConnection();
                con.Open();
                SqlCommand cmd=new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(ap.IdPatient1.ToString())) { cmd.Parameters.AddWithValue("@IdPatient1", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdPatient1", ap.IdPatient1); }
                if (string.IsNullOrEmpty(ap.IdPatient2.ToString())) { cmd.Parameters.AddWithValue("@IdPatient2", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdPatient2",ap.IdPatient2 ); }

                if (string.IsNullOrEmpty(ap.IdRoom1.ToString())) { cmd.Parameters.AddWithValue("@IdRoom1", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdRoom1", ap.IdRoom1); }

                if (string.IsNullOrEmpty(ap.IdRoom2.ToString())) { cmd.Parameters.AddWithValue("@IdRoom2", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdRoom2", ap.IdRoom2); }

                if (string.IsNullOrEmpty(ap.IdPrescribingDoctor1.ToString())) { cmd.Parameters.AddWithValue("@IdPrescribingDoctor1", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdPrescribingDoctor1", ap.IdPrescribingDoctor1); }

                if (string.IsNullOrEmpty(ap.IdPrescribingDoctor2.ToString())) { cmd.Parameters.AddWithValue("@IdPrescribingDoctor2", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdPrescribingDoctor2", ap.IdPrescribingDoctor2); }

                if (string.IsNullOrEmpty(ap.IdMedicalAct1.ToString())) { cmd.Parameters.AddWithValue("@IdMedicalAct1", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdMedicalAct1", ap.IdMedicalAct1); }

                if (string.IsNullOrEmpty(ap.IdMedicalAct2.ToString())) { cmd.Parameters.AddWithValue("@IdMedicalAct2", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdMedicalAct2", ap.IdMedicalAct2); }

                if (string.IsNullOrEmpty(ap.Date.ToString())) { cmd.Parameters.AddWithValue("@Date", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@Date", ap.Date); }

                if (string.IsNullOrEmpty(ap.Hour1.ToString())) { cmd.Parameters.AddWithValue("@Hour1", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@Hour1", ap.Hour1); }

                if (string.IsNullOrEmpty(ap.Hour2.ToString())) { cmd.Parameters.AddWithValue("@Hour2", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@Hour2", ap.Hour2); }

                if (string.IsNullOrEmpty(ap.Notes)) { cmd.Parameters.AddWithValue("@Notes", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@Notes", ap.Notes); }

                if (string.IsNullOrEmpty(ap.State.ToString())) { cmd.Parameters.AddWithValue("@State", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@State", ap.State); }
                cmd.ExecuteNonQuery();
                con.Close();
                return new Message(true, "Appointment ajouté");
               

            } catch(Exception e)
            {
                return new Message(false, e.Message);
            }
        }
        public static Message update(Appointment ap)
        {
            try
            {
                string query = "update Appointment set IdPatient1=@IdPatient1,IdPatient2=@IdPatient2,IdRoom1=@IdRoom1,IdRoom2=@IdRoom2,IdPrescribingDoctor1=@IdPrescribingDoctor1,IdPrescribingDoctor2=@IdPrescribingDoctor2,IdMedicalAct1=@IdMedicalAct1,IdMedicalAct2=@IdMedicalAct2,Date=@Date,Hour1=@Hour1,Hour2=@Hour2,Notes=@Notes,State=@State where(Id=@Id);";
                SqlConnection con = DbConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandTimeout = 50;
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(ap.IdPatient1.ToString())) { cmd.Parameters.AddWithValue("@IdPatient1", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdPatient1", ap.IdPatient1); }
                if (string.IsNullOrEmpty(ap.IdPatient2.ToString())) { cmd.Parameters.AddWithValue("@IdPatient2", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdPatient2", ap.IdPatient2); }

                if (string.IsNullOrEmpty(ap.IdRoom1.ToString())) { cmd.Parameters.AddWithValue("@IdRoom1", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdRoom1", ap.IdRoom1); }

                if (string.IsNullOrEmpty(ap.IdRoom2.ToString())) { cmd.Parameters.AddWithValue("@IdRoom2", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdRoom2", ap.IdRoom2); }

                if (string.IsNullOrEmpty(ap.IdPrescribingDoctor1.ToString())) { cmd.Parameters.AddWithValue("@IdPrescribingDoctor1", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdPrescribingDoctor1", ap.IdPrescribingDoctor1); }

                if (string.IsNullOrEmpty(ap.IdPrescribingDoctor2.ToString())) { cmd.Parameters.AddWithValue("@IdPrescribingDoctor2", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdPrescribingDoctor2", ap.IdPrescribingDoctor2); }

                if (string.IsNullOrEmpty(ap.IdMedicalAct1.ToString())) { cmd.Parameters.AddWithValue("@IdMedicalAct1", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdMedicalAct1", ap.IdMedicalAct1); }

                if (string.IsNullOrEmpty(ap.IdMedicalAct2.ToString())) { cmd.Parameters.AddWithValue("@IdMedicalAct2", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@IdMedicalAct2", ap.IdMedicalAct2); }

                if (string.IsNullOrEmpty(ap.Date.ToString())) { cmd.Parameters.AddWithValue("@Date", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@Date", ap.Date); }

                if (string.IsNullOrEmpty(ap.Hour1.ToString())) { cmd.Parameters.AddWithValue("@Hour1", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@Hour1", ap.Hour1); }

                if (string.IsNullOrEmpty(ap.Hour2.ToString())) { cmd.Parameters.AddWithValue("@Hour2", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@Hour2", ap.Hour2); }

                if (string.IsNullOrEmpty(ap.Notes)) { cmd.Parameters.AddWithValue("@Notes", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@Notes", ap.Notes); }

                if (string.IsNullOrEmpty(ap.State)) { cmd.Parameters.AddWithValue("@State", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@State", ap.State); }

                if (string.IsNullOrEmpty(ap.Id.ToString())) { cmd.Parameters.AddWithValue("@Id", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@Id", ap.Id); }
                cmd.ExecuteNonQuery();
                con.Close();
                return new Message(true, "Appointment Modifié");


            }
            catch (Exception e)
            {
                return new Message(false, "Appointment non  Modifié :" +e.Message);
            }
        }


        public static Message delete ( int ID  )
        {
            try
            {
                string query = "DELETE  Appointment WHERE(Id=@ID);";
                SqlConnection con = DbConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(ID.ToString())) { cmd.Parameters.AddWithValue("@ID", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@ID", ID); }
                
                cmd.ExecuteNonQuery();
                con.Close();
                return new Message(true, "Rendez vous Supprimer");


            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
        }


        public static Message deletebyidDoctor( int ID )
        {
            try
            {
                string query = "DELETE  Appointment WHERE(IdPrescribingDoctor1=@ID or IdPrescribingDoctor2=@ID );";
                SqlConnection con = DbConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(ID.ToString())) { cmd.Parameters.AddWithValue("@ID", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@ID", ID); }

                cmd.ExecuteNonQuery();
                con.Close();
                return new Message(true, "Rendez vous Supprimer");


            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
        }
        public static Message deletebyidPatients ( int ID )
        {
            try
            {
                string query = "DELETE  Appointment WHERE(IdPatient1=@ID or IdPatient2=@ID );";
                SqlConnection con = DbConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(ID.ToString())) { cmd.Parameters.AddWithValue("@ID", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@ID", ID); }

                cmd.ExecuteNonQuery();
                con.Close();
                return new Message(true, "Rendez vous Supprimer");


            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
        }
        public static Message deletebyidMEdicalACTE(int ID)
        {
            try
            {
                string query = "DELETE  Appointment WHERE(IdMedicalAct1=@ID or IdMedicalAct2=@ID );";
                SqlConnection con = DbConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(ID.ToString())) { cmd.Parameters.AddWithValue("@ID", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@ID", ID); }

                cmd.ExecuteNonQuery();
                con.Close();
                return new Message(true, "Rendez vous Supprimer");


            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
        }

        public static Message deletebyidROMs ( int ID )
        {
            try
            {
                string query = "DELETE  Appointment WHERE(IdRoom1=@ID or IdRoom2=@ID );";
                SqlConnection con = DbConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 50;
                if (string.IsNullOrEmpty(ID.ToString())) { cmd.Parameters.AddWithValue("@ID", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@ID", ID); }

                cmd.ExecuteNonQuery();
                con.Close();
                return new Message(true, "Rendez vous Supprimer");


            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
        }
        /// <summary>
        /// mettre appointement en status terminer 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Message terminer(int Id)
        {

            try
            {
                string query = "update Appointment set State=' TERMINER ' where(Id=@Id);";
                SqlConnection con = DbConnection.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(Id.ToString())) { cmd.Parameters.AddWithValue("@Id", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@Id", Id); }


                cmd.CommandTimeout = 50;
                cmd.ExecuteNonQuery();
                con.Close();
                return new Message(true, "Appointment termineé ");


            }
            catch (Exception e)
            {
                return new Message(false, "Appointment non  Modifié :" + e.Message);
            }

        }






    }

}
