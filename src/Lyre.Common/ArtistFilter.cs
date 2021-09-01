using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Common
{
    public class ArtistFilter : IFilter
    {
        public string FilterString { get; set; }

        public ArtistFilter(string filter = null)
        {
            FilterString = filter;
        }
        public string GetSql()
        {
            if (FilterString == null) return "";

            return "WHERE name = @artistName";
        }
        public void AddParameters(SqlCommand command)
        {
            if (FilterString == null) return;

            command.Parameters.AddWithValue("@artistName", "%'" + FilterString + "'%");
        }
    }
}
