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

        public async Task<List<IAlbum>> GetAllAlbums(QueryStringManager qsManager)
        {
            string sqlSelect = "SELECT * FROM album " + qsManager.Filter.GetSql() + qsManager.Sorter.GetSql() + qsManager.Pager.GetSql() + ';';

            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);

                qsManager.Pager.AddParameters(command);
                qsManager.Filter.AddParameters(command);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<IAlbum> albumList = new List<IAlbum>();

                if (!reader.HasRows)
                {
                    return albumList;
                }

                object[] objectBuffer = new object[Album.FieldNumber];
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        reader.GetValues(objectBuffer);
                        albumList.Add(new Album(objectBuffer));
                    }
                    reader.NextResult();
                }
                return albumList;
            }
        }

        public async Task<IAlbum> GetAlbum(Guid albumGuid)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM ALBUM WHERE albumID = @AlbumID;";

                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@AlbumID", albumGuid);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (!reader.HasRows)
                {
                    return null;
                }

                object[] objectBuffer = new object[Album.FieldNumber];

                reader.Read();

                reader.GetValues(objectBuffer);
                IAlbum album = new Album(objectBuffer);

                return album;
            }
        }

        public async Task<int> PostAlbum(IAlbum A)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string queryString =
                    "INSERT INTO ALBUM(albumID, name, NumberOfTracks, year, cover, artistID, CreationTime) " +
                    "VALUES(@AlbumID, @Name, @NumberOfTracks, @Year, @Cover, @ArtistID, @CreationTime);";


                adapter.InsertCommand = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@AlbumID", A.AlbumID);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@Name", A.Name);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@NumberOfTracks", A.NumberOfTracks);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@Year", A.Year);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@Cover", A.Cover);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@ArtistID", A.ArtistID);
                SqlUtilities.AddParameterWithNullableValue(adapter.InsertCommand, "@CreationTime", A.CreationTime);

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

                string queryString = "UPDATE ALBUM SET name = @name, NumberOfTracks = @number_of_tracks, year = @year, cover = @cover, artistID = @artistID "
                + "WHERE albumID = @ID;";

                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@ID", albumGuid);
                SqlUtilities.AddParameterWithNullableValue(command, "@name", album.Name);
                SqlUtilities.AddParameterWithNullableValue(command, "@number_of_tracks", album.NumberOfTracks);
                SqlUtilities.AddParameterWithNullableValue(command, "@year", album.Year);
                SqlUtilities.AddParameterWithNullableValue(command, "@cover", album.Cover);
                SqlUtilities.AddParameterWithNullableValue(command, "@artistID", album.ArtistID);


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

                string queryString = "DELETE ALBUM WHERE albumID = @AlbumID;";

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

        public async Task<List<IAlbumComposite>> GetSongsInAlbum(QueryStringManager qsManager)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();

                string queryString = "SELECT Album.name, Song.songID, Song.name FROM SONG " +
                                     "INNER JOIN ALBUM ON (album.albumID = song.albumID) " +
                                     qsManager.Filter.GetSql() +
                                     qsManager.Sorter.GetSql() +
                                     qsManager.Pager.GetSql() + ';';


                SqlCommand command = new SqlCommand(queryString, connection);

                qsManager.Pager.AddParameters(command);
                qsManager.Filter.AddParameters(command);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<IAlbumComposite> songList = new List<IAlbumComposite>();

                if (!reader.HasRows)
                {
                    return songList;
                }
                else
                {

                    object[] objectBuffer = new object[AlbumComposite.FieldNumber];

                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            reader.GetValues(objectBuffer);
                            songList.Add(new AlbumComposite(objectBuffer));
                        }
                        reader.NextResult();
                    }
                    return songList;
                }
            }
        }

        public async Task<List<IAlbumComposite>> GetSongsInAlbumByID(Guid albumGuid)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();

                string queryString = "SELECT Album.name, Song.songID, Song.name, Artist.name, Artist.artistID FROM SONG " +
                                     "INNER JOIN ALBUM ON (album.albumID = song.albumID)" +
                                     "INNER JOIN ARTIST ON (album.artistID = artist.artistID) " +
                                     "WHERE Album.AlbumID = @AlbumID";


                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@AlbumID", albumGuid);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<IAlbumComposite> songList = new List<IAlbumComposite>();

                if (!reader.HasRows)
                {
                    return songList;
                }
                else
                {

                    object[] objectBuffer = new object[AlbumComposite.FieldNumber];

                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            reader.GetValues(objectBuffer);
                            songList.Add(new AlbumComposite(objectBuffer));
                        }
                        reader.NextResult();
                    }
                    return songList;
                }
            }
        }

        public async Task<List<IAlbumArtistComposite>> GetAlbumArtistComposite(QueryStringManager qsManager)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();

                string queryString = "SELECT Album.albumID, Album.name, Artist.artistID, Artist.name, Album.Cover FROM ALBUM " +
                                     "INNER JOIN ARTIST ON (album.artistID = artist.artistID) " +
                                     qsManager.Filter.GetSql() +
                                     qsManager.Sorter.GetSql() +
                                     qsManager.Pager.GetSql() + ';';


                SqlCommand command = new SqlCommand(queryString, connection);

                qsManager.Pager.AddParameters(command);
                qsManager.Filter.AddParameters(command);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<IAlbumArtistComposite> compositeList = new List<IAlbumArtistComposite>();

                if (!reader.HasRows)
                {
                    return compositeList;
                }
                else
                {

                    object[] objectBuffer = new object[AlbumArtistComposite.FieldNumber];

                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            reader.GetValues(objectBuffer);
                            compositeList.Add(new AlbumArtistComposite(objectBuffer));
                        }
                        reader.NextResult();
                    }
                    return compositeList;
                }
            }
        }
    }
}
