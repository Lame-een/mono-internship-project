using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Lyre.Repository
{
    public static class SqlUtilities
    {
        public static void AddParameterWithNullableValue(SqlCommand command, string parameterName, object value)
        {
            if (value == null)
            {
                command.Parameters.AddWithValue(parameterName, DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue(parameterName, value);
            }
        }
    }
}
