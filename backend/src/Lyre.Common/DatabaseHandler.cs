using System.Data.SqlClient;

namespace Lyre.Common
{
    public class DatabaseHandler : IDatabaseHandler
    {
        private const string _connectionString = "Server=tcp:ajanjic-intern.database.windows.net,1433;Initial Catalog=internship_proj-lyre;Persist Security Info=False;User ID=ajanjic;Password=IZwLQysyaSXmxg3QNpeO;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public SqlConnection NewConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
