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

        public static Message Add(List<int> listenumero, string jours , int IdActDataTransfertsEnbryonnaire , string glaire)
        {
            try
            {
                DalMigration.create_table_EnbryonTransfertData();
                connection = DbConnection.GetConnection();
                connection.Open();
                foreach (int i in listenumero) {
                    if (Getby(i, IdActDataTransfertsEnbryonnaire) == 0)
                    {
                        connection.Open();
                        string query = "INSERT INTO EnbryonTransfertData(IdActDataTransfertsEnbryonnaire,Numeroenbryon,Jourtransfert,Glaire)" +
                         "VALUES(@IdActDataTransfertsEnbryonnaire, @Numeroenbryon, @Jourtransfert ,@Glaire);";

                        var command = new SqlCommand(query, connection);
                        command.CommandTimeout = 50;

                        CommandHelper.AddParameterValue<int>(command, "@IdActDataTransfertsEnbryonnaire", IdActDataTransfertsEnbryonnaire);
                        CommandHelper.AddParameterValue<int>(command, "@Numeroenbryon", i);
                        CommandHelper.AddParameterValue<string>(command, "@Jourtransfert", jours);
                        CommandHelper.AddParameterValue<string>(command, "@Glaire", glaire);

                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        connection.Open();
                        string query = "update  EnbryonTransfertData set  Jourtransfert=@Jourtransfert,Glaire=@Glaire   " +
                         "where (IdActDataTransfertsEnbryonnaire=@IdActDataTransfertsEnbryonnaire AND Numeroenbryon=@Numeroenbryon);";

                        var command = new SqlCommand(query, connection);
                        command.CommandTimeout = 50;

                        CommandHelper.AddParameterValue<int>(command, "@IdActDataTransfertsEnbryonnaire", IdActDataTransfertsEnbryonnaire);
                        CommandHelper.AddParameterValue<int>(command, "@Numeroenbryon", i);
                        CommandHelper.AddParameterValue<string>(command, "@Jourtransfert", jours);
                        CommandHelper.AddParameterValue<string>(command, "@Glaire", glaire);

                        command.ExecuteNonQuery();

                    }
                }
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


        public static void delete(List<int> listenumero, int IdActDataTransfertsEnbryonnaire)
        {
            try
            {
                DalMigration.create_table_EnbryonTransfertData();
                connection = DbConnection.GetConnection();
                connection.Open();
                foreach (int i in listenumero)
                {
                    string query = "delete FROM EnbryonTransfertData   where (IdActDataTransfertsEnbryonnaire=@IdActDataTransfertsEnbryonnaire AND Numeroenbryon=@Numeroenbryon);";

                    var command = new SqlCommand(query, connection);
                    command.CommandTimeout = 50;

                    CommandHelper.AddParameterValue<int>(command, "@IdActDataTransfertsEnbryonnaire", IdActDataTransfertsEnbryonnaire);
                    CommandHelper.AddParameterValue<int>(command, "@Numeroenbryon", i);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch
            {
                connection.Close();


            }
            finally
            {
                connection.Close();
            }


        }



        public static int Getby(int listenume,int id)
        {
            DalMigration.create_table_EnbryonnaireCongelationData();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from EnbryonTransfertData  where(Numeroenbryon=@NumeroEnbroyon And IdActDataTransfertsEnbryonnaire=@IdActDataTransfertsEnbryonnaire);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@NumeroEnbroyon", listenume);
            CommandHelper.AddParameterValue<int>(command, "@IdActDataTransfertsEnbryonnaire", id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return (table.Rows.Count);
        }
    }
}
