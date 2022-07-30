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
    public class DAL_EnbryonTransfertData
    {

        private static SqlConnection? connection = null;

        public static Message Add(EnbryonTransfertData actData)
        {
            try
            {
                DalMigration.create_table_EnbryonTransfertData();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO EnbryonTransfertData(IdActDataTransfertsEnbryonnaire,Numeroenbryon,Jourtransfert)" +
                    "VALUES(@IdActDataTransfertsEnbryonnaire, @Numeroenbryon, @Jourtransfert );";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdActDataTransfertsEnbryonnaire", actData.IdActDataTransfertsEnbryonnaire);
                CommandHelper.AddParameterValue<int>(command, "@Numeroenbryon", actData.Numeroenbryon);
                CommandHelper.AddParameterValue<string>(command, "@Jourtransfert", actData.Jourtransfert);

                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " EnbryonTransfertData AJOUTER");
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

        public static EnbryonTransfertData Get(DataRow row)
        {
            EnbryonTransfertData act = new EnbryonTransfertData();
            act.IdActDataTransfertsEnbryonnaire = CommandHelper.ReadIdValue(row["IdActDataTransfertsEnbryonnaire"].ToString());
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.Numeroenbryon = CommandHelper.ReadIdValue(row["Numeroenbryon"].ToString());
            act.Jourtransfert = CommandHelper.ReadValue(row["Jourtransfert"].ToString());
          return act;
        }
        public static List<EnbryonTransfertData> Gets(DataTable table)
        {
            List<EnbryonTransfertData> acts = new List<EnbryonTransfertData>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<EnbryonTransfertData> GETS(int Id)
        {
            DalMigration.create_table_EnbryonTransfertData();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from EnbryonTransfertData  where(IdActDataTransfertsEnbryonnaire=@IdActDataTransfertsEnbryonnaire);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdActDataTransfertsEnbryonnaire", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(EnbryonTransfertData actData)
        {
            try
            {
                DalMigration.create_table_EnbryonTransfertData();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE EnbryonTransfertData SET " +
                    "Numeroenbryon= @Numeroenbryon" +
                    ",Jourtransfert=@Jourtransfert  " +

                    "where(IdActDataTransfertsEnbryonnaire=@IdActDataTransfertsEnbryonnaire);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdActDataTransfertsEnbryonnaire", actData.IdActDataTransfertsEnbryonnaire);
                CommandHelper.AddParameterValue<int>(command, "@Numeroenbryon", actData.Numeroenbryon);
                CommandHelper.AddParameterValue<string>(command, "@Jourtransfert", actData.Jourtransfert);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " EnbryonTransfertData MOdifier");
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
