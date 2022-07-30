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
    public class DAL_ActDataDecoronisation
    {
        private static SqlConnection? connection = null;

        public static Message Add(ActDataDecoronisation actData)
        {
            try
            {
                DalMigration.create_table_ActDataDecoronisation();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO ActDataDecoronisation(IdMedicalRecordAct,IdEnbryologisteDoctor,EmbryologisteDoctorType,Date,Heure,Commentaires)" +
                    "VALUES(@IdMedicalRecordAct, @IdEnbryologisteDoctor, @EmbryologisteDoctorType  , @Date, @Heure,@Commentaires);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@IdEnbryologisteDoctor", actData.IdEnbryologisteDoctor);
                CommandHelper.AddParameterValue<string>(command, "@EmbryologisteDoctorType", actData.EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@Date", actData.Date);
                CommandHelper.AddParameterValue<string>(command, "@Heure", actData.Heure);
                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataDecoronisation AJOUTER");
            }
            catch
            {
                connection.Close();
                return new Message(false, "erreur d Ajout ");


            }
            finally
            {
                connection.Close();
            }
        }

        public static ActDataDecoronisation Get(DataRow row)
        {
            ActDataDecoronisation act = new ActDataDecoronisation();
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.IdMedicalRecordAct = CommandHelper.ReadIdValue(row["IdMedicalRecordAct"].ToString());
            act.IdEnbryologisteDoctor = CommandHelper.ReadIdValue(row["IdEnbryologisteDoctor"].ToString());
            act.Date = CommandHelper.ReadValue(row["Date"].ToString());
            act.Heure = CommandHelper.ReadValue(row["Heure"].ToString());
            act.Commentaires = CommandHelper.ReadValue(row["Commentaires"].ToString());
            act.EmbryologisteDoctorType = CommandHelper.ReadValue(row["EmbryologisteDoctorType"].ToString());
            return act;
        }
        public static List<ActDataDecoronisation> Gets(DataTable table)
        {
            List<ActDataDecoronisation> acts = new List<ActDataDecoronisation>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<ActDataDecoronisation> GETS(int Id)
        {
            DalMigration.create_table_ActDataDecoronisation();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from ActDataDecoronisation  where(IdMedicalRecordAct=@IdMedicalRecordAct);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(ActDataDecoronisation actData)
        {
            try
            {
                DalMigration.create_table_ActDataDecoronisation();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE ActDataDecoronisation SET " +
                    "IdEnbryologisteDoctor= @IdEnbryologisteDoctor" +
                    ",EmbryologisteDoctorType=@EmbryologisteDoctorType ," +
                    "Date=@Date,Heure= @Heure," +
                    "Commentaires=@Commentaires " +
                    "where(IdMedicalRecordAct=@IdMedicalRecordAct);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@IdEnbryologisteDoctor", actData.IdEnbryologisteDoctor);
                CommandHelper.AddParameterValue<string>(command, "@EmbryologisteDoctorType", actData.EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@Date", actData.Date);
                CommandHelper.AddParameterValue<string>(command, "@Heure", actData.Heure);
                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataDecoronisation MOdifier");
            }
            catch (Exception e)
            {
                connection.Close();
                return new Message(false, "erreur de MOdification :  " + e.Message);


            }
            finally
            {
                connection.Close();
            }
        }
    }
}

