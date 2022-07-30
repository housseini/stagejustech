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
    public class DAL_ActDataDecoronisationOvocyteData
    {
        private static SqlConnection? connection = null;

        public static Message Add(ActDataDecoronisationOvocyteData actData)
        {
            try
            {
                DalMigration.create_table_ActDataDecoronisationOvocyteData();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO ActDataDecoronisationOvocyteData(IdActDataDecoronisation,DecoronisationOvocyteNumeroOvocyte,DecoronisationOvocyteEtat,DecoronisationOvocyteCommantaire)" +
                    "VALUES(@IdActDataDecoronisation, @DecoronisationOvocyteNumeroOvocyte, @DecoronisationOvocyteEtat  , @DecoronisationOvocyteCommantaire);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdActDataDecoronisation", actData.IdActDataDecoronisation);
                CommandHelper.AddParameterValue<int>(command, "@DecoronisationOvocyteNumeroOvocyte", actData.DecoronisationOvocyteNumeroOvocyte);
                CommandHelper.AddParameterValue<string>(command, "@DecoronisationOvocyteEtat", actData.DecoronisationOvocyteEtat);
                CommandHelper.AddParameterValue<string>(command, "@DecoronisationOvocyteCommantaire", actData.DecoronisationOvocyteCommantaire);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataDecoronisationOvocyteData AJOUTER");
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

        public static ActDataDecoronisationOvocyteData Get(DataRow row)
        {
            ActDataDecoronisationOvocyteData act = new ActDataDecoronisationOvocyteData();
            act.IdActDataDecoronisation = CommandHelper.ReadIdValue(row["IdActDataDecoronisation"].ToString());
            act.DecoronisationOvocyteNumeroOvocyte = CommandHelper.ReadIdValue(row["DecoronisationOvocyteNumeroOvocyte"].ToString());
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.DecoronisationOvocyteCommantaire = CommandHelper.ReadValue(row["DecoronisationOvocyteCommantaire"].ToString());
            act.DecoronisationOvocyteEtat = CommandHelper.ReadValue(row["DecoronisationOvocyteEtat"].ToString());
            
            return act;
        }
        public static List<ActDataDecoronisationOvocyteData> Gets(DataTable table)
        {
            List<ActDataDecoronisationOvocyteData> acts = new List<ActDataDecoronisationOvocyteData>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<ActDataDecoronisationOvocyteData> GETS(int Id)
        {
            DalMigration.create_table_ActDataDecoronisationOvocyteData();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from ActDataDecoronisationOvocyteData  where(IdActDataDecoronisation=@IdActDataDecoronisation);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdActDataDecoronisation", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(ActDataDecoronisationOvocyteData actData)
        {
            try
            {
                DalMigration.create_table_ActDataDecoronisationOvocyteData();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE ActDataDecoronisationOvocyteData SET " +
                    "DecoronisationOvocyteNumeroOvocyte= @DecoronisationOvocyteNumeroOvocyte," +
                    "DecoronisationOvocyteEtat=@DecoronisationOvocyteEtat, " +
                      "DecoronisationOvocyteCommantaire=@DecoronisationOvocyteCommantaire " +
                    "where(IdActDataDecoronisation=@IdActDataDecoronisation);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdActDataDecoronisation", actData.IdActDataDecoronisation);
                CommandHelper.AddParameterValue<int>(command, "@DecoronisationOvocyteNumeroOvocyte", actData.DecoronisationOvocyteNumeroOvocyte);
                CommandHelper.AddParameterValue<string>(command, "@DecoronisationOvocyteEtat", actData.DecoronisationOvocyteEtat);
                CommandHelper.AddParameterValue<string>(command, "@DecoronisationOvocyteCommantaire", actData.DecoronisationOvocyteCommantaire);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " ActDataDecoronisationOvocyteData MOdifier");
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
