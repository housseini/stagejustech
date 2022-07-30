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
    public class DAL_ActDataCongelationOvocyte
    {
        private static SqlConnection? connection = null;

        public static Message Add(ActDataCongelationOvocyte actData)
        {
            try
            {
                DalMigration.create_table_ActDataCongelationOvocyte();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO ActDataCongelationOvocyte(IdMedicalRecordAct,NombreOvocyteCongeles,Commentaires)" +
                    "VALUES(@IdMedicalRecordAct, @NombreOvocyteCongeles, @Commentaires);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@NombreOvocyteCongeles", actData.NombreOvocyteCongeles);

                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataCongelationOvocyte AJOUTER");
            }
            catch(Exception e)
            {
                connection.Close();
                return new Message(false, "erreur d Ajout "+e.Message );


            }
            finally
            {
                connection.Close();
            }
        }

        public static ActDataCongelationOvocyte Get(DataRow row)
        {
            ActDataCongelationOvocyte act = new ActDataCongelationOvocyte();
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.IdMedicalRecordAct = CommandHelper.ReadIdValue(row["IdMedicalRecordAct"].ToString());
            act.NombreOvocyteCongeles = CommandHelper.ReadIdValue(row["NombreOvocyteCongeles"].ToString());
            act.Commentaires = CommandHelper.ReadValue(row["Commentaires"].ToString());
            return act;
        }
        public static List<ActDataCongelationOvocyte> Gets(DataTable table)
        {
            List<ActDataCongelationOvocyte> acts = new List<ActDataCongelationOvocyte>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<ActDataCongelationOvocyte> GETS(int Id)
        {
            DalMigration.create_table_ActDataCongelationOvocyte();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from ActDataCongelationOvocyte  where(IdMedicalRecordAct=@IdMedicalRecordAct);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(ActDataCongelationOvocyte actData)
        {
            try
            {
                DalMigration.create_table_ActDataCongelationOvocyte();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE ActDataCongelationOvocyte SET " +
                    "NombreOvocyteCongeles= @NombreOvocyteCongeles," +

                      "Commentaires=@Commentaires " +
                    "where(IdMedicalRecordAct=@IdMedicalRecordAct);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdMedicalRecordAct", actData.IdMedicalRecordAct);
                CommandHelper.AddParameterValue<int>(command, "@NombreOvocyteCongeles", actData.NombreOvocyteCongeles);
                CommandHelper.AddParameterValue<string>(command, "@Commentaires", actData.Commentaires);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataCongelationOvocyte MOdifier");
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
