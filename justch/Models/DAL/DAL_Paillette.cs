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
    public class DAL_Paillette
    {

        private static SqlConnection? connection = null;

        public static Message Add(Paillette actData)
        {
            try
            {
                DalMigration.create_table_Paillette();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO Paillette (IdVisotube,Reference,Couleur,Statu,TypeCongelation)" +
                    "VALUES(@IdVisotube,@Reference ,@Couleur, @Statu ,@TypeCongelation );";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdVisotube", actData.IdVisotube);
                CommandHelper.AddParameterValue<string>(command, "@Reference", actData.Reference);
                CommandHelper.AddParameterValue<string>(command, "@Statu", actData.Statu);
                CommandHelper.AddParameterValue<string>(command, "@Couleur", actData.Couleur);
                CommandHelper.AddParameterValue<string>(command, "@TypeCongelation", actData.TypeCongelation);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " Paillette AJOUTER");
            }
            catch (Exception e)
            {
                connection.Close();
                if (e.Message.Contains("Violation of UNIQUE KEY"))
                    return new Message(false, "la Couleur  ou la refernce Entrer exite deja  ");

                return new Message(false, "erreur d Ajout " + e.Message);


            }
            finally
            {
                connection.Close();
            }
        }

        public static Paillette Get(DataRow row)
        {
            Paillette act = new Paillette();
            act.IdVisotube = CommandHelper.ReadIdValue(row["IdVisotube"].ToString());
            act.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            act.Couleur = CommandHelper.ReadValue(row["Couleur"].ToString());
            act.Reference = CommandHelper.ReadValue(row["Reference"].ToString());
            act.TypeCongelation = CommandHelper.ReadValue(row["TypeCongelation"].ToString());
            act.Statu = CommandHelper.ReadValue(row["Statu"].ToString());
            return act;
        }
        public static List<Paillette> Gets(DataTable table)
        {
            List<Paillette> acts = new List<Paillette>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }

        public static List<Paillette> GETS(int Id)
        {
            DalMigration.create_table_Paillette();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from Paillette  where(Id=@Id);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@Id", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static List<Paillette> GETSIdVisotube(int Id)
        {
            DalMigration.create_table_Paillette();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from Paillette  where(IdVisotube=@Id);";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            CommandHelper.AddParameterValue<int>(command, "@Id", Id);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static List<Paillette> GETS()
        {
            DalMigration.create_table_Paillette();

            connection = DbConnection.GetConnection();
            connection.Open();
            string query = "select *from Paillette  ;";
            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;

            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static Message Update(Paillette actData)
        {
            try
            {
                DalMigration.create_table_Paillette();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE Paillette SET " +
                    "IdVisotube= @IdVisotube," +
                    "Reference= @Reference," +
                
                    "TypeCongelation=@TypeCongelation" +
                    ",Couleur=@Couleur ," +
                    "Statu=@Statu    " +

                    "where(Id=@Id);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", actData.Id);
                CommandHelper.AddParameterValue<int>(command, "@IdVisotube", actData.IdVisotube);
                CommandHelper.AddParameterValue<string>(command, "@Reference", actData.Reference);
                CommandHelper.AddParameterValue<string>(command, "@TypeCongelation", actData.TypeCongelation);
                CommandHelper.AddParameterValue<string>(command, "@Statu", actData.Statu);
                CommandHelper.AddParameterValue<string>(command, "@Couleur", actData.Couleur);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " Paillette MOdifier");
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
                DalMigration.create_table_Paillette();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "delete from Paillette where(Id=@Id);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", Id);
                command.ExecuteNonQuery();
                connection.Close();
                return new Message(true, " Paillette supprimer");
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
