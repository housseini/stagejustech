using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace justch.Models.Service
{
    public class Test<T>
    {
        static Dictionary<string, Type> structure = new Dictionary<string, Type>();

        private static void AddParameterValue<TProp>(SqlCommand command, String parameterName, TProp value)
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

        private void InitializeStructure()
        {
            foreach (PropertyInfo property in typeof(T).GetProperties())
                structure.Add(property.Name, property.PropertyType);
        }
        void Add(T entity)
        {
            StringBuilder query = new StringBuilder($"INSERT INTO {nameof(T)}(");
            foreach (var key in structure.Keys)
            {
                if (key == "Id")
                    continue;
                else
                {
                    if (key == structure.Keys.Last())
                        query.Append($"{key}) ");
                    else
                        query.Append($"{key}, ");
                }
            }

            query.Append("VALUES (");
            foreach (var key in structure.Keys)
            {
                if (key == "Id")
                    continue;
                else
                {
                    if (key == structure.Keys.Last())
                        query.Append($"@{key}) ");
                    else
                        query.Append($"@{key}, ");
                }
            }
            /*
            SqlConnection? connection = null;

            SqlCommand command = new SqlCommand(query.ToString(), connection);

            AddParameterValue<Type>(command, "", 1);

            foreach ((var key, var type) in structure)
            {
            }
            */
        }
    }
}
