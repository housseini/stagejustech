using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using justch.Models.ENTITIES;

using justch.Models.Service;

namespace justch.Models.DAL
{
    public class DAL_STATISTIQUE
    {
        private static SqlConnection? connection = null;

        public static Dictionary<string, int> COUNTGENRE()
        {
            try
            {
                var result = new Dictionary<string, int>();
               
                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "select Gender,COUNT(*) as GenderCount from Patient Group by (Gender);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;

               
                SqlDataReader MyReader = command.ExecuteReader();
                DataTable table = new DataTable();

                if (MyReader.HasRows)
                {
                    while (MyReader.Read())
                    {
                        var columnName = MyReader["Gender"].ToString();
                        columnName = CryptageEncryptage.decrypte(columnName);
                        result.Add(columnName, Convert.ToInt32(MyReader["GenderCount"].ToString()));
                    }
                }

                MyReader.Close();
                return result;
              
            }
            catch 
            {
                connection.Close();
                return null;


            }
            finally
            {
                connection.Close();
            }
        }

        public static Dictionary<string, int> COUNTdossierType()
        {
            try
            {
                var result = new Dictionary<string, int>();

                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "select Type,COUNT(*) as GenderCount from DossierMedical Group by (Type);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;


                SqlDataReader MyReader = command.ExecuteReader();
                DataTable table = new DataTable();

                if (MyReader.HasRows)
                {
                    while (MyReader.Read())
                    {
                        var columnName = MyReader["Type"].ToString();
                       
                        result.Add(columnName, Convert.ToInt32(MyReader["GenderCount"].ToString()));
                    }
                }

                MyReader.Close();
                return result;

            }
            catch
            {
                connection.Close();
                return null;


            }
            finally
            {
                connection.Close();
            }
        }



        public static Dictionary<string, int> COUNTMEDICALRECOREType()
        {
            try
            {
                var result = new Dictionary<string, int>();

                connection = DbConnection.GetConnection();
                connection.Open();

                string query = "select MedicalActType,COUNT(*) as GenderCount from MedicalRecordAct Group by (MedicalActType);";

                var command = new SqlCommand(query, connection);
                command.CommandTimeout = 50;


                SqlDataReader MyReader = command.ExecuteReader();
                DataTable table = new DataTable();

                if (MyReader.HasRows)
                {
                    while (MyReader.Read())
                    {
                        var columnName = MyReader["MedicalActType"].ToString();

                        result.Add(columnName, Convert.ToInt32(MyReader["GenderCount"].ToString()));
                    }
                }

                MyReader.Close();
                return result;

            }
            catch
            {
                connection.Close();
                return null;


            }
            finally
            {
                connection.Close();
            }
        }



    }
}
