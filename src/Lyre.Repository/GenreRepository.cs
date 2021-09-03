using Lyre.Common;
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
        public IDatabaseHandler DBHandler { get; set; }
        public GenreRepository(IDatabaseHandler dbHandler)
        {
            DBHandler = dbHandler;
        }

        public async Task<int> PostGenreAsync(IGenre newGenre) 
        {
            try
            {
                using (SqlConnection connection = DBHandler.NewConnection())
                {
                    connection.Open();
                    string queryString = "INSERT INTO genre VALUES (@genreId, @genreName);";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.Add("@genreId", SqlDbType.UniqueIdentifier).Value = newGenre.ID;
                    command.Parameters.Add("@genreName", SqlDbType.VarChar, 128).Value = newGenre.Name;

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = command;
                    return await adapter.InsertCommand.ExecuteNonQueryAsync();
                }
            }
            catch
            {
                return -1;
            }
        }
        public async Task<List<IGenre>> GetAllGenresAsync() 
        {
            using (SqlConnection connection = DBHandler.NewConnection())
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
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM genre WHERE genre_id = @genreID;";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@genreID", id);

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
        public async Task<IGenre> GetGenreByNameAsync(string genreName)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM genre WHERE name = @genreName;";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@genreName", genreName);

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
                using (SqlConnection connection = DBHandler.NewConnection())
                {
                    connection.Open();
                    string queryString = "UPDATE genre SET name = @genreName WHERE genre_id = @genreID;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.Add("@genreID", SqlDbType.UniqueIdentifier).Value = genre.ID;
                    command.Parameters.Add("@genreName", SqlDbType.VarChar, 128).Value = genre.Name;

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.UpdateCommand = command;
                    return await adapter.UpdateCommand.ExecuteNonQueryAsync();
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
                using (SqlConnection connection = DBHandler.NewConnection())
                {
                    connection.Open();
                    string queryString = "DELETE FROM genre WHERE genre_id = @id;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = command;
                    return await adapter.DeleteCommand.ExecuteNonQueryAsync();
                }
            }
            catch
            {
                return -1;
            }
        }
        public async Task<int> DeleteGenreByNameAsync(string genreName)
        {
            try
            {
                using (SqlConnection connection = DBHandler.NewConnection())
                {
                    connection.Open();
                    string queryString = "DELETE FROM genre WHERE name = @genreName;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@genreName", genreName);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = command;
                    return await adapter.DeleteCommand.ExecuteNonQueryAsync();
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}
