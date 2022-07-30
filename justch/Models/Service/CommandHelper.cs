using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace justch.Models.Service
{
    public static class CommandHelper
    {
        #region Helper methods
        public static void AddParameterValue<T>(SqlCommand command, String parameterName, T value)
        {
            if ((value == null) || ((value is string) && string.IsNullOrEmpty(value.ToString())))
            {
                command.Parameters.AddWithValue(parameterName, DBNull.Value);
                return;
            }

            if (value is string)
            {
                command.Parameters.AddWithValue(parameterName, CryptageEncryptage.Encrypte(value.ToString()));
                return;
            }
            command.Parameters.AddWithValue(parameterName, value);
        }


        public static string ReadValue( string value )
        {
            if ((value == null) || ((value is string) && string.IsNullOrEmpty(value.ToString())))
            {
              
                return "";
            }
            else
            {
                return CryptageEncryptage.decrypte(value.ToString());
                

            }
                
                


        }
        public static Int32 ReadIdValue(string value)
        {
            if ((value == null) || ((value is string) && string.IsNullOrEmpty(value.ToString())))
            {

                return 0;
            }
            else
            {
                return Int32.Parse(value.ToString());


            }




        }



        #endregion
    }
}
