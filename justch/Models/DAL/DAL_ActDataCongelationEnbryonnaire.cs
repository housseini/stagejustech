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
    public class DAL_ActDataCongelationEnbryonnaire
    {

        private static SqlConnection? connection = null;

        public static Message Add(ActDataCongelationEnbryonnaire actData)
        {
            try
            {
                DalMigration.create_table_ActDataCongelationEnbryonnaire();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO ActDataCongelationEnbryonnaire(IdMedicalRecordAct,NombreEnbryonsCongeles,Commentaires)" +
                    "VALUES(@IdMedicalRecordAct, @NombreEnbryonsCongeles, @Commentaires);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@NombreEnbryonsCongeles", actData.NombreEnbryonsCongeles);

                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataCongelationEnbryonnaire AJOUTER");
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

        public static ActDataCongelationEnbryonnaire Get(DataRow row)
        {
            ActDataCongelationEnbryonnaire act = new ActDataCongelationEnbryonnaire();
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.IdMedicalRecordAct = CommandHelper.ReadIdValue(row["IdMedicalRecordAct"].ToString());
            act.NombreEnbryonsCongeles = CommandHelper.ReadIdValue(row["NombreEnbryonsCongeles"].ToString());
            act.Commentaires = CommandHelper.ReadValue(row["Commentaires"].ToString());
            return act;
        }
        public static List<ActDataCongelationEnbryonnaire> Gets(DataTable table)
        {
            List<ActDataCongelationEnbryonnaire> acts = new List<ActDataCongelationEnbryonnaire>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<ActDataCongelationEnbryonnaire> GETS(int Id)
        {
            DalMigration.create_table_ActDataCongelationEnbryonnaire();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from ActDataCongelationEnbryonnaire  where(IdMedicalRecordAct=@IdMedicalRecordAct);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(ActDataCongelationEnbryonnaire actData)
        {
            try
            {
                DalMigration.create_table_ActDataCongelationEnbryonnaire();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE ActDataCongelationEnbryonnaire SET " +
                    "NombreEnbryonsCongeles= @NombreEnbryonsCongeles," +
                   
                      "Commentaires=@Commentaires " +
                    "where(IdMedicalRecordAct=@IdMedicalRecordAct);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@NombreEnbryonsCongeles", actData.NombreEnbryonsCongeles);
                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataCongelationEnbryonnaire MOdifier");
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
