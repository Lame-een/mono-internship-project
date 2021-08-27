using Lyre.Model;
using Lyre.Model.Common;
using Lyre.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Repository
{
    public class ArtistRepository: IArtistRepository
    {
        public ArtistRepository() { }

        public string ConnectionString { get; set; }

        public async Task<int> PostArtistAsync(IArtist newArtist) 
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string queryString = "INSERT INTO artist VALUES (@artistId, @artistName, @artistCreationTime);";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.Add("@artistId", SqlDbType.Int).Value = newArtist.ID;
                    command.Parameters.Add("@artistName", SqlDbType.VarChar, 50).Value = newArtist.Name;
                    command.Parameters.Add("@artistId", SqlDbType.Timestamp).Value = newArtist.CreationTime;

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
        public async Task<List<IArtist>> GetAllArtistsAsync() 
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string queryString = "SELECT * FROM artist;";
                SqlCommand command = new SqlCommand(queryString, connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    List<IArtist> artistsList = new List<IArtist>();
                    while (reader.Read())
                    {
                        IArtist artist = new Artist(reader.GetGuid(0), reader.GetString(1), reader.GetDateTime(2));
                        artistsList.Add(artist);
                    }
                    reader.Close();

                    return artistsList;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<IArtist> GetArtistByIDAsync(Guid id) 
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string queryString = "SELECT * FROM artist WHERE artist_id = " + id.ToString() + ";";
                SqlCommand command = new SqlCommand(queryString, connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    reader.Read();
                    IArtist artist = new Artist(reader.GetGuid(0), reader.GetString(1), reader.GetDateTime(2));
                    reader.Close();
                    return artist;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<int> PutArtistAsync(IArtist artist) 
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string queryString = "UPDATE artist SET name = " + artist.Name + "WHERE genre_id = " + artist.ID + ";";

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
        public async Task<int> DeleteArtistByIDAsync(Guid id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string queryString = "DELETE FROM artist WHERE genre_id = " + id.ToString() + ";";

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
