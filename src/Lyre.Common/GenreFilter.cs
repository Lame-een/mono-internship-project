using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Common
{
    public class GenreFilter: IFilter
    {
        public string FilterString { get; set; }

        public GenreFilter(string filter = null)
        {
            FilterString = filter;
        }
        public string GetSql()
        {
            if(FilterString == null) return "";

            return "WHERE name LIKE @genreName";
        }
        public void AddParameters(SqlCommand command)
        {
            if (FilterString == null) return;

            command.Parameters.AddWithValue("@genreName", "%'" + FilterString + "'%");
        }
    }
}
