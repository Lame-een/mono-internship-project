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
    public class SongRepository: ISongRepository
    {

        protected IDatabaseHandler DBHandler;

        public SongRepository(IDatabaseHandler dbHandler)
        {
            DBHandler = dbHandler;

        }
        public async Task<ISong> GetSong(Guid songGuid)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM SONG WHERE SONG_ID = @SongID;";

                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@SongID", songGuid);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if(reader.HasRows)
                {
                    reader.Read();

                    Song S = new Song
                    {
                        song_id = reader.GetGuid(0),
                        name = Convert.ToString(reader.GetString(1)),
                        album_id = reader.GetGuid(2),
                        genre_id = reader.GetGuid(3),
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
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
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
                            song_id = reader.GetGuid(0),
                            name = Convert.ToString(reader.GetString(1)),
                            album_id = reader.GetGuid(2),
                            genre_id = reader.GetGuid(3),
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
            using(SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string queryString = 
                    "INSERT INTO SONG(song_id, name, album_id, genre_id, creation_time) " +
                    "VALUES(@SongID, @SongName, @AlbumID, @GenreID, @CreationTime);";


                adapter.InsertCommand = new SqlCommand(queryString, connection);


                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@SongID", S.song_id);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@SongName", S.name);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@AlbumID", S.album_id);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@GenreID", S.genre_id);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@CreationTime", S.creation_time);

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

        public async Task<int> PutSong(Guid songGuid, ISong song)
        {
            string queryString = "UPDATE SONG SET name = @name "
            + "WHERE song_id = @ID;";

            using (SqlConnection connection = DBHandler.NewConnection())
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@name", song.name);
                SqlUtilities.AddParameterWithNullableValue(command, "@ID", songGuid);

                try
                {
                    connection.Open();
                    return await command.ExecuteNonQueryAsync();
                }
                catch
                {
                    return -1;
                }
            }
        }

        public async Task<int> DeleteSong(Guid songGuid)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string queryString = "DELETE SONG WHERE song_id = @SongID";

                adapter.DeleteCommand = connection.CreateCommand();
                adapter.DeleteCommand.CommandText = queryString;

                SqlUtilities.AddParameterWithNullableValue(adapter.DeleteCommand, "@SongID", songGuid);

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
