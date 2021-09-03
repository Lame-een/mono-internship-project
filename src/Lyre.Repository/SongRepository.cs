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

        public async Task<List<ISong>> GetAllSongs(QueryStringManager qsManager)
        {
            string sqlSelect = "SELECT * FROM song " + qsManager.Filter.GetSql() + qsManager.Sorter.GetSql(typeof(ISong)) + qsManager.Pager.GetSql() + ';';

            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);

                qsManager.Pager.AddParameters(command);
                qsManager.Filter.AddParameters(command);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<ISong> songList = new List<ISong>();

                if (!reader.HasRows)
                {
                    return songList;
                }

                object[] objectBuffer = new object[Song.FieldNumber];
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        reader.GetValues(objectBuffer);
                        songList.Add(new Song(objectBuffer));
                    }
                    reader.NextResult();
                }
                return songList;
            }
        }

        public async Task<ICompositeSongObject> GetSongComposite(Guid songGuid)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT song.name, album.name, genre.name, artist.name FROM SONG " +
                                "INNER JOIN ALBUM USING (album_id) " +
                                "INNER JOIN ARTIST USING (artist_id) " +
                                "INNER JOIN GENRE USING (genre_id) " +
                                "WHERE Song.song_id = @Song_id;";


                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@SongID", songGuid);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    reader.Read();

                    CompositeSongObject S = new CompositeSongObject
                    {
                        song_name = Convert.ToString(reader.GetString(0)),
                        album_name = Convert.ToString(reader.GetString(1)),
                        genre_name = Convert.ToString(reader.GetString(2)),
                        artist_name = Convert.ToString(reader.GetString(3))
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
            string queryString = "UPDATE SONG SET name = @name, album_id = @album_id, genre_id = @genre_id "
            + "WHERE song_id = @ID;";

            using (SqlConnection connection = DBHandler.NewConnection())
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@ID", songGuid);
                SqlUtilities.AddParameterWithNullableValue(command, "@name", song.name);
                SqlUtilities.AddParameterWithNullableValue(command, "@album_id", song.album_id);
                SqlUtilities.AddParameterWithNullableValue(command, "@genre_id", song.genre_id);

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

        public async Task<int> DeleteSongByID(Guid songGuid)
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
