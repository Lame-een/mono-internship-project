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
            string sqlSelect = "SELECT * FROM song " + qsManager.Filter.GetSql() + qsManager.Sorter.GetSql() + qsManager.Pager.GetSql() + ';';

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

        public async Task<ISongComposite> GetSongComposite(Guid songGuid)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                //FIX select song.songID and lyrics.lyricsID as well
                //lyrics.lyricsID should only be selected if it's verified
                string queryString = "SELECT song.name, album.name, genre.name, artist.name FROM SONG " +
                                     "INNER JOIN ALBUM ON (album.albumID = song.albumID) " +
                                     "INNER JOIN ARTIST ON (artist.artistID = album.artistID) " +
                                     "INNER JOIN GENRE ON (genre.genreID = song.genreID) " +
                                     "WHERE SONG.songID = @SongID;";


                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@SongID", songGuid);

                SqlDataReader reader = await command.ExecuteReaderAsync();


                if (reader.HasRows)
                {
                    reader.Read();

                    //FIX use SongComposite(object[]) constructor
                    SongComposite S = new SongComposite
                    {
                        SongName = Convert.ToString(reader.GetString(0)),
                        AlbumName = Convert.ToString(reader.GetString(1)),
                        GenreName = Convert.ToString(reader.GetString(2)),
                        ArtistName = Convert.ToString(reader.GetString(3))
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

                    //FIX use Song(object[]) constructor
                    Song S = new Song
                    {
                        SongID = reader.GetGuid(0),
                        Name = Convert.ToString(reader.GetString(1)),
                        AlbumID = reader.GetGuid(2),
                        GenreID = reader.GetGuid(3),
                        CreationTime = Convert.ToDateTime(reader.GetDateTime(4))
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
                    "INSERT INTO SONG(songID, name, albumID, genreID, creation_time) " +
                    "VALUES(@SongID, @SongName, @AlbumID, @GenreID, @CreationTime);";


                adapter.InsertCommand = new SqlCommand(queryString, connection);


                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@SongID", S.SongID);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@SongName", S.Name);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@AlbumID", S.AlbumID);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@GenreID", S.GenreID);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@CreationTime", S.CreationTime);

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
            string queryString = "UPDATE SONG SET name = @Name, albumID = @AlbumID, genreID = @GenreID"
            + "WHERE songID = @ID;";

            using (SqlConnection connection = DBHandler.NewConnection())
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@ID", songGuid);
                SqlUtilities.AddParameterWithNullableValue(command, "@Name", song.Name);
                SqlUtilities.AddParameterWithNullableValue(command, "@AlbumID", song.AlbumID);
                SqlUtilities.AddParameterWithNullableValue(command, "@GenreID", song.GenreID);

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

                string queryString = "DELETE SONG WHERE songID = @SongID";

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
