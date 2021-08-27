using System.Data.SqlClient;

namespace Lyre.Common
{
    public interface IDatabaseHandler
    {
        SqlConnection NewConnection();
    }
}
