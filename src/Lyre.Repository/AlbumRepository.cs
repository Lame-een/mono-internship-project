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
using Lyre.Common;

namespace Lyre.Repository
{
    public class AlbumRepository: IAlbumRepository
    {
        protected IDatabaseHandler DBHandler;

        public AlbumRepository(IDatabaseHandler dbHandler)
        {
            DBHandler = dbHandler;
        }

        public async Task<IAlbum> GetAlbum(Guid albumGuid)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM ALBUM WHERE ALBUM_ID = @AlbumID;";

                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@AlbumID", albumGuid);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    reader.Read();

                    Album A = new Album
                    {
                        album_id = reader.GetGuid(0),
                        name = Convert.ToString(reader.GetString(1)),
                        number_of_tracks = Convert.ToInt32(reader.GetInt32(2)),
                        year = Convert.ToInt32(reader.GetInt32(3)),
                        cover = Convert.ToString(reader.GetString(4)),
                        artist_id = reader.GetGuid(5),
                        creation_time = Convert.ToDateTime(reader.GetDateTime(6))
                    };

                    connection.Close();

                    return A;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<IAlbum>> GetAllAlbums(Pager pager, Sorter sorter, AlbumFilter filter)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM ALBUM" + filter.GetSql() + sorter.GetSql(typeof(IAlbum)) + pager.GetSql() + ";";

                SqlCommand command = new SqlCommand(queryString, connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    List<IAlbum> albumList = new List<IAlbum>();

                    while (reader.HasRows)
                    {
                        reader.Read();

                        Album A = new Album
                        {
                            album_id = reader.GetGuid(0),
                            name = Convert.ToString(reader.GetString(1)),
                            number_of_tracks = Convert.ToInt32(reader.GetInt32(2)),
                            year = Convert.ToInt32(reader.GetInt32(3)),
                            cover = Convert.ToString(reader.GetString(4)),
                            artist_id = reader.GetGuid(5),
                            creation_time = Convert.ToDateTime(reader.GetDateTime(6))
                        };

                        albumList.Add(A);
                    }

                    return albumList;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<int> PostAlbum(IAlbum A)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string queryString =
                    "INSERT INTO ALBUM(album_id, name, number_of_tracks, year, cover, artist_id, creation_time) " +
                    "VALUES(@AlbumID, @Name, @NumberOfTracks, @Year, @Cover, @ArtistID, @CreationTime);";


                adapter.InsertCommand = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@AlbumID", A.album_id);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@Name", A.name);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@NumberOfTracks", A.number_of_tracks);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@Year", A.year);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@Cover", A.cover);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@ArtistID", A.artist_id);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@CreationTime", A.creation_time);

                try
                {
                    return await adapter.InsertCommand.ExecuteNonQueryAsync();
                }
                catch
                {
                    return -1;
                }
            }
        }

        public async Task<int> PutAlbum(Guid albumGuid, IAlbum album)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();

                string queryString = "UPDATE ALBUM SET name = @name "
                + "WHERE album_id = @ID;";

                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@ID", albumGuid);
                SqlUtilities.AddParameterWithNullableValue(command, "@name", album.name);

                try
                {
                    return await command.ExecuteNonQueryAsync();
                }
                catch
                {
                    return -1;
                }
            }
        }

        public async Task<int> DeleteAlbumByID(Guid albumGuid)
        {
            using(SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string queryString = "DELETE ALBUM WHERE album_id = @ALbumID";

                adapter.DeleteCommand = connection.CreateCommand();
                adapter.DeleteCommand.CommandText = queryString;
                SqlUtilities.AddParameterWithNullableValue(adapter.DeleteCommand, "@AlbumID", albumGuid);
                try
                {
                    return await adapter.DeleteCommand.ExecuteNonQueryAsync();
                }
                catch
                {
                    return -1;
                }
            }
        }

        public async Task<int> DeleteAlbumByName(string name)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string queryString = "DELETE ALBUM WHERE name = @ALbumName";

                adapter.DeleteCommand = connection.CreateCommand();
                adapter.DeleteCommand.CommandText = queryString;
                SqlUtilities.AddParameterWithNullableValue(adapter.DeleteCommand, "@AlbumName", name);
                try
                {
                    return await adapter.DeleteCommand.ExecuteNonQueryAsync();
                }
                catch
                {
                    return -1;
                }
            }
        }
    }
}
