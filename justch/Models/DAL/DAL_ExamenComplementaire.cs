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
    public class DAL_ExamenComplementaire
    {
        private static SqlConnection? connection = null;

        #region Add 
        public static Message Add(ExamenComplementaire examen)
        {
            try
            {
                DalMigration.create_table_ExamenComplementaire();
                 connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO ExamenComplementaire(IdRenseignementClinique,Echo,Hsg,Tpc,Hsg_Hs,Cytogenetique)VALUES(@IdRenseignementClinique, @Echo, @Hsg, @Tpc, @Hsg_Hs, @Cytogenetique);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", examen.IdRenseignementClinique);
                CommandHelper.AddParameterValue<string>(command, "@Echo", examen.Echo);
                CommandHelper.AddParameterValue<string>(command, "@Hsg", examen.Hsg);
                CommandHelper.AddParameterValue<string>(command, "@Hsg_Hs", examen.Hsg_Hs);
                CommandHelper.AddParameterValue<string>(command, "@Tpc", examen.Tpc);
                CommandHelper.AddParameterValue<string>(command, "@Cytogenetique", examen.Cytogenetique);

                command.ExecuteNonQuery();
                return new Message(true, "ExamenComplementaire Anterieur ajoutée ");
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

        #region Gets

        public static ExamenComplementaire Get(DataRow row)
        {
           
            try
            {
                ExamenComplementaire examen = new ExamenComplementaire();
                examen.Id = Int32.Parse(row["Id"].ToString());
                examen.IdRenseignementClinique = Int32.Parse(row["IdRenseignementClinique"].ToString());
                if (string.IsNullOrEmpty((string)row["Echo"])) { }
                else
                    examen.Echo = CryptageEncryptage.decrypte((string)row["Echo"]);

                if (string.IsNullOrEmpty(row["Hsg"].ToString())) { }
                else
                    examen.Hsg = CryptageEncryptage.decrypte((string)row["Hsg"]);
                if (string.IsNullOrEmpty(row["Hsg_Hs"].ToString())) { }
                else
                    examen.Hsg_Hs = CryptageEncryptage.decrypte((string)row["Hsg_Hs"]);
                if (string.IsNullOrEmpty(row["Tpc"].ToString())) { }
                else
                    examen.Tpc = CryptageEncryptage.decrypte((string)row["Tpc"]);
                if (string.IsNullOrEmpty(row["Cytogenetique"].ToString())) { }
                else
                    examen.Cytogenetique = CryptageEncryptage.decrypte((string)row["Cytogenetique"]);



                return examen;

            }
            catch 
            {
             
                return null;
            }

        }

        public static List<ExamenComplementaire> Gets(DataTable data)
        {
            try
            {
                List<ExamenComplementaire> examens = new List<ExamenComplementaire>();
                foreach (DataRow row in data.Rows)
                    examens.Add(Get( row));
                return examens;


            }
            catch
            {

                return null;
            }

        }
        public static List<ExamenComplementaire> Gets(int IdRenseignement)
        {
        
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from ExamenComplementaire where(IdRenseignementClinique=@IdRenseignementClinique);";

            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;
            command.CommandType = CommandType.Text;
            CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", IdRenseignement);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);



        }

        public static ExamenComplementaire GetbyId(int Id)
        {
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from ExamenComplementaire where(Id=@Id);";

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


        #endregion



        #region Update method
        public static Message Update(ExamenComplementaire examen)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE ExamenComplementaire SET IdRenseignementClinique = @IdRenseignementClinique, Echo = @Echo," +
                    "Hsg = @Hsg, Hsg_Hs = @Hsg_Hs, Tpc = @Tpc , Cytogenetique = @Cytogenetique    WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", examen.Id);
                CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", examen.IdRenseignementClinique);
                CommandHelper.AddParameterValue<string>(command, "@Echo", examen.Echo);
                CommandHelper.AddParameterValue<string>(command, "@Hsg", examen.Hsg);
                CommandHelper.AddParameterValue<string>(command, "@Hsg_Hs", examen.Hsg_Hs);
                CommandHelper.AddParameterValue<string>(command, "@Tpc", examen.Tpc);
                CommandHelper.AddParameterValue<string>(command, "@Cytogenetique", examen.Cytogenetique);

                command.ExecuteNonQuery();
                return new Message(true, " ExamenComplementaire modifier avec  Succès");
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

        #region Delete 
        public static Message Delete(int Id)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "Delete  from ExamenComplementaire  WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", Id);


                command.ExecuteNonQuery();
                return new Message(true, " ExamenComplementaire Supprimer avec  Succès");
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
