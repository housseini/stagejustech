using justch.Models.ENTITIES;
using justch.Models.Service;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Models.DAL
{
    public class DAL_TentativeAnterieur
    {
        private static SqlConnection? connection = null;




        #region Add method
        public static Message Add(TentativeAnterieur tentative)
        {
            try
            {
                DalMigration.create_table_TentativeAnterieure();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO TentativeAnterieure(IdRenseignementClinique,Date,Acte,Remarques,Resultats)VALUES(@IdRenseignementClinique, @Date, @Acte, @Remarques, @Resultats);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", tentative.IdRenseignementClinique);
                CommandHelper.AddParameterValue<string>(command, "@Date", tentative.Date);
                CommandHelper.AddParameterValue<string>(command, "@Remarques", tentative.Remarques);
                CommandHelper.AddParameterValue<string>(command, "@Acte", tentative.Acte);
                CommandHelper.AddParameterValue<string>(command, "@Resultats", tentative.Resultats);

                command.ExecuteNonQuery();
                return new Message(true, "Tentative Anterieur ajoutée ");
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


        #region Update method
        public static Message Update(TentativeAnterieur tentative)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE TentativeAnterieure SET IdRenseignementClinique = @IdRenseignementClinique, Date = @Date," +
                    "Acte = @Acte, Remarques = @Remarques, Resultats = @Resultats WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", tentative.Id);
                CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", tentative.IdRenseignementClinique);
                CommandHelper.AddParameterValue<string>(command, "@Date", tentative.Date);
                CommandHelper.AddParameterValue<string>(command, "@Remarques", tentative.Remarques);
                CommandHelper.AddParameterValue<string>(command, "@Acte", tentative.Acte);
                CommandHelper.AddParameterValue<string>(command, "@Resultats", tentative.Resultats);

                command.ExecuteNonQuery();
                return new Message(true, " TentativeAnterieur modifier avec  Succès");
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
        #region Get 
        public static TentativeAnterieur Get(DataRow row)
        {
            try
            {
                TentativeAnterieur tentativeAnterieur = new TentativeAnterieur();
                tentativeAnterieur.Id = Int32.Parse(row["Id"].ToString());
                tentativeAnterieur.IdRenseignementClinique = Int32.Parse(row["IdRenseignementClinique"].ToString());
                if (string.IsNullOrEmpty((string)row["Date"])) { }
                else
                    tentativeAnterieur.Date = CryptageEncryptage.decrypte((string)row["Date"]);

                if (string.IsNullOrEmpty(row["Acte"].ToString())) { }
                else
                    tentativeAnterieur.Acte = CryptageEncryptage.decrypte((string)row["Acte"]);
                if (string.IsNullOrEmpty(row["Remarques"].ToString())) { }
                else
                    tentativeAnterieur.Remarques = CryptageEncryptage.decrypte((string)row["Remarques"]);
                if (string.IsNullOrEmpty(row["Resultats"].ToString())) { }
                else
                    tentativeAnterieur.Resultats = CryptageEncryptage.decrypte((string)row["Resultats"]);



                return tentativeAnterieur;

            }
            catch(Exception e)
            {
                TentativeAnterieur tentativeAnterieur = new TentativeAnterieur();
                tentativeAnterieur.Acte = e.Message;
                return tentativeAnterieur;
            }



        }
        public static TentativeAnterieur GetById(int Id)
        {

            DalMigration.create_table_TentativeAnterieure();
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from TentativeAnterieure where(Id=@Id);";

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


        public static List<TentativeAnterieur> Gets(DataTable dataRow)
        {
            try
            {
                var Listes = new List<TentativeAnterieur>();
                foreach (DataRow row in dataRow.Rows)
                    Listes.Add(Get(row));
                return Listes;
            }
            catch
            {
                return null;
            }
        }

        public static List<TentativeAnterieur> Gets(int IdRenseignement)
        {
            DalMigration.create_table_TentativeAnterieure();
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from TentativeAnterieure where(IdRenseignementClinique=@IdRenseignementClinique);";

            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;
            command.CommandType = CommandType.Text;
            CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique",IdRenseignement);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);



        }
        #endregion

        #region Delete 
        public static Message Delete(int  Id)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "Delete  from TentativeAnterieure  WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", Id);
              

                command.ExecuteNonQuery();
                return new Message(true, " TentativeAnterieur Supprimer avec  Succès");
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
