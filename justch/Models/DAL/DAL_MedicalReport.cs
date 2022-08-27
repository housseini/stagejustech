using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.ENTITIES;

using justch.Models.Service;

namespace justch.Models.DAL
{
    public class DAL_MedicalReport
    {
        private static SqlConnection? connection = null;

        public static Message Add(MedicalReport actData)
        {
            try
            {
                DalMigration.create_table_MedicalReport();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO MedicalReport(IdMedicalRecordAct,ReportBody)" +
                    "VALUES( @IdMedicalRecordAct, @ReportBody);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);

                CommandHelper.AddParameterValue<string>(command, "@ReportBody", actData.ReportBody);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " MedicalReport ENREGISTRE");
            }
            catch 
            {

                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "Update  MedicalReport SET ReportBody=@ReportBody   " +
                    "where(IdMedicalRecordAct=@IdMedicalRecordAct);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);

                CommandHelper.AddParameterValue<string>(command, "@ReportBody", actData.ReportBody);
                command.ExecuteNonQuery();
                connection.Close();
             
                return new Message(true, "MedicalReport ENREGISTRE ");


            }
            finally
            {
                connection.Close();
            }
        }

        public static MedicalReport Get(DataRow row)
        {
            MedicalReport act = new MedicalReport();
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.IdMedicalRecordAct = CommandHelper.ReadIdValue(row["IdMedicalRecordAct"].ToString());
            act.ReportBody = CommandHelper.ReadValue(row["ReportBody"].ToString());
            return act;
        }
        public static List<MedicalReport> Gets(DataTable table)
        {
            List<MedicalReport> acts = new List<MedicalReport>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<MedicalReport> GETS(int Id)
        {
            DalMigration.create_table_MedicalReport();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from MedicalReport  where(IdMedicalRecordAct=@IdMedicalRecordAct);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Regernere(int Id)
        {
            DalMigration.create_table_MedicalReport();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "delete  MedicalReport  where(IdMedicalRecordAct=@IdMedicalRecordAct);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return new Message(true, " MedicalReport ENREGISTRE");

        }
        //public static Message Update(ActDataCongelationOvocyte actData)
        //{
        //    try
        //    {
        //        DalMigration.create_table_MedicalReport();
        //        connection = DbConnection.GetConnection();
        //        connection.Open();

        //        string query = "UPDATE ActDataCongelationOvocyte SET " +
        //            "NombreOvocyteCongeles= @NombreOvocyteCongeles," +

        //              "Commentaires=@Commentaires " +
        //            "where(IdMedicalRecordAct=@IdMedicalRecordAct);";

        //        var command = new SqlCommand(query, connection);
        //        command.CommandTimeout = 50;

        //        CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
        //        CommandHelper.AddParameterValue<int>(command, "@NombreOvocyteCongeles", actData.NombreOvocyteCongeles);
        //        CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
        //        command.ExecuteNonQuery();
        //        connection.Close();
        //        return new Message(true, " ActDataCongelationOvocyte MOdifier");
        //    }
        //    catch (Exception e)
        //    {
        //        connection.Close();
        //        return new Message(false, "erreur de MOdification :  " + e.Message);


        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}
    }
}
