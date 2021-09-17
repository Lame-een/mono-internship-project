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
                    command.Parameters.AddWithValue("@artistID", newArtist.ArtistID);
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

        public async Task<List<IArtistComposite>> GetArtistComposite(Guid artistGuid)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT Album.name, Album.albumID FROM ARTIST " +
                    "INNER JOIN ALBUM ON (Album.ArtistID = Artist.ArtistID) " +
                    "WHERE Artist.ArtistID = @ArtistID;";

                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@ArtistID", artistGuid);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<IArtistComposite> compositeList = new List<IArtistComposite>();

                if (!reader.HasRows)
                {
                    return compositeList;
                }
                else
                {

                    object[] objectBuffer = new object[ArtistComposite.FieldNumber];

                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            reader.GetValues(objectBuffer);
                            ArtistComposite artistComposite = new ArtistComposite();
                            artistComposite.AlbumName = (string)objectBuffer[0];
                            artistComposite.AlbumID = (Guid)objectBuffer[1];
                            compositeList.Add(artistComposite);
                        }
                        reader.NextResult();
                    }
                    return compositeList;
                }
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

        public async Task<List<IArtist>> GetAllArtistsAsync(QueryStringManager qsManager)
        {
            string sqlSelect = "SELECT * FROM artist " + qsManager.Filter.GetSql() + qsManager.Sorter.GetSql() + qsManager.Pager.GetSql() + ';';

            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);

                qsManager.Pager.AddParameters(command);
                qsManager.Filter.AddParameters(command);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<IArtist> artistList = new List<IArtist>();

                if (!reader.HasRows)
                {
                    return artistList;
                }

                object[] objectBuffer = new object[Artist.FieldNumber];
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        reader.GetValues(objectBuffer);
                        artistList.Add(new Artist(objectBuffer));
                    }
                    reader.NextResult();
                }
                return artistList;
            }
        }

        public async Task<IArtist> GetArtistByIDAsync(Guid id) 
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM artist WHERE artistID = @artistID;";
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
                    string queryString = "UPDATE artist SET name = @artistName WHERE artistID = @artistID;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@artistName", artist.Name);
                    command.Parameters.AddWithValue("@artistID", artist.ArtistID);

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
                    string queryString = "DELETE FROM artist WHERE artistID = @artistID;";

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
