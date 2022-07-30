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
    public class DAL_DevenirEmbryon
    {
        private static SqlConnection? connection = null;

        public static Message Add(DevenirEmbryon actData)
        {
            try
            {
                DalMigration.create_table_DevenirEmbryon();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO DevenirEmbryon(IdActeDataCulture,NumeroEmbryon,Devenir)" +
                    "VALUES(@IdActDataCulture, @NumeroEmbryon  , @Devenir);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdActDataCulture", actData.IdActDataCulture);
                CommandHelper.AddParameterValue<int>(command, "@NumeroEmbryon", actData.NumeroEmbryon);
                CommandHelper.AddParameterValue<string>(command, "@Devenir", actData.Devenir);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " DevenirEmbryon AJOUTER");
            }
            catch
            {
                connection.Close();
                return new Message(false, "erreur d modofier ");


            }
            finally
            {
                connection.Close();
            }
        }

        public static DevenirEmbryon Get(DataRow row)
        {
            DevenirEmbryon act = new DevenirEmbryon();
            act.IdActDataCulture = CommandHelper.ReadIdValue(row["IdActeDataCulture"].ToString());
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.Devenir = CommandHelper.ReadValue(row["Devenir"].ToString());
            act.NumeroEmbryon = CommandHelper.ReadIdValue(row["NumeroEmbryon"].ToString());

            return act;
        }
        public static List<DevenirEmbryon> Gets(DataTable table)
        {
            List<DevenirEmbryon> acts = new List<DevenirEmbryon>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<DevenirEmbryon> GETS(int Id)
        {
            DalMigration.create_table_DevenirEmbryon();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from DevenirEmbryon  where(IdActeDataCulture=@IdActDataCulture);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdActDataCulture", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(DevenirEmbryon actData)
        {
            try
            {
                DalMigration.create_table_DevenirEmbryon();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE DevenirEmbryon SET " +
                    "NumeroEmbryon= @NumeroEmbryon," +
                      "Devenir=@Devenir  " +
                    "where(IdActeDataCulture=@IdActDataCulture);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdActDataCulture", actData.IdActDataCulture);
                CommandHelper.AddParameterValue<int>(command, "@NumeroEmbryon", actData.NumeroEmbryon);
                CommandHelper.AddParameterValue<string>(command, "@Devenir", actData.Devenir);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " DevenirEmbryon MOdifier");
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
