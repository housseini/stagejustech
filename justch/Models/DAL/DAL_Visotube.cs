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
    public class DAL_Visotube
    {
        private static SqlConnection? connection = null;

        public static Message Add(Visotube actData)
        {
            try
            {
                DalMigration.create_table_Visotube();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO Visotube (IdCube,NumeroCanister,Couleur,Capacite,NumeroEtage)" +
                    "VALUES(@IdCube,@NumeroCanister ,@Couleur, @Capacite  , @NumeroEtage);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdCube", actData.IdCube);
                CommandHelper.AddParameterValue<int>(command, "@NumeroCanister", actData.NumeroCanister);
                CommandHelper.AddParameterValue<int>(command, "@NumeroEtage", actData.NumeroEtage);
                CommandHelper.AddParameterValue<int>(command, "@Capacite", actData.Capacite);
                CommandHelper.AddParameterValue<string>(command, "@Couleur", actData.Couleur);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " Visotube AJOUTER");
            }
            catch (Exception e)
            {
                connection.Close();
                if (e.Message.Contains("Violation of UNIQUE KEY"))
                    return new Message(false, "le nom  ou la refernce Entrer exite deja  ");

                return new Message(false, "erreur d Ajout " + e.Message);


            }
            finally
            {
                connection.Close();
            }
        }

        public static Visotube Get(DataRow row)
        {
            Visotube act = new Visotube();
            act.IdCube = CommandHelper.ReadIdValue(row["IdCube"].ToString());
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.Couleur = CommandHelper.ReadValue(row["Couleur"].ToString());
            act.NumeroCanister = CommandHelper.ReadIdValue(row["NumeroCanister"].ToString());
            act.NumeroEtage = CommandHelper.ReadIdValue(row["NumeroEtage"].ToString());
            act.Capacite = CommandHelper.ReadIdValue(row["Capacite"].ToString());
            return act;
        }
        public static List<Visotube> Gets(DataTable table)
        {
            List<Visotube> acts = new List<Visotube>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<Visotube> GETS(int Id)
        {
            DalMigration.create_table_Visotube();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from Visotube  where(Id=@Id);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@Id", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static List<Visotube> GETSIdCuve(int Id)
        {
            DalMigration.create_table_Visotube();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from Visotube  where(IdCube=@Id);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@Id", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static List<Visotube> GETS()
        {
            DalMigration.create_table_Visotube();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from Visotube  ;";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(Visotube actData)
        {
            try
            {
                DalMigration.create_table_Visotube();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE Visotube SET " +
                    "IdCube= @IdCube," +
                    "NumeroCanister= @NumeroCanister" +
                    ",NumeroEtage=@NumeroEtage " +
               
                    ",Couleur=@Couleur ," +
                    "Capacite=@Capacite   " +

                    "where(Id=@Id);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", actData.Id);
                CommandHelper.AddParameterValue<int>(command, "@IdCube", actData.IdCube);
                CommandHelper.AddParameterValue<int>(command, "@NumeroCanister", actData.NumeroCanister);
                CommandHelper.AddParameterValue<int>(command, "@NumeroEtage", actData.NumeroEtage);
                CommandHelper.AddParameterValue<int>(command, "@Capacite", actData.Capacite);
                CommandHelper.AddParameterValue<string>(command, "@Couleur", actData.Couleur);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " Visotube MOdifier");
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
                DalMigration.create_table_Visotube();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "delete from Visotube where(Id=@Id);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", Id);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " Visotube supprimer");
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
