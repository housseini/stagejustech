using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using justch.Models.ENTITIES;

using justch.Models.Service;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace justch.Models.DAL
{
    public class DAL_Cuve
    {
        private static SqlConnection? connection = null;

        public static Message Add(Cuve actData)
        {
            try
            {
                DalMigration.create_table_Cuve();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO Cuve (Nom,Reference,NombreCanisters)" +
                    "VALUES(@Nom, @Reference  , @NombreCanisters);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@NombreCanisters", actData.NombreCanisters);
                CommandHelper.AddParameterValue<string>(command, "@Nom", actData.Nom);
                CommandHelper.AddParameterValue<string>(command, "@Reference", actData.Reference);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " Cuve AJOUTER");
            }
            catch (Exception e)
{
connection.Close();
                if(e.Message.Contains("Violation of UNIQUE KEY"))
                    return new Message(false, "le nom  ou la refernce Entrer exite deja  " );

                return new Message(false, "erreur d Ajout " + e.Message);


            }
            finally
            {
                connection.Close();
            }
        }

        public static Cuve Get(DataRow row)
        {
            Cuve act = new Cuve();
            act.NombreCanisters = CommandHelper.ReadIdValue(row["NombreCanisters"].ToString());
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.Reference = CommandHelper.ReadValue(row["Reference"].ToString());
            act.Nom = CommandHelper.ReadValue(row["Nom"].ToString());
           return act;
        }
        public static List<Cuve> Gets(DataTable table)
        {
            List<Cuve> acts = new List<Cuve>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<Cuve> GETS(int Id)
        {
            DalMigration.create_table_Cuve();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from Cuve  where(Id=@Id);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@Id", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static List<Cuve> GETS()
        {
            DalMigration.create_table_Cuve();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from Cuve  ;";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(Cuve actData)
        {
            try
            {
                DalMigration.create_table_Cuve();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE Cuve SET " +
                    "Nom= @Nom" +
                    ",Reference=@Reference ," +
                    "NombreCanisters=@NombreCanisters   " +

                    "where(Id=@Id);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@NombreCanisters", actData.NombreCanisters);
                CommandHelper.AddParameterValue<int>(command, "@Id", actData.Id);
                CommandHelper.AddParameterValue<string>(command, "@Nom", actData.Nom);
                CommandHelper.AddParameterValue<string>(command, "@Reference", actData.Reference);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " Cuve MOdifier");
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
        public static Message delete(int Id)
        {
            try
            {
                DalMigration.create_table_Cuve();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "delete from Cuve where(Id=@Id);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", Id);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " Cuve supprimer");
            }
            catch (Exception e)
            {
                connection.Close();
                return new Message(false, "erreur de suppression :  " + e.Message);


            }
            finally
            {
                connection.Close();
            }
        }
    }
}
