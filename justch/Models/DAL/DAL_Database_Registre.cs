using justch.Models.ENTITIES;
using justch.Models.Service;
using System.Data.SqlClient;
using System.IO;
using System;
using System.Data;
using System.Collections.Generic;

namespace justch.Models.DAL
{
    public class DAL_Database_Registre
    {


        private static SqlConnection? connection = null;

        public static Message Add(string Utulisateur_nome,string CAUSEs,string EFFECUTER_PAR)
        {
            try
            {
                BackupDatabase.Backup();
                DalMigration.create_table_Data_Registre();
                connection = DbConnection.GetConnectionForRegistre();
        
                string sourceDirectory = @"D:\";
                var  Files = Directory.EnumerateFiles(sourceDirectory);
                foreach (var file in Files)
                {
                    if (GETS(file).Count==0)
                    {
                        connection.Open();


                        string query = "INSERT INTO Registre(Name,Utulisateur_nome,CAUSEs,EFFECUTER_PAR)" +
                    "VALUES(@Name,@Utulisateur_nome,@CAUSEs,@EFFECUTER_PAR);";

                      var command = new SqlCommand(query, connection);
                         command.CommandTimeout = 50;


                           CommandHelper.AddParameterValue<string>(command, "@Name", file);
                           CommandHelper.AddParameterValue<string>(command, "@Utulisateur_nome", Utulisateur_nome);
                            CommandHelper.AddParameterValue<string>(command, "@CAUSEs", CAUSEs);
                            CommandHelper.AddParameterValue<string>(command, "@EFFECUTER_PAR", EFFECUTER_PAR);
                           command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
               
                return new Message(true, " Database_Registre ENREGISTRE");
            }
            catch (Exception e)
            {


                return new Message(false, " une erreur lors BAckup");

            }
            finally
            {
                connection.Close();
            }
        }
        public static Database_Registre Get(DataRow row)
        {
            Database_Registre registre = new Database_Registre();

            registre.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            registre.Name = CommandHelper.ReadValue (row["Name"].ToString());
            registre.EFFECUTER_PAR = CommandHelper.ReadValue (row["EFFECUTER_PAR"].ToString());
            registre.CAUSEs = CommandHelper.ReadValue (row["CAUSEs"].ToString());
            registre.Utulisateur_nome = CommandHelper.ReadValue (row["Utulisateur_nome"].ToString());
            registre.Add =  (DateTime) (row["Add"]);
            return registre; 

        }
        public static List<Database_Registre> Gets(DataTable table)
        {
            List<Database_Registre> acts = new List<Database_Registre>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }


        public static List<Database_Registre> GETS()
        {
            DalMigration.create_table_Data_Registre();

            connection = DbConnection.GetConnectionForRegistre();
            connection.Open();
            string query = "select *from Registre ORDER BY Id DESC ;";
            var command = new SqlCommand(query, connection);
           
            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static List<Database_Registre> GETS(string name)
        {
            DalMigration.create_table_Data_Registre();

            connection = DbConnection.GetConnectionForRegistre();
            connection.Open();
            string query = "select *from Registre Where(Name=@name)  ;";

            var command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            CommandHelper.AddParameterValue<string>(command, "@name", name);

            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }


        public static Message Add(string Utulisateur_nome, string CAUSEs, string EFFECUTER_PAR,string namedata)
        {
            try
            {
                if (namedata.Equals("Justech DATABASE")) {
                    BackupDatabase.Backup("JUSTECH");
                }
                else
                {
                    BackupDatabase.Backup("REGISTRE");

                }
              
                DalMigration.create_table_Data_Registre();
                connection = DbConnection.GetConnectionForRegistre();

                string sourceDirectory = @"D:\";
                var Files = Directory.EnumerateFiles(sourceDirectory);
                foreach (var file in Files)
                {
                    if (GETS(file).Count == 0)
                    {
                        connection.Open();


                        string query = "INSERT INTO Registre(Name,Utulisateur_nome,CAUSEs,EFFECUTER_PAR)" +
                    "VALUES(@Name,@Utulisateur_nome,@CAUSEs,@EFFECUTER_PAR);";

                        var command = new SqlCommand(query, connection);
                        command.CommandTimeout = 50;


                        CommandHelper.AddParameterValue<string>(command, "@Name", file);
                        CommandHelper.AddParameterValue<string>(command, "@Utulisateur_nome", Utulisateur_nome);
                        CommandHelper.AddParameterValue<string>(command, "@CAUSEs", CAUSEs);
                        CommandHelper.AddParameterValue<string>(command, "@EFFECUTER_PAR", EFFECUTER_PAR);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return new Message(true, " Database_Registre ENREGISTRE");
            }
            catch (Exception e)
            {


                return new Message(false, " une erreur lors BAckup");

            }
            finally
            {
                connection.Close();
            }
        }
    }
}
