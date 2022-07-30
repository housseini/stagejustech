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
    public class DAL_Serologie
    {
        private static SqlConnection? connection = null;
        public static Message Add(Serologie Serologie)
        {
            try
            {
                DalMigration.create_table_Serologie();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO Serologie(IdRenseignementClinique,TypeSerologie,Date,Hiv,Hvb,Hvc, Syphilis,Chlamydia,Mycoplasmes,Autres)VALUES(@IdRenseignementClinique, @TypeSerologie, @Date, @Hiv, @Hvb,@Hvc  , @Syphilis, @Chlamydia, @Mycoplasmes, @Autres);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", Serologie.IdRenseignementClinique);
                CommandHelper.AddParameterValue<string>(command, "@TypeSerologie", Serologie.TypeSerologie);
                CommandHelper.AddParameterValue<string>(command, "@Date", Serologie.Date);
                CommandHelper.AddParameterValue<string>(command, "@Hiv", Serologie.Hiv);
                CommandHelper.AddParameterValue<string>(command, "@Hvb", Serologie.Hvb);
                CommandHelper.AddParameterValue<string>(command, "@Hvc", Serologie.Hvc);

                CommandHelper.AddParameterValue<string>(command, "@Syphilis", Serologie.Syphilis);
                CommandHelper.AddParameterValue<string>(command, "@Chlamydia", Serologie.Chlamydia);
                CommandHelper.AddParameterValue<string>(command, "@Mycoplasmes", Serologie.Mycoplasmes);
                CommandHelper.AddParameterValue<string>(command, "@Autres", Serologie.Autres);

                command.ExecuteNonQuery();
                return new Message(true, "Serologie  ajoutée ");
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

        public static Serologie Get(DataRow row)
        {
            Serologie Serologie = new Serologie();
            Serologie.Id = Int32.Parse(row["Id"].ToString());
            Serologie.IdRenseignementClinique = Int32.Parse(row["IdRenseignementClinique"].ToString());
            if (string.IsNullOrEmpty(row["TypeSerologie"].ToString())) { }
            else
                Serologie.TypeSerologie = CryptageEncryptage.decrypte((string)row["TypeSerologie"]);

            if (string.IsNullOrEmpty(row["Date"].ToString())) { }
            else
                Serologie.Date = CryptageEncryptage.decrypte((string)row["Date"]);


            if (string.IsNullOrEmpty(row["Hiv"].ToString())) { }
            else
                Serologie.Hiv = CryptageEncryptage.decrypte((string)row["Hiv"]);

            if (string.IsNullOrEmpty(row["Hvb"].ToString())) { }
            else
                Serologie.Hvb = CryptageEncryptage.decrypte((string)row["Hvb"]);

            if (string.IsNullOrEmpty(row["Hvc"].ToString())) { }
            else
                Serologie.Hvc = CryptageEncryptage.decrypte((string)row["Hvc"]);

            if (string.IsNullOrEmpty(row["Syphilis"].ToString())) { }
            else
                Serologie.Syphilis = CryptageEncryptage.decrypte((string)row["Syphilis"]);

            if (string.IsNullOrEmpty(row["Chlamydia"].ToString())) { }
            else
                Serologie.Chlamydia = CryptageEncryptage.decrypte((string)row["Chlamydia"]);


            if (string.IsNullOrEmpty(row["Mycoplasmes"].ToString())) { }
            else
                Serologie.Mycoplasmes = CryptageEncryptage.decrypte((string)row["Mycoplasmes"]);



            if (string.IsNullOrEmpty(row["Autres"].ToString())) { }
            else
                Serologie.Autres = CryptageEncryptage.decrypte((string)row["Autres"]);


            return Serologie;


        }


        public static List<Serologie> Gets(DataTable table)
        {
            try
            {
                List<Serologie> Serologies = new List<Serologie>();
                foreach (DataRow row in table.Rows)
                    Serologies.Add(Get(row));
                return Serologies;
            }
            catch
            {
                return null;
            }



        }
        public static List<Serologie> Gets(int IdReneignement)
        {
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from Serologie where(IdRenseignementClinique=@IdRenseignementClinique);";

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

        public static Serologie GETbyID(int ID)
        {
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from Serologie where(Id=@Id);";

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
        public static Message Update(Serologie Serologie)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE Serologie SET IdRenseignementClinique = @IdRenseignementClinique, TypeSerologie = @TypeSerologie," +
                    "Date = @Date, Hiv = @Hiv, Hvb = @Hvb , Hvc = @Hvc , Syphilis = @Syphilis, Chlamydia = @Chlamydia , Autres = @Autres,Mycoplasmes=@Mycoplasmes   WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", Serologie.Id);
                CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", Serologie.IdRenseignementClinique);
                CommandHelper.AddParameterValue<string>(command, "@TypeSerologie", Serologie.TypeSerologie);
                CommandHelper.AddParameterValue<string>(command, "@Date", Serologie.Date);
                CommandHelper.AddParameterValue<string>(command, "@Hiv", Serologie.Hiv);
                CommandHelper.AddParameterValue<string>(command, "@Hvb", Serologie.Hvb);
                CommandHelper.AddParameterValue<string>(command, "@Hvc", Serologie.Hvc);
                CommandHelper.AddParameterValue<string>(command, "@Syphilis", Serologie.Syphilis);
                CommandHelper.AddParameterValue<string>(command, "@Chlamydia", Serologie.Chlamydia);
                CommandHelper.AddParameterValue<string>(command, "@Mycoplasmes", Serologie.Mycoplasmes);
                CommandHelper.AddParameterValue<string>(command, "@Autres", Serologie.Autres);

                command.ExecuteNonQuery();
                return new Message(true, " Serologie modifier avec  Succès");
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
        public static Message Delete(int Id)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "Delete  from Serologie  WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", Id);


                command.ExecuteNonQuery();
                return new Message(true, " Serologie Supprimer avec  Succès");
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
