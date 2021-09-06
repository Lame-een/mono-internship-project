using Lyre.Common;
using Lyre.Model;
using Lyre.Model.Common;
using Lyre.Repository.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Repository
{
    public class LyricsRepository : ILyricsRepository
    {
        public IDatabaseHandler DBHandler { get; set; }
        public LyricsRepository(IDatabaseHandler dbHandler)
        {
            DBHandler = dbHandler;
        }

        public async Task<int> PostLyricsAsync(ILyrics newLyrics)
        {
            try
            {
                using (SqlConnection connection = DBHandler.NewConnection())
                {
                    connection.Open();
                    string queryString = "INSERT INTO lyrics VALUES (@lyricsID, @text, @userID, @songID, @creationTime);";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@lyricsID", newLyrics.LyricsID);
                    command.Parameters.AddWithValue("@text", newLyrics.Text);
                    command.Parameters.AddWithValue("@userID", newLyrics.UserID);
                    command.Parameters.AddWithValue("@songID", newLyrics.SongID);
                    command.Parameters.AddWithValue("@creationDate", newLyrics.CreationTime);

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
        public async Task<ILyrics> GetLyricsByIDAsync(Guid id)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM lyrics WHERE lyricsID = @lyricsID;";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@lyricsID", id);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    ILyrics ret = null;
                    object[] objectBuffer = new object[Lyrics.FieldNumber];

                    if (reader.Read())
                    {
                        reader.GetValues(objectBuffer);
                        ret = new Lyrics(objectBuffer);
                        reader.Close();
                    }
                    reader.Dispose();
                    return ret;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<ILyrics>> GetLyricsBySongIDAsync(Guid id)
        {
            using (SqlConnection connection = DBHandler.NewConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM lyrics WHERE songID = @songID;";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@songID", id);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<ILyrics> lyricsList = new List<ILyrics>();

                object[] objectBuffer = new object[Lyrics.FieldNumber];
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        reader.GetValues(objectBuffer);
                        lyricsList.Add(new Lyrics(objectBuffer));
                    }
                    reader.NextResult();
                }
                return lyricsList;
            }
        }
        public async Task<int> PutLyricsAsync(ILyrics lyrics)
        {
            try
            {
                using (SqlConnection connection = DBHandler.NewConnection())
                {
                    connection.Open();
                    string queryString = "UPDATE lyrics SET text = @text, verified = @verified, songID = @songID WHERE lyricsID = @lyricsID;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@text", lyrics.Text);
                    command.Parameters.AddWithValue("@verified", lyrics.Verified);
                    command.Parameters.AddWithValue("@songID", lyrics.SongID);
                    command.Parameters.AddWithValue("@lyricsID", lyrics.LyricsID);

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
        public async Task<int> DeleteLyricsByIDAsync(Guid id)
        {
            try
            {
                using (SqlConnection connection = DBHandler.NewConnection())
                {
                    connection.Open();
                    string queryString = "DELETE FROM lyrics WHERE lyricsID = @id;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", id);

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
