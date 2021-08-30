using Lyre.Common;
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
        public IDatabaseHandler DBHandler { get; set; }
        public ArtistRepository(IDatabaseHandler dbHandler) 
        {
            DBHandler = dbHandler;
        }

        public async Task<int> PostArtistAsync(IArtist newArtist) 
        {
            try
            {
                using (SqlConnection connection = DBHandler.NewConnection())
                {
                    connection.Open();
                    string queryString = "INSERT INTO artist VALUES (@artistId, @artistName, @artistCreationTime);";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@artistID", newArtist.ID);
                    command.Parameters.AddWithValue("@artistName", newArtist.Name);
                    command.Parameters.AddWithValue("@artistCreationTime", newArtist.CreationTime);

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
        public async Task<List<IArtist>> GetAllArtistsAsync() 
        {
            using (SqlConnection connection = DBHandler.NewConnection())
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
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM artist WHERE artist_id = @artistID;";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@artistID", id);

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
                using (SqlConnection connection = DBHandler.NewConnection())
                {
                    connection.Open();
                    string queryString = "UPDATE artist SET name = @artistName WHERE artist_id = @artistID;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@artistName", artist.Name);
                    command.Parameters.AddWithValue("@artistID", artist.ID);

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
        public async Task<int> DeleteArtistByIDAsync(Guid id)
        {
            try
            {
                using (SqlConnection connection = DBHandler.NewConnection())
                {
                    connection.Open();
                    string queryString = "DELETE FROM artist WHERE artist_id = @artistID;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@artistID", id);

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
