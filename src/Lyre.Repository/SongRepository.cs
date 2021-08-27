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
    public class SongRepository: ISongRepository
    {

        SqlConnection connection = new SqlConnection("");
        public async Task<ISong> GetSong(int id)
        {
            using(connection)
            {
                await connection.OpenAsync();
                string queryString = "SELECT * FROM SONG WHERE SONG_ID = @SongID;";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@SongID", id);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if(reader.HasRows)
                {
                    reader.Read();

                    Song S = new Song
                    {
                        song_id = Convert.ToInt32(reader.GetInt32(0)),
                        name = Convert.ToString(reader.GetString(1)),
                        album_id = Convert.ToInt32(reader.GetInt32(2)),
                        genre_id = Convert.ToInt32(reader.GetInt32(3)),
                        creation_time = Convert.ToDateTime(reader.GetDateTime(4))
                    };

                    connection.Close();

                    return S;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<ISong>> GetAllSongs()
        {
            using (connection)
            {
                await connection.OpenAsync();
                string queryString = "SELECT * FROM SONG;";

                SqlCommand command = new SqlCommand(queryString, connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    List<ISong> songList = new List<ISong>();

                    while (reader.HasRows)
                    {
                        reader.Read();

                        Song S = new Song
                        {
                            song_id = Convert.ToInt32(reader.GetInt32(0)),
                            name = Convert.ToString(reader.GetString(1)),
                            album_id = Convert.ToInt32(reader.GetInt32(2)),
                            genre_id = Convert.ToInt32(reader.GetInt32(3)),
                            creation_time = Convert.ToDateTime(reader.GetDateTime(4))
                        };

                        songList.Add(S);
                    }

                    return songList;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<int> PostSong(ISong S)
        {
            using (connection)
            {
                await connection.OpenAsync();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string queryString = 
                    "INSERT INTO SONG(song_id, name, album_id, genre_id, creation_time) " +
                    "VALUES(@SongID, @SongName, @AlbumID, @GenreID, @CreationTime);";


                adapter.InsertCommand = new SqlCommand(queryString, connection);

                adapter.InsertCommand.Parameters.AddWithValue("@SongID", S.song_id);
                adapter.InsertCommand.Parameters.AddWithValue("@SongName", S.name);
                adapter.InsertCommand.Parameters.AddWithValue("@AlbumID", S.album_id);
                adapter.InsertCommand.Parameters.AddWithValue("@GenreID", S.genre_id);
                adapter.InsertCommand.Parameters.AddWithValue("@CreationTime", S.creation_time);

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

        public async Task<int> PutSong(int id, string name)
        {
            string queryString = "UPDATE SONG SET name = @name "
            + "WHERE song_id = @ID;";

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

        public async Task<int> DeleteSong(ISong S)
        {
            using (connection)
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string queryString = "DELETE SONG WHERE song_id = @SongID";

                adapter.DeleteCommand = connection.CreateCommand();
                adapter.DeleteCommand.CommandText = queryString;
                adapter.DeleteCommand.Parameters.AddWithValue("@SongID", S.song_id);
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
