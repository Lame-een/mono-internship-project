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
    public class AlbumRepository: IAlbumRepository
    {
        SqlConnection connection = new SqlConnection("");
        public async Task<IAlbum> GetAlbum(int id)
        {
            using (connection)
            {
                await connection.OpenAsync();
                string queryString = "SELECT * FROM ALBUM WHERE ALBUM_ID = @AlbumID;";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@AlbumID", id);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    reader.Read();

                    Album A = new Album
                    {
                        album_id = Convert.ToInt32(reader.GetInt32(0)),
                        name = Convert.ToString(reader.GetString(1)),
                        number_of_tracks = Convert.ToInt32(reader.GetInt32(2)),
                        year = Convert.ToInt32(reader.GetInt32(3)),
                        cover = Convert.ToString(reader.GetString(4)),
                        artist_id = Convert.ToInt32(reader.GetInt32(5)),
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

        public async Task<List<IAlbum>> GetAllAlbums()
        {
            using (connection)
            {
                await connection.OpenAsync();
                string queryString = "SELECT * FROM ALBUM;";

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
                            album_id = Convert.ToInt32(reader.GetInt32(0)),
                            name = Convert.ToString(reader.GetString(1)),
                            number_of_tracks = Convert.ToInt32(reader.GetInt32(2)),
                            year = Convert.ToInt32(reader.GetInt32(3)),
                            cover = Convert.ToString(reader.GetString(4)),
                            artist_id = Convert.ToInt32(reader.GetInt32(5)),
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
            using (connection)
            {
                await connection.OpenAsync();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string queryString =
                    "INSERT INTO ALBUM(album_id, name, number_of_tracks, year, cover, artist_id, creation_time) " +
                    "VALUES(@AlbumID, @Name, @NumberOfTracks, @Year, @Cover, @ArtistID, @CreationTime);";


                adapter.InsertCommand = new SqlCommand(queryString, connection);

                adapter.InsertCommand.Parameters.AddWithValue("@AlbumID", A.album_id);
                adapter.InsertCommand.Parameters.AddWithValue("@Name", A.name);
                adapter.InsertCommand.Parameters.AddWithValue("@NumberOfTracks", A.number_of_tracks);
                adapter.InsertCommand.Parameters.AddWithValue("@Year", A.year);
                adapter.InsertCommand.Parameters.AddWithValue("@Cover", A.cover);
                adapter.InsertCommand.Parameters.AddWithValue("@ArtistID", A.artist_id);
                adapter.InsertCommand.Parameters.AddWithValue("@CreationTime", A.creation_time);

                try
                {
                    int rowsAffected = await adapter.InsertCommand.ExecuteNonQueryAsync();
                    connection.Close();
                    return rowsAffected;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public async Task<int> PutAlbum(int id, string name)
        {
            string queryString = "UPDATE ALBUM SET name = @name "
            + "WHERE album_id = @ID;";

            using (connection)
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = id;


                command.Parameters.AddWithValue("@name", name);

                try
                {
                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public async Task<int> DeleteAlbum(IAlbum A)
        {
            using (connection)
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string queryString = "DELETE ALBUM WHERE album_id = @ALbumID";

                adapter.DeleteCommand = connection.CreateCommand();
                adapter.DeleteCommand.CommandText = queryString;
                adapter.DeleteCommand.Parameters.AddWithValue("@ALbumID", A.album_id);
                try
                {
                    int affectedRows = await adapter.DeleteCommand.ExecuteNonQueryAsync();
                    connection.Close();

                    return affectedRows;
                }
                catch
                {
                    return -1;
                }
            }
        }
    }
}
