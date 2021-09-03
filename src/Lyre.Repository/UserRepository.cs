using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Lyre.Repository.Common;
using Lyre.Model;
using Lyre.Model.Common;
using Lyre.Common;

namespace Lyre.Repository
{
    class UserRepository : IUserRepository
    {
        protected IDatabaseHandler DBHandler;

        public UserRepository(IDatabaseHandler dbHandler)
        {
            DBHandler = dbHandler;

        }

        public async Task<List<IUser>> SelectUsersAsync(QueryStringManager qsManager)
        {
            string sqlSelect = "SELECT * FROM serveruser " + qsManager.Filter.GetSql() + qsManager.Sorter.GetSql() + qsManager.Pager.GetSql() + ';';

            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);

                qsManager.Pager.AddParameters(command);
                qsManager.Filter.AddParameters(command);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<IUser> userList = new List<IUser>();

                if (!reader.HasRows)
                {
                    return userList;
                }

                object[] objectBuffer = new object[User.FieldNumber];
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        reader.GetValues(objectBuffer);
                        userList.Add(new User(objectBuffer));
                    }
                    reader.NextResult();
                }
                return userList;
            }
        }

        public async Task<IUser> SelectUserAsync(Guid id)
        {
            const string sqlSelect = "SELECT TOP(1) * FROM serveruser WHERE User_ID = @UserID";

            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                command.Parameters.AddWithValue("@UserID", id);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (!reader.HasRows)
                {
                    return null;
                }

                IUser ret = null;

                object[] objectBuffer = new object[User.FieldNumber];

                if (reader.Read())
                {
                    reader.GetValues(objectBuffer);
                    ret = new User(objectBuffer);
                }
                return ret;
            }
        }

        public async Task<IUser> SelectUserAsync(string name)
        {
            const string sqlSelect = "SELECT TOP(1) * FROM serveruser WHERE lower(Username) = lower(@Username)";

            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                command.Parameters.AddWithValue("@Username", name);

                try
                {

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (!reader.HasRows)
                    {
                        return null;
                    }

                    IUser ret = null;

                    object[] objectBuffer = new object[User.FieldNumber];

                    if (reader.Read())
                    {
                        reader.GetValues(objectBuffer);
                        ret = new User(objectBuffer);
                    }
                    return ret;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<int> UpdateAsync(IUser value)
        {
            const string sqlUpdate = "UPDATE serveruser SET " +
                "user_id = @UserID, username = @Username, hash = @Hash, salt = @Salt, role = @Role, creation_time = @CreationTime " +
                "WHERE user_id = @UserID";

            using (SqlConnection connection = DBHandler.NewConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlUpdate, connection);
                    command.Parameters.AddWithValue("@UserID", value.UserID);
                    command.Parameters.AddWithValue("@Username", value.Username);
                    command.Parameters.AddWithValue("@Hash", value.Hash);
                    command.Parameters.AddWithValue("@Salt", value.Salt);
                    command.Parameters.AddWithValue("@Role", value.Role.ToString());
                    SqlUtilities.AddParameterWithNullableValue(command, "@CreationTime", value.CreationTime);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.UpdateCommand = command;
                    return await adapter.UpdateCommand.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {
                    return -1;
                }

            }
        }

        public async Task<int> InsertAsync(IUser value)
        {

            const string sqlInsert = "INSERT INTO serveruser(user_id, username, hash, salt, role, creation_time) VALUES (@UserID, @Username, @Hash, @Salt, @Role, @CreationTime)";
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlInsert, connection);
                    command.Parameters.AddWithValue("@UserID", value.UserID);
                    command.Parameters.AddWithValue("@Username", value.Username);
                    command.Parameters.AddWithValue("@Hash", value.Hash);
                    command.Parameters.AddWithValue("@Salt", value.Salt);
                    command.Parameters.AddWithValue("@Role", value.Role.ToString());
                    SqlUtilities.AddParameterWithNullableValue(command, "@CreationTime", value.CreationTime);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = command;
                    return await adapter.InsertCommand.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            const string sqlDelete = "DELETE FROM serveruser WHERE user_id = @UserID";


            using (SqlConnection connection = DBHandler.NewConnection())
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlDelete, connection);
                    command.Parameters.AddWithValue("@UserID", id);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = command;
                    return await adapter.DeleteCommand.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
    }
}
