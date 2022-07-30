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
    public class DAL_AntecedentParticulier
    {
        private static SqlConnection? connection = null;
        public static Message Add(AntecedentParticulier antecedent)
        {
            try
            {
                DalMigration.create_table_AntecedentParticulier();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO AntecedentParticulier(IdRenseignementClinique,TypeAntecedent,Medicaux,Chirurgicaux,Familiaux, Gynecologiques,Tabac,Alcool,Autres)VALUES(@IdRenseignementClinique, @TypeAntecedent, @Medicaux, @Chirurgicaux, @Familiaux  , @Gynecologiques, @Tabac, @Alcool, @Autres);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", antecedent.IdRenseignementClinique);
                CommandHelper.AddParameterValue<string>(command, "@TypeAntecedent", antecedent.TypeAntecedent);
                CommandHelper.AddParameterValue<string>(command, "@Medicaux", antecedent.Medicaux);
                CommandHelper.AddParameterValue<string>(command, "@Chirurgicaux", antecedent.Chirurgicaux);
                CommandHelper.AddParameterValue<string>(command, "@Familiaux", antecedent.Familiaux);
                CommandHelper.AddParameterValue<string>(command, "@Gynecologiques", antecedent.Gynecologiques);
                CommandHelper.AddParameterValue<string>(command, "@Tabac", antecedent.Tabac);
                CommandHelper.AddParameterValue<string>(command, "@Alcool", antecedent.Alcool);
                CommandHelper.AddParameterValue<string>(command, "@Autres", antecedent.Autres);

                command.ExecuteNonQuery();
                return new Message(true, "antecedent particulier ajoutée ");
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

        public static AntecedentParticulier Get(DataRow row)
        {
            AntecedentParticulier particulier = new AntecedentParticulier();
            particulier.Id = Int32.Parse(row["Id"].ToString());
            particulier.IdRenseignementClinique = Int32.Parse(row["IdRenseignementClinique"].ToString());
            if (string.IsNullOrEmpty(row["TypeAntecedent"].ToString())) { }
            else
                particulier.TypeAntecedent = CryptageEncryptage.decrypte((string)row["TypeAntecedent"]);

            if (string.IsNullOrEmpty(row["Medicaux"].ToString())) { }
            else
                particulier.Medicaux = CryptageEncryptage.decrypte((string)row["Medicaux"]);


            if (string.IsNullOrEmpty(row["Chirurgicaux"].ToString())) { }
            else
                particulier.Chirurgicaux = CryptageEncryptage.decrypte((string)row["Chirurgicaux"]);

            if (string.IsNullOrEmpty(row["Familiaux"].ToString())) { }
            else
                particulier.Familiaux = CryptageEncryptage.decrypte((string)row["Familiaux"]);

            if (string.IsNullOrEmpty(row["Gynecologiques"].ToString())) { }
            else
                particulier.Gynecologiques = CryptageEncryptage.decrypte((string)row["Gynecologiques"]);

            if (string.IsNullOrEmpty(row["Tabac"].ToString())) { }
            else
                particulier.Tabac = CryptageEncryptage.decrypte((string)row["Tabac"]);

            if (string.IsNullOrEmpty(row["Alcool"].ToString())) { }
            else
                particulier.Alcool = CryptageEncryptage.decrypte((string)row["Alcool"]);

            if (string.IsNullOrEmpty(row["Autres"].ToString())) { }
            else
                particulier.Autres = CryptageEncryptage.decrypte((string)row["Autres"]);


            return particulier;


        }

        public static List<AntecedentParticulier> Gets(DataTable table)
        {
            try
            {
                List<AntecedentParticulier> antecedents = new List<AntecedentParticulier>();
                foreach (DataRow row in table.Rows)
                    antecedents.Add(Get(row));
                return antecedents;
            }
            catch{
                return null;
            }

     

        }
        public static List<AntecedentParticulier> Gets(int IdReneignement)
        {
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from AntecedentParticulier where(IdRenseignementClinique=@IdRenseignementClinique);";

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

        public static AntecedentParticulier GETbyID(int ID)
        {
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from AntecedentParticulier where(Id=@Id);";

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



        public static Message Update (AntecedentParticulier antecedent)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE AntecedentParticulier SET IdRenseignementClinique = @IdRenseignementClinique, TypeAntecedent = @TypeAntecedent," +
                    "Medicaux = @Medicaux, Chirurgicaux = @Chirurgicaux, Familiaux = @Familiaux , Gynecologiques = @Gynecologiques , Tabac = @Tabac, Alcool = @Alcool , Autres = @Autres   WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", antecedent.Id);
                CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", antecedent.IdRenseignementClinique);
                CommandHelper.AddParameterValue<string>(command, "@TypeAntecedent", antecedent.TypeAntecedent);
                CommandHelper.AddParameterValue<string>(command, "@Medicaux", antecedent.Medicaux);
                CommandHelper.AddParameterValue<string>(command, "@Chirurgicaux", antecedent.Chirurgicaux);
                CommandHelper.AddParameterValue<string>(command, "@Familiaux", antecedent.Familiaux);
                CommandHelper.AddParameterValue<string>(command, "@Gynecologiques", antecedent.Gynecologiques);
                CommandHelper.AddParameterValue<string>(command, "@Tabac", antecedent.Tabac);
                CommandHelper.AddParameterValue<string>(command, "@Alcool", antecedent.Alcool);
                CommandHelper.AddParameterValue<string>(command, "@Autres", antecedent.Autres);

                command.ExecuteNonQuery();
                return new Message(true, " AntecedentParticulier modifier avec  Succès");
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

                string query = "Delete  from AntecedentParticulier  WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", Id);


                command.ExecuteNonQuery();
                return new Message(true, " AntecedentParticulier Supprimer avec  Succès");
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
