using System;

using System.Collections.Generic;
using System.Data.SqlClient;
namespace justch.Models.DAL
{
    public class DbConnection

    {
        //static string connectionString = @"workstation id=Justech.mssql.somee.com;packet size=4096;user id=bako_SQLLogin_1;pwd=ygocf9gmg7;data source=Justech.mssql.somee.com;persist security info=False;initial catalog=Justech";
        static string connectionString = @"Data Source=DESKTOP-G08J4S7\SQLEXPRESS;Initial Catalog=JUSTECH;Integrated Security=True ;Connection Timeout=120";
        public static SqlConnection GetConnection()
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return cn;
        }

    }
}
