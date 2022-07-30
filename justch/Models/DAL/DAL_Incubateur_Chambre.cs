using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using justch.Models.ENTITIES;

using justch.Models.Service;

namespace justch.Models.DAL
{
    public class DAL_Incubateur_Chambre
    {
        #region dal Incubateur
        private static SqlConnection? connection = null;
        public static Message Add(Incubateur Incubateur)
        {
            try
            {
                DalMigration.create_table_Incubateur();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO Incubateur(NomIncubateur,NombreChambre)VALUES(@NomIncubateur, @NombreChambre);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@NombreChambre", Incubateur.NombreChambre);
                CommandHelper.AddParameterValue<string>(command, "@NomIncubateur", Incubateur.NomIncubateur);
 
                command.ExecuteNonQuery();
                return new Message(true, " Incubateur ajoutée ");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        public static Incubateur Get(DataRow row)
        {
            try
            {
                Incubateur v = new Incubateur();

                v.Id = Int32.Parse(row["Id"].ToString());
                v.NombreChambre = Int32.Parse(row["NombreChambre"].ToString());
                v.NomIncubateur=CommandHelper.ReadValue((string)row["NomIncubateur"]);
              
                return v;


            }
            catch 
            {
                return null;
            }
        }

        public static List<Incubateur> Gets(DataTable dataTable) 
        {
            try
            {
                List<Incubateur> incubateurs = new List<Incubateur>();

                foreach (DataRow row in dataTable.Rows)
                {
                    incubateurs.Add(Get(row));
                }
                return incubateurs;
            }
            catch
            {
                return null;
            }
        }

        public static List<Incubateur> Gets() 
        {
            try { 
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from Incubateur ;";

            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;
            command.CommandType = CommandType.Text;
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);
            }
            catch 
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = @"select *from Incubateur ;";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;
                command.CommandType = CommandType.Text;
                DataTable table = new DataTable();
                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                connection.Close();
                return Gets(table);

            }


        }

        public static Incubateur Get(int Id)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = @"select *from Incubateur where(Id=@Id) ;";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;
                command.CommandType = CommandType.Text;
                CommandHelper.AddParameterValue<int>(command, "@Id", Id);

                DataTable table = new DataTable();
                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                connection.Close();
                return Get(table.Rows[0]);
            }
            catch
            {
                return null;

            }
            finally
            {
                connection.Close();

            }

        }

        public static Message Update( Incubateur incubateur)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE Incubateur SET NomIncubateur=@NomIncubateur,NombreChambre=@NombreChambre   " +
                    " WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;
                CommandHelper.AddParameterValue<int>(command, "@Id", incubateur.Id);
                CommandHelper.AddParameterValue<string>(command, "@NomIncubateur", incubateur.NomIncubateur);
                CommandHelper.AddParameterValue<int>(command, "@NombreChambre", incubateur.NombreChambre);
                command.ExecuteNonQuery();
                return new Message(true, " Incubateur modifier avec  Succès");
            }
            catch(Exception e)
            {
                return new Message(false, e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static Message Delete(int Id)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "Delete  from Incubateur  WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", Id);


                command.ExecuteNonQuery();
                return new Message(true, " Incubateur Supprimer avec  Succès");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion



        #region  CHAMBRE 

        public static Message Add(Chambre chambre)
        {
            try
            {
                DalMigration.create_table_Chambre();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO Chambre(NomChambre,IdIncubateur)VALUES(@NomIncubateur, @IdIncubateur);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdIncubateur", chambre.IdIncubateur);
                CommandHelper.AddParameterValue<string>(command, "@NomIncubateur", chambre.NomChambre);

                command.ExecuteNonQuery();
                return new Message(true, " chambre ajoutée ");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public static Chambre GetChambre(DataRow raw)
        {
            Chambre chambre1 = new Chambre();
            chambre1.Id=Int32.Parse(raw["Id"].ToString());
            chambre1.IdIncubateur = Int32.Parse(raw["IdIncubateur"].ToString());
            chambre1.NomChambre = CommandHelper.ReadValue(raw["NomChambre"].ToString());
            return chambre1;


        }

        public static List<Chambre> GetsChambre(DataTable dataTable)
        {
            try
            {
                List<Chambre> Chambre = new List<Chambre>();

                foreach (DataRow row in dataTable.Rows)
                {
                    Chambre.Add(GetChambre(row));
                }
                return Chambre;
            }
            catch
            {
                return null;
            }
        }


        public static List<Chambre> GetsChambre()
        {
            try { 
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from Chambre ;";

            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;
            command.CommandType = CommandType.Text;
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return GetsChambre(table);
            }
            catch
            {
                return null;
            }


        }
        public static List<Chambre> GetsChambreByIdncubateur(int IdIncubateur)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = @"select *from Chambre where(IdIncubateur=@IdIncubateur) ;";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;
                command.CommandType = CommandType.Text;
                CommandHelper.AddParameterValue<int>(command, "@IdIncubateur", IdIncubateur);

                DataTable table = new DataTable();
                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                connection.Close();
                return GetsChambre(table);
            }
            catch
            {
                return null;
            }


        }

        public static Chambre GetChambre(int Id)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = @"select *from Chambre where(Id=@Id) ;";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;
                command.CommandType = CommandType.Text;
                CommandHelper.AddParameterValue<int>(command, "@Id", Id);

                DataTable table = new DataTable();
                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                connection.Close();
                return GetChambre(table.Rows[0]);
            }
            catch
            {
                return null;

            }
            finally
            {
                connection.Close();

            }

        }
        public static Message Update(Chambre incubateur)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE Chambre SET NomChambre=@NomChambre,IdIncubateur=@IdIncubateur   " +
                    " WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;
                CommandHelper.AddParameterValue<int>(command, "@Id", incubateur.Id);
                CommandHelper.AddParameterValue<string>(command, "@NomChambre", incubateur.NomChambre);
                CommandHelper.AddParameterValue<int>(command, "@IdIncubateur", incubateur.IdIncubateur);
                command.ExecuteNonQuery();
                return new Message(true, " Chambre modifier avec  Succès");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static Message DeleteChambre(int Id)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "Delete  from Chambre  WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", Id);


                command.ExecuteNonQuery();
                return new Message(true, " Chambre Supprimer avec  Succès");
            }
            catch (Exception e)
            {
                return new Message(false, e.Message);
            }
            finally
            {
                connection.Close();
            }
        }



        #endregion





    }
}
