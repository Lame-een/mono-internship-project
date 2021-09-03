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
            string sqlSelect = "SELECT * FROM album " + qsManager.Filter.GetSql() + qsManager.Sorter.GetSql(typeof(IAlbum)) + qsManager.Pager.GetSql() + ';';

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
                string queryString = "SELECT * FROM ALBUM WHERE ALBUM_ID = @AlbumID;";

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

                string queryString = "UPDATE ALBUM SET name = @name, number_of_tracks = @number_of_tracks, year = @year, cover = @cover, artist_id = @artist_id "
                + "WHERE album_id = @ID;";

                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@ID", albumGuid);
                SqlUtilities.AddParameterWithNullableValue(command, "@name", album.name);
                SqlUtilities.AddParameterWithNullableValue(command, "@number_of_tracks", album.number_of_tracks);
                SqlUtilities.AddParameterWithNullableValue(command, "@year", album.year);
                SqlUtilities.AddParameterWithNullableValue(command, "@cover", album.cover);
                SqlUtilities.AddParameterWithNullableValue(command, "@artist_id", album.artist_id);


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

                string queryString = "DELETE ALBUM WHERE album_id = @AlbumID;";

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

        public async Task<int> CountSongsInAlbum(Guid albumGuid)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT COUNT(song_id) FROM SONG WHERE ALBUM_ID = @AlbumID;";

                SqlCommand command = new SqlCommand(queryString, connection);

                SqlUtilities.AddParameterWithNullableValue(command, "@AlbumID", albumGuid);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    reader.Read();

                    return reader.GetInt32(0);
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
