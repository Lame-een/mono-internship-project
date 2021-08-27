using Lyre.Model;
using Lyre.Model.Common;
using Lyre.Repository.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Repository
{
    public class GenreRepository: IGenreRepository
    {
        public GenreRepository() { }

        public string ConnectionString { get; set; }

        public async Task<int> PostGenreAsync(IGenre newGenre) 
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string queryString = "INSERT INTO genre VALUES (@genreId, @genreName);";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.Add("@genreId", SqlDbType.Int).Value = newGenre.ID;
                    command.Parameters.Add("@genreName", SqlDbType.VarChar, 50).Value = newGenre.Name;

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = command;
                    await adapter.InsertCommand.ExecuteNonQueryAsync();

                    queryString = "SELECT @@ROWCOUNT;";
                    command = new SqlCommand(queryString, connection);

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        int count = reader.GetInt32(0);
                        reader.Close();
                        return count;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }
        public async Task<List<IGenre>> GetAllGenresAsync() 
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string queryString = "SELECT * FROM genre;";
                SqlCommand command = new SqlCommand(queryString, connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    List<IGenre> genreList = new List<IGenre>();
                    while (reader.Read())
                    {
                        IGenre genre = new Genre(reader.GetGuid(0), reader.GetString(1));
                        genreList.Add(genre);
                    }
                    reader.Close();

                    return genreList;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<IGenre> GetGenreByIDAsync(Guid id) 
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string queryString = "SELECT * FROM genre WHERE genre_id = " + id.ToString() + ";";
                SqlCommand command = new SqlCommand(queryString, connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    reader.Read();
                    IGenre genre = new Genre(reader.GetGuid(0), reader.GetString(1));
                    reader.Close();
                    return genre;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<int> PutGenreAsync(IGenre genre)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string queryString = "UPDATE genre SET name = " + genre.Name + " WHERE genre_id = " + genre.ID + ";";

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.UpdateCommand = new SqlCommand(queryString, connection);
                    await adapter.UpdateCommand.ExecuteNonQueryAsync();

                    queryString = "SELECT @@ROWCOUNT;";
                    SqlCommand command = new SqlCommand(queryString, connection);

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        int count = reader.GetInt32(0);
                        reader.Close();
                        return count;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }
        public async Task<int> DeleteGenreByIDAsync(Guid id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string queryString = "DELETE FROM genre WHERE genre_id = " + id.ToString() + ";";

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = connection.CreateCommand();
                    adapter.DeleteCommand.CommandText = queryString;
                    await adapter.DeleteCommand.ExecuteNonQueryAsync();

                    queryString = "SELECT @@ROWCOUNT;";
                    SqlCommand command = new SqlCommand(queryString, connection);

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        int count = reader.GetInt32(0);
                        reader.Close();
                        return count;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}
