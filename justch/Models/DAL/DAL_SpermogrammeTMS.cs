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
    public class DAL_SpermogrammeTMS
    {
        private static SqlConnection? connection = null;
        public static Message Add(SpermogrammeTMS spermogramme)
        {
            try
            {
                DalMigration.create_table_SpermogrammeTMS();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO SpermogrammeTMS(IdRenseignementClinique,Date,Vol,Num,Mobilite, Vita,Ft,Leuco)VALUES(@IdRenseignementClinique, @Date, @Vol, @Num,@Mobilite  , @Vita, @Ft, @Leuco);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", spermogramme.IdRenseignementClinique);
                CommandHelper.AddParameterValue<string>(command, "@Date", spermogramme.Date);
                CommandHelper.AddParameterValue<string>(command, "@Vol", spermogramme.Vol);
                CommandHelper.AddParameterValue<string>(command, "@Num", spermogramme.Num);
                CommandHelper.AddParameterValue<string>(command, "@Mobilite", spermogramme.Mobilite);

                CommandHelper.AddParameterValue<string>(command, "@Vita", spermogramme.Vita);
                CommandHelper.AddParameterValue<string>(command, "@Ft", spermogramme.Ft);
                CommandHelper.AddParameterValue<string>(command, "@Leuco", spermogramme.Leuco);

                command.ExecuteNonQuery();
                return new Message(true, "spermogramme  ajoutée ");
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


        public static SpermogrammeTMS Get(DataRow row)
        {
            SpermogrammeTMS SpermogrammeTMS = new SpermogrammeTMS();
            SpermogrammeTMS.Id = Int32.Parse(row["Id"].ToString());
            SpermogrammeTMS.IdRenseignementClinique = Int32.Parse(row["IdRenseignementClinique"].ToString());
         
            if (string.IsNullOrEmpty(row["Date"].ToString())) { }
            else
                SpermogrammeTMS.Date = CryptageEncryptage.decrypte((string)row["Date"]);


            if (string.IsNullOrEmpty(row["Vol"].ToString())) { }
            else
                SpermogrammeTMS.Vol = CryptageEncryptage.decrypte((string)row["Vol"]);

            if (string.IsNullOrEmpty(row["Num"].ToString())) { }
            else
                SpermogrammeTMS.Num = CryptageEncryptage.decrypte((string)row["Num"]);

            if (string.IsNullOrEmpty(row["Mobilite"].ToString())) { }
            else
                SpermogrammeTMS.Mobilite = CryptageEncryptage.decrypte((string)row["Mobilite"]);

            if (string.IsNullOrEmpty(row["Vita"].ToString())) { }
            else
                SpermogrammeTMS.Vita = CryptageEncryptage.decrypte((string)row["Vita"]);

            if (string.IsNullOrEmpty(row["Ft"].ToString())) { }
            else
                SpermogrammeTMS.Ft = CryptageEncryptage.decrypte((string)row["Ft"]);


            if (string.IsNullOrEmpty(row["Leuco"].ToString())) { }
            else
                SpermogrammeTMS.Leuco = CryptageEncryptage.decrypte((string)row["Leuco"]);

            return SpermogrammeTMS;


        }

        public static List<SpermogrammeTMS> Gets(DataTable table)
        {
            try
            {
                List<SpermogrammeTMS> SpermogrammeTMSs = new List<SpermogrammeTMS>();
                foreach (DataRow row in table.Rows)
                    SpermogrammeTMSs.Add(Get(row));
                return SpermogrammeTMSs;
            }
            catch
            {
                return null;
            }



        }

        public static List<SpermogrammeTMS> Gets(int IdReneignement)
        {
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from SpermogrammeTMS where(IdRenseignementClinique=@IdRenseignementClinique);";

            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;
            command.CommandType = CommandType.Text;
            CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", IdReneignement);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }


        public static SpermogrammeTMS GETbyID(int ID)
        {
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from SpermogrammeTMS where(Id=@Id);";

            var command = new SqlCommand(query, connection);
            command.CommandTimeout = 50;
            command.CommandType = CommandType.Text;
            CommandHelper.AddParameterValue<int>(command, "@Id", ID);
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Get(table.Rows[0]);
        }


        public static Message Delete(int Id)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "Delete  from SpermogrammeTMS  WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", Id);


                command.ExecuteNonQuery();
                return new Message(true, " SpermogrammeTMS Supprimer avec  Succès");
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


        public static Message Update(SpermogrammeTMS spermogramme)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE SpermogrammeTMS SET IdRenseignementClinique = @IdRenseignementClinique," +
                    "Date = @Date, Vol = @Vol, Num = @Num , Mobilite = @Mobilite , Vita = @Vita, Ft = @Ft , Leuco = @Leuco  WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;
                CommandHelper.AddParameterValue<int>(command, "@Id", spermogramme.Id);
                CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", spermogramme.IdRenseignementClinique);
                CommandHelper.AddParameterValue<string>(command, "@Date", spermogramme.Date);
                CommandHelper.AddParameterValue<string>(command, "@Vol", spermogramme.Vol);
                CommandHelper.AddParameterValue<string>(command, "@Num", spermogramme.Num);
                CommandHelper.AddParameterValue<string>(command, "@Mobilite", spermogramme.Mobilite);

                CommandHelper.AddParameterValue<string>(command, "@Vita", spermogramme.Vita);
                CommandHelper.AddParameterValue<string>(command, "@Ft", spermogramme.Ft);
                CommandHelper.AddParameterValue<string>(command, "@Leuco", spermogramme.Leuco);



                command.ExecuteNonQuery();
                return new Message(true, " SpermogrammeTMS modifier avec  Succès");
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

    }
}
