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
using Lyre.Service.Common;

namespace Lyre.Repository
{
    public class SongRepository : ISongRepository
    {

        protected IDatabaseHandler DBHandler;
        protected ILyricsService Service;

        public SongRepository(IDatabaseHandler dbHandler, ILyricsService service)
        {
            DBHandler = dbHandler;
            Service = service;
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
                else
                {

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
        }

        public async Task<List<ISongComposite>> GetAllCompositeSongs(QueryStringManager qsManager)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();

                string queryString = "SELECT song.name, song.songID, album.name, album.albumID, artist.name, artist.artistID, genre.name, NULL AS [lyrics.lyricsID] FROM SONG " +
                                     "INNER JOIN ALBUM ON (album.albumID = song.albumID) " +
                                     "INNER JOIN ARTIST ON (artist.artistID = album.artistID) " +
                                     "INNER JOIN GENRE ON (genre.genreID = song.genreID) " +
                                     qsManager.Filter.GetSql() +
                                     qsManager.Sorter.GetSql() +
                                     qsManager.Pager.GetSql() + ';';



                SqlCommand command = new SqlCommand(queryString, connection);

                qsManager.Pager.AddParameters(command);
                qsManager.Filter.AddParameters(command);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<ISongComposite> songList = new List<ISongComposite>();

                if (!reader.HasRows)
                {
                    return songList;
                }
                else
                {

                    object[] objectBuffer = new object[SongComposite.FieldNumber];

                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            reader.GetValues(objectBuffer);
                            songList.Add(new SongComposite(objectBuffer));
                        }
                        reader.NextResult();
                    }
                    return songList;
                }
            }
        }

        public async Task<ISongComposite> GetSongComposite(Guid songGuid)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();

                List<ILyrics> lyricsList = await Service.GetLyricsBySongIDAsync(songGuid);

                Guid? lyricsGuid = null;

                foreach (ILyrics L in lyricsList)
                {
                    if (L.Verified == 'Y')
                    {
                        lyricsGuid = L.LyricsID;
                        break;
                    }
                }

                string queryString = "SELECT song.songID, song.name, album.name, genre.name, artist.name, @LyricsID AS [lyrics.lyricsID] FROM SONG " +
                                     "INNER JOIN ALBUM ON (album.albumID = song.albumID) " +
                                     "INNER JOIN ARTIST ON (artist.artistID = album.artistID) " +
                                     "INNER JOIN GENRE ON (genre.genreID = song.genreID) " +
                                     "WHERE SONG.songID = @SongID;";


                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@SongID", songGuid);
                SqlUtilities.AddParameterWithNullableValue(command, "@LyricsID", lyricsGuid);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                SongComposite S;

                if (!reader.HasRows)
                {
                    return null;
                }
                else
                {

                    object[] objectBuffer = new object[SongComposite.FieldNumber];

                    reader.Read();
                    reader.GetValues(objectBuffer);
                    S = new SongComposite(objectBuffer);
                    return S;
                }
            }

        }

        public async Task<ISong> GetSong(Guid songGuid)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM SONG WHERE songID = @SongID;";

                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@SongID", songGuid);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                Song S;

                if (!reader.HasRows)
                {
                    return null;
                }
                else
                {
                    object[] objectBuffer = new object[Song.FieldNumber];
                    reader.Read();
                    reader.GetValues(objectBuffer);
                    S = new Song(objectBuffer);

                    return S;
                }
            }
        }


        public async Task<int> PostSong(ISong S)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
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
