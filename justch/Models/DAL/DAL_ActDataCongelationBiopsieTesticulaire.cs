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
    public class DAL_ActDataCongelationBiopsieTesticulaire
    {
        private static SqlConnection? connection = null;

        public static Message Add(ActDataCongelationBiopsieTesticulaire actData)
        {
            try
            {
                DalMigration.create_table_ActDataCongelationBiopsieTesticulaire();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO ActDataCongelationBiopsieTesticulaire(IdMedicalRecordAct,IdEnbryologisteDoctor,EmbryologisteDoctorType,Date,Heure,Commentaires,Milieu)" +
                    "VALUES(@IdMedicalRecordAct, @IdEnbryologisteDoctor, @EmbryologisteDoctorType  , @Date, @Heure,@Commentaires,@Milieu);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@IdEnbryologisteDoctor", actData.IdEnbryologisteDoctor);
                CommandHelper.AddParameterValue<string>(command, "@EmbryologisteDoctorType", actData.EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@Date", actData.Date);
                CommandHelper.AddParameterValue<string>(command, "@Heure", actData.Heure);
                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                CommandHelper.AddParameterValue<string>(command, "@Milieu", actData.Milieu);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataCongelationBiopsieTesticulaire AJOUTER");
            }
            catch (Exception e)
            {
                connection.Close();
                return new Message(false, "erreur d Ajout " +e.Message);


            }
            finally
            {
                connection.Close();
            }
        }

        public static ActDataCongelationBiopsieTesticulaire Get(DataRow row)
        {
            ActDataCongelationBiopsieTesticulaire act = new ActDataCongelationBiopsieTesticulaire();
            act.Milieu = CommandHelper.ReadValue(row["Milieu"].ToString());
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.IdMedicalRecordAct = CommandHelper.ReadIdValue(row["IdMedicalRecordAct"].ToString());
            act.IdEnbryologisteDoctor = CommandHelper.ReadIdValue(row["IdEnbryologisteDoctor"].ToString());
            act.Date = CommandHelper.ReadValue(row["Date"].ToString());
            act.Heure = CommandHelper.ReadValue(row["Heure"].ToString());
            act.Commentaires = CommandHelper.ReadValue(row["Commentaires"].ToString());
            act.EmbryologisteDoctorType = CommandHelper.ReadValue(row["EmbryologisteDoctorType"].ToString());
            return act;
        }
        public static List<ActDataCongelationBiopsieTesticulaire> Gets(DataTable table)
        {
            List<ActDataCongelationBiopsieTesticulaire> acts = new List<ActDataCongelationBiopsieTesticulaire>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<ActDataCongelationBiopsieTesticulaire> GETS(int Id)
        {
            DalMigration.create_table_ActDataCongelationBiopsieTesticulaire();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from ActDataCongelationBiopsieTesticulaire  where(IdMedicalRecordAct=@IdMedicalRecordAct);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(ActDataCongelationBiopsieTesticulaire actData)
        {
            try
            {
                DalMigration.create_table_ActDataCongelationBiopsieTesticulaire();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE ActDataCongelationBiopsieTesticulaire SET " +
                    "IdEnbryologisteDoctor= @IdEnbryologisteDoctor" +
                    ",EmbryologisteDoctorType=@EmbryologisteDoctorType ," +
                    "Date=@Date,Heure= @Heure," +
                    "Commentaires=@Commentaires, " +
                      "Milieu=@Milieu " +
                    "where(IdMedicalRecordAct=@IdMedicalRecordAct);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@IdEnbryologisteDoctor", actData.IdEnbryologisteDoctor);
                CommandHelper.AddParameterValue<string>(command, "@EmbryologisteDoctorType", actData.EmbryologisteDoctorType);
                CommandHelper.AddParameterValue<string>(command, "@Date", actData.Date);
                CommandHelper.AddParameterValue<string>(command, "@Heure", actData.Heure);
                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                CommandHelper.AddParameterValue<string>(command, "@Milieu", actData.Milieu);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataCongelationBiopsieTesticulaire MOdifier");
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
