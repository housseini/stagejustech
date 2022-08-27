using System;

using System.Collections.Generic;
using System.Data.SqlClient;
namespace justch.Models.DAL
{
    public class DbConnection

    {
   //    static string connectionString = @"workstation id=Justech.mssql.somee.com;packet size=4096;user id=bako_SQLLogin_1;pwd=ygocf9gmg7;data source=Justech.mssql.somee.com;persist security info=False;initial catalog=Justech";
       static string connectionString = @"Data Source=DESKTOP-JC5UUA5\SQLEXPRESS;Initial Catalog=JUSTECH;Integrated Security=True ;Connection Timeout=120";
        static string connectionStringFORregistre = @"Data Source=DESKTOP-JC5UUA5\SQLEXPRESS;Initial Catalog=REGISTRE;Integrated Security=True ;Connection Timeout=120";
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
        public static SqlConnection GetConnectionForRegistre()
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(connectionStringFORregistre);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return cn;
        }


    }
}
