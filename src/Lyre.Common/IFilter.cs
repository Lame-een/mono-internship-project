using System.Data.SqlClient;

namespace Lyre.Common
{
    public interface IFilter
    {
        string FilterString { get; set; }
        string GetSql();
        void AddParameters(SqlCommand command);
    }
}
