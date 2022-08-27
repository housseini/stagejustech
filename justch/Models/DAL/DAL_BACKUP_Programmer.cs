using justch.Models.ENTITIES;
using justch.Models.Service;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System;

namespace justch.Models.DAL
{
    public class DAL_BACKUP_Programmer
    {


        private static SqlConnection? connection = null;

        public static Message Add(BACKUP_Programmer bACKUP_Programmer)
        {
            try
            {
               
                DalMigration.create_table_Data_BACKUP_Programmer();
                connection = DbConnection.GetConnectionForRegistre();

                connection.Open();

                        string query = "INSERT INTO BACKUP_Programmer(Name,Date,Heure)" +
                       "VALUES(@Name,@Date,@Heure);";

                        var command = new SqlCommand(query, connection);
                        command.CommandTimeout = 50;


                        CommandHelper.AddParameterValue<string>(command, "@Name", bACKUP_Programmer.Name);
                        CommandHelper.AddParameterValue<string>(command, "@Date", bACKUP_Programmer.Date);
                        CommandHelper.AddParameterValue<string>(command, "@Heure", bACKUP_Programmer.Heure);
                        command.ExecuteNonQuery();
                   
                    connection.Close();
               

                return new Message(true, "  BACKUP_Programmer ENREGISTRE");
            }
            catch (Exception e)
            {


                return new Message(false, " une erreur lors de la Progammation ");

            }
            finally
            {
                connection.Close();
            }
        }


        public static BACKUP_Programmer Get(DataRow row)
        {
            BACKUP_Programmer registre = new BACKUP_Programmer();

            registre.Id = CommandHelper.ReadIdValue(row["Id"].ToString());
            registre.Name = CommandHelper.ReadValue(row["Name"].ToString());
            registre.Heure = CommandHelper.ReadValue(row["Heure"].ToString());
            registre.Date = CommandHelper.ReadValue(row["Date"].ToString());
            registre.Add = (DateTime)(row["Add"]);
            return registre;

        }
        public static List<BACKUP_Programmer> Gets(DataTable table)
        {
            List<BACKUP_Programmer> acts = new List<BACKUP_Programmer>();

            foreach (DataRow Row in table.Rows)
            {
                acts.Add(Get(Row));
            }

            return acts;
        }


        public static List<BACKUP_Programmer> GETS()
        {
            DalMigration.create_table_Data_Registre();

            connection = DbConnection.GetConnectionForRegistre();
            connection.Open();
            string query = "select *from BACKUP_Programmer ORDER BY Id DESC ;";
            var command = new SqlCommand(query, connection);

            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }
        public static List<BACKUP_Programmer> GETS( int Id )
        {
            DalMigration.create_table_Data_Registre();

            connection = DbConnection.GetConnectionForRegistre();
            connection.Open();
            string query = "select *from Registre Where(Id=@Id)  ;";

            var command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            CommandHelper.AddParameterValue<int>(command, "@Id", Id);

            DataTable table = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            connection.Close();
            return Gets(table);

        }


    }
}
