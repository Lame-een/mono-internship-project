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

        public async Task<IUser> SelectAsync(Guid id)
        {
            const string sqlSelect = "SELECT TOP(1) * FROM serveruser WHERE User_ID = @userID";

            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                command.Parameters.AddWithValue("@AlbumID", id);

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
                    //ret = new User(objectBuffer);
                    ret = objectBuffer.Cast<User>().First();
                }
                return ret;
            }
        }

        //public Task<List<IUser>> SelectAsync(Pager pager, Sorter sorter, AlbumFilter filter)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<int> UpdateAsync(Guid id, IUser value)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertAsync(IUser value)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
