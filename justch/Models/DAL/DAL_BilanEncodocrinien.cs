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
    public class DAL_BilanEncodocrinien
    {
        private static SqlConnection? connection = null;
        public static Message Add(BilanEndocrinien bilan)
        {
            try
            {
                DalMigration.create_table_BilanEncodocrinien();
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "INSERT INTO BilanEncodocrinien(IdRenseignementClinique,Type,Date,Fsh,Lh,Prolactine, Tsh,E2,Progesterone,Autres,Amh,Testosterone)VALUES(@IdRenseignementClinique, @Type, @Date, @Fsh, @Lh,@Prolactine  , @Tsh, @E2, @Progesterone, @Autres,@Amh,@Testosterone);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", bilan.IdRenseignementClinique);
                CommandHelper.AddParameterValue<string>(command, "@Type", bilan.Type);
                CommandHelper.AddParameterValue<string>(command, "@Date", bilan.Date);
                CommandHelper.AddParameterValue<string>(command, "@Fsh", bilan.Fsh);
                CommandHelper.AddParameterValue<string>(command, "@Lh", bilan.Lh);
                CommandHelper.AddParameterValue<string>(command, "@Prolactine", bilan.Prolactine);

                CommandHelper.AddParameterValue<string>(command, "@Tsh", bilan.Tsh);
                CommandHelper.AddParameterValue<string>(command, "@E2", bilan.E2);
                CommandHelper.AddParameterValue<string>(command, "@Progesterone", bilan.Progesterone);
                CommandHelper.AddParameterValue<string>(command, "@Autres", bilan.Autres);
                CommandHelper.AddParameterValue<string>(command, "@Amh", bilan.Amh);
                CommandHelper.AddParameterValue<string>(command, "@Testosterone", bilan.Testosterone);



                command.ExecuteNonQuery();
                return new Message(true, "bilan  ajoutée ");
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

        public static BilanEndocrinien Get(DataRow row)
        {
            BilanEndocrinien BilanEndocrinien = new BilanEndocrinien();
            BilanEndocrinien.Id = Int32.Parse(row["Id"].ToString());
            BilanEndocrinien.IdRenseignementClinique = Int32.Parse(row["IdRenseignementClinique"].ToString());
            if (string.IsNullOrEmpty(row["Type"].ToString())) { }
            else
                BilanEndocrinien.Type = CryptageEncryptage.decrypte((string)row["Type"]);

            if (string.IsNullOrEmpty(row["Date"].ToString())) { }
            else
                BilanEndocrinien.Date = CryptageEncryptage.decrypte((string)row["Date"]);


            if (string.IsNullOrEmpty(row["Fsh"].ToString())) { }
            else
                BilanEndocrinien.Fsh = CryptageEncryptage.decrypte((string)row["Fsh"]);

            if (string.IsNullOrEmpty(row["Lh"].ToString())) { }
            else
                BilanEndocrinien.Lh = CryptageEncryptage.decrypte((string)row["Lh"]);

            if (string.IsNullOrEmpty(row["Prolactine"].ToString())) { }
            else
                BilanEndocrinien.Prolactine = CryptageEncryptage.decrypte((string)row["Prolactine"]);

            if (string.IsNullOrEmpty(row["Tsh"].ToString())) { }
            else
                BilanEndocrinien.Tsh = CryptageEncryptage.decrypte((string)row["Tsh"]);

            if (string.IsNullOrEmpty(row["E2"].ToString())) { }
            else
                BilanEndocrinien.E2 = CryptageEncryptage.decrypte((string)row["E2"]);


            if (string.IsNullOrEmpty(row["Progesterone"].ToString())) { }
            else
                BilanEndocrinien.Progesterone = CryptageEncryptage.decrypte((string)row["Progesterone"]);



            if (string.IsNullOrEmpty(row["Autres"].ToString())) { }
            else
                BilanEndocrinien.Autres = CryptageEncryptage.decrypte((string)row["Autres"]);

            if (string.IsNullOrEmpty(row["Amh"].ToString())) { }
            else
                BilanEndocrinien.Amh = CryptageEncryptage.decrypte((string)row["Amh"]);



            if (string.IsNullOrEmpty(row["Testosterone"].ToString())) { }
            else
                BilanEndocrinien.Testosterone = CryptageEncryptage.decrypte((string)row["Testosterone"]);




            return BilanEndocrinien;


        }

        public static List<BilanEndocrinien> Gets(DataTable table)
        {
            try
            {
                List<BilanEndocrinien> BilanEndocriniens = new List<BilanEndocrinien>();
                foreach (DataRow row in table.Rows)
                    BilanEndocriniens.Add(Get(row));
                return BilanEndocriniens;
            }
            catch
            {
                return null;
            }



        }
        public static List<BilanEndocrinien> Gets(int IdReneignement)
        {
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from BilanEncodocrinien where(IdRenseignementClinique=@IdRenseignementClinique);";

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

        public static BilanEndocrinien GETbyID(int ID)
        {
            connection = DbConnection.GetConnection();
            connection.Open();

            string query = @"select *from BilanEncodocrinien where(Id=@Id);";

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

        public static Message Update(BilanEndocrinien bilan)
        {
            try
            {
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "UPDATE BilanEncodocrinien SET IdRenseignementClinique = @IdRenseignementClinique, Type= @Type," +
                    "Date = @Date, Fsh = @Fsh, Lh = @Lh , Prolactine = @Prolactine , Tsh = @Tsh, E2 = @E2 , Autres = @Autres,Progesterone=@Progesterone,Amh=@Amh,Testosterone=@Testosterone   WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@IdRenseignementClinique", bilan.IdRenseignementClinique);
                CommandHelper.AddParameterValue<string>(command, "@Type", bilan.Type);
                CommandHelper.AddParameterValue<string>(command, "@Date", bilan.Date);
                CommandHelper.AddParameterValue<string>(command, "@Fsh", bilan.Fsh);
                CommandHelper.AddParameterValue<string>(command, "@Lh", bilan.Lh);
                CommandHelper.AddParameterValue<string>(command, "@Prolactine", bilan.Prolactine);
                CommandHelper.AddParameterValue<string>(command, "@Tsh", bilan.Tsh);
                CommandHelper.AddParameterValue<string>(command, "@E2", bilan.E2);
                CommandHelper.AddParameterValue<string>(command, "@Progesterone", bilan.Progesterone);
                CommandHelper.AddParameterValue<string>(command, "@Autres", bilan.Autres);
                CommandHelper.AddParameterValue<string>(command, "@Amh", bilan.Amh);
                CommandHelper.AddParameterValue<string>(command, "@Testosterone", bilan.Testosterone);
                CommandHelper.AddParameterValue<int>(command, "@Id", bilan.Id);
                command.ExecuteNonQuery();
                return new Message(true, " BilanEncodocrinien modifier avec  Succès");
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

                string query = "Delete  from BilanEncodocrinien  WHERE Id = @Id";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

                CommandHelper.AddParameterValue<int>(command, "@Id", Id);


                command.ExecuteNonQuery();
                return new Message(true, " BilanEncodocrinien Supprimer avec  Succès");
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
