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
    public class DAL_CulureOvocyteData
    {
        private static SqlConnection? connection = null;

        public static Message Add(CulureOvocyteData actData)
        {
            try
            {
                DalMigration.create_table_CulureOvocyteData();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO CulureOvocyteData(IdActDataCulture,OvocytesCultureNumeroOvocyte,OvocytesCultureJour,OvocytesCultureGrade)" +
                    "VALUES(@IdActDataCulture, @OvocytesCultureNumeroOvocyte, @OvocytesCultureJour  , @OvocytesCultureGrade);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdActDataCulture", actData.IdActDataCulture);
                CommandHelper.AddParameterValue<int>(command, "@OvocytesCultureNumeroOvocyte", actData.OvocytesCultureNumeroOvocyte);
                CommandHelper.AddParameterValue<int>(command, "@OvocytesCultureJour", actData.OvocytesCultureJour);
                CommandHelper.AddParameterValue<string>(command, "@OvocytesCultureGrade", actData.OvocytesCultureGrade);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " CulureOvocyteData AJOUTER");
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

        public static CulureOvocyteData Get(DataRow row)
        {
            CulureOvocyteData act = new CulureOvocyteData();
            act.IdActDataCulture = CommandHelper.ReadIdValue(row["IdActDataCulture"].ToString());
            act.OvocytesCultureNumeroOvocyte = CommandHelper.ReadIdValue(row["OvocytesCultureNumeroOvocyte"].ToString());
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.OvocytesCultureGrade = CommandHelper.ReadValue(row["OvocytesCultureGrade"].ToString());
            act.OvocytesCultureJour = CommandHelper.ReadIdValue(row["OvocytesCultureJour"].ToString());

            return act;
        }
        public static List<CulureOvocyteData> Gets(DataTable table)
        {
            List<CulureOvocyteData> acts = new List<CulureOvocyteData>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<CulureOvocyteData> GETS(int Id)
        {
            DalMigration.create_table_CulureOvocyteData();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from CulureOvocyteData  where(IdActDataCulture=@IdActDataCulture);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@IdActDataCulture", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(List<int> listenumero,int idactculture,int Jours , string Grade)
        {
            try
            {
                DalMigration.create_table_CulureOvocyteData();
                connection = DbConnection.GetConnection();
                connection.Open();

                foreach (int i in listenumero)
                {

              
                string query = "UPDATE CulureOvocyteData SET " +
                      "OvocytesCultureGrade=@OvocytesCultureGrade  " +
                    "where(IdActDataCulture=@IdActDataCulture AND OvocytesCultureJour=@OvocytesCultureJour AND OvocytesCultureNumeroOvocyte=@OvocytesCultureNumeroOvocyte);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdActDataCulture", idactculture);
                CommandHelper.AddParameterValue<int>(command, "@OvocytesCultureNumeroOvocyte", i);
                CommandHelper.AddParameterValue<int>(command, "@OvocytesCultureJour", Jours);
                CommandHelper.AddParameterValue<string>(command, "@OvocytesCultureGrade", Grade);
                command.ExecuteNonQuery();
              
                }
                connection.Close();
                return new Message(true, " CulureOvocyteData MOdifier");
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
