using Lyre.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Common
{
    public class SongFilter
    {
        public string FilterString { get; set; }

        public SongFilter(string filter = null)
        {
            FilterString = filter;
        }

        public string GetSql()
        {
            if (FilterString == null) return "";

            string ret = " WHERE (name LIKE @QueryString) ";

            return ret;
        }

        public void AddParameters(SqlCommand command)
        {
            if (FilterString == null) return;

            SqlUtilities.AddParameterWithNullableValue(command, "@QueryString", '%' + FilterString + '%');
        }
    }
}
