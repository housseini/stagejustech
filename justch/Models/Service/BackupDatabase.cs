using justch.Models.DAL;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace justch.Models.Service
{
    public class BackupDatabase
    {
        private static SqlConnection? connection = null;

        public static void Backup( )
        {
            try
            {

                string querys = @"DECLARE @name VARCHAR(50) "+
                                " DECLARE @path VARCHAR(256)  " +
                                 " DECLARE @fileName VARCHAR(256) " +
                                 "DECLARE @fileDate VARCHAR(20) " +
                                 "SET @path = 'D:\\' " +
                                 "SELECT @fileDate = CONVERT(VARCHAR(20),GETDATE(),112) + '_' + REPLACE(CONVERT(VARCHAR(20),GETDATE(),108),':','')" +
                                 "DECLARE db_cursor CURSOR READ_ONLY FOR " +
                                 "SELECT name " +
                                 "FROM master.sys.databases " +
                                 "WHERE name NOT IN ('master','model','msdb','tempdb')" +
                                 "AND state = 0 " +
                                 "AND is_in_standby = 0"  +
                                 "OPEN db_cursor " +
                                 "FETCH NEXT FROM db_cursor INTO @name " +
                                 "WHILE @@FETCH_STATUS = 0 " +
                                 "BEGIN " +
                                 " SET @fileName = @path + @name + '_' + @fileDate + '.BAK' " +
                                 "   BACKUP DATABASE @name TO DISK =@fileName  " +
                                 "   FETCH NEXT FROM db_cursor INTO @name  " +
                                 "END " +
                                 "CLOSE db_cursor " +
                                 "DEALLOCATE db_cursor ";










                var formatName = $"Full Backup of JUSTECH";
                var databaseName = $"JUSTECH";
                DalMigration.create_table_ActDataBiopsie();
                connection = DbConnection.GetConnection();
                connection.Open();
                string pacth = @"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL";
                string localDatabasePath = Path.Combine(pacth,"Backup", $"{databaseName}.bak");

                string query = @"BACKUP DATABASE @databaseName  TO DISK = @localDatabasePath WITH FORMAT, NAME = @formatName";

                var command = new SqlCommand(querys, connection);
               
                command.ExecuteNonQuery();
                connection.Close();
              
            }
            catch (Exception e)
            {
                connection.Close();

            }
            finally
            {
                connection.Close();
            }
        }



        public static void Backup(string Name)
        {
            try {

                if (Name.Equals("REGISTRE")) {
                    string querys = @"DECLARE @name VARCHAR(50) " +
                                    " DECLARE @path VARCHAR(256)  " +
                                     " DECLARE @fileName VARCHAR(256) " +
                                     "DECLARE @fileDate VARCHAR(20) " +
                                     "SET @path = 'D:\\' " +
                                     "SELECT @fileDate = CONVERT(VARCHAR(20),GETDATE(),112) + '_' + REPLACE(CONVERT(VARCHAR(20),GETDATE(),108),':','')" +
                                     "DECLARE db_cursor CURSOR READ_ONLY FOR " +
                                     "SELECT name " +
                                     "FROM master.sys.databases " +
                                     "WHERE name NOT IN ('master','model','msdb','tempdb','JUSTECH')" +
                                     "AND state = 0 " +
                                     "AND is_in_standby = 0" +
                                     "OPEN db_cursor " +
                                     "FETCH NEXT FROM db_cursor INTO @name " +
                                     "WHILE @@FETCH_STATUS = 0 " +
                                     "BEGIN " +
                                     " SET @fileName = @path + @name + '_' + @fileDate + '.BAK' " +
                                     "   BACKUP DATABASE @name TO DISK =@fileName  " +
                                     "   FETCH NEXT FROM db_cursor INTO @name  " +
                                     "END " +
                                     "CLOSE db_cursor " +
                                     "DEALLOCATE db_cursor ";










                    var formatName = $"Full Backup of JUSTECH";
                    var databaseName = $"JUSTECH";
                    DalMigration.create_table_ActDataBiopsie();
                    connection = DbConnection.GetConnection();
                    connection.Open();
                    string pacth = @"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL";
                    string localDatabasePath = Path.Combine(pacth, "Backup", $"{databaseName}.bak");

                    string query = @"BACKUP DATABASE @databaseName  TO DISK = @localDatabasePath WITH FORMAT, NAME = @formatName";

                    var command = new SqlCommand(querys, connection);

                    command.ExecuteNonQuery();
                    connection.Close();

                }
                else
                {
                       string querys = @"DECLARE @name VARCHAR(50) " +
                                    " DECLARE @path VARCHAR(256)  " +
                                     " DECLARE @fileName VARCHAR(256) " +
                                     "DECLARE @fileDate VARCHAR(20) " +
                                     "SET @path = 'D:\\' " +
                                     "SELECT @fileDate = CONVERT(VARCHAR(20),GETDATE(),112) + '_' + REPLACE(CONVERT(VARCHAR(20),GETDATE(),108),':','')" +
                                     "DECLARE db_cursor CURSOR READ_ONLY FOR " +
                                     "SELECT name " +
                                     "FROM master.sys.databases " +
                                     "WHERE name NOT IN ('master','model','msdb','tempdb','REGISTRE')" +
                                     "AND state = 0 " +
                                     "AND is_in_standby = 0" +
                                     "OPEN db_cursor " +
                                     "FETCH NEXT FROM db_cursor INTO @name " +
                                     "WHILE @@FETCH_STATUS = 0 " +
                                     "BEGIN " +
                                     " SET @fileName = @path + @name + '_' + @fileDate + '.BAK' " +
                                     "   BACKUP DATABASE @name TO DISK =@fileName  " +
                                     "   FETCH NEXT FROM db_cursor INTO @name  " +
                                     "END " +
                                     "CLOSE db_cursor " +
                                     "DEALLOCATE db_cursor ";










                    var formatName = $"Full Backup of JUSTECH";
                    var databaseName = $"JUSTECH";
                    DalMigration.create_table_ActDataBiopsie();
                    connection = DbConnection.GetConnection();
                    connection.Open();
                    string pacth = @"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL";
                    string localDatabasePath = Path.Combine(pacth, "Backup", $"{databaseName}.bak");

                    string query = @"BACKUP DATABASE @databaseName  TO DISK = @localDatabasePath WITH FORMAT, NAME = @formatName";

                    var command = new SqlCommand(querys, connection);

                    command.ExecuteNonQuery();
                    connection.Close();

                }
              


            }
            catch (Exception e)
            {
                connection.Close();

            }
            finally
            {
                connection.Close();
            }
        }




        public static void Restauration( string name)
        {
            try
            {
              
                DalMigration.create_table_ActDataBiopsie();
                connection = DbConnection.GetConnection();
                connection.Open();
                string pacth = @"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL";
                string localDatabasePath = Path.Combine(pacth, "Backup", $"{name}.bak");

                string query = @"RESTORE  DATABASE @databaseName  FROM = @localDatabasePath WITH ;";

                var command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.Text;
                command.CommandTimeout = 7200;
                command.Parameters.AddWithValue("@databaseName", name);
                command.Parameters.AddWithValue("@localDatabasePath", localDatabasePath);
              
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception e)
            {
                connection.Close();

            }
            finally
            {
                connection.Close();
            }
        }
    }
}
