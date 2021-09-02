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
    public class LyricsRepository: ILyricsRepository
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
                    command.Parameters.AddWithValue("@lyricsID", newLyrics.ID);
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
                string queryString = "SELECT * FROM lyrics WHERE lyrics_id = @lyricsID;";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@lyricsID", id);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    reader.Read();
                    ILyrics lyricsData = new Lyrics(reader.GetGuid(0), reader.GetString(1), reader.GetGuid(2), reader.GetGuid(3), 
                                                    reader.GetDateTime(4), Convert.ToChar(reader.GetString(5)));
                    reader.Close();
                    return lyricsData;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<int> PutLyricsAsync(ILyrics lyrics)
        {
            try
            {
                using (SqlConnection connection = DBHandler.NewConnection())
                {
                    connection.Open();
                    string queryString = "UPDATE lyrics SET text = @text, verified = @verified WHERE lyrics_id = @lyricsID;";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@text", lyrics.Text);
                    command.Parameters.AddWithValue("@verified", lyrics.Verified);
                    command.Parameters.AddWithValue("@lyricsID", lyrics.ID);

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
                    string queryString = "DELETE FROM lyrics WHERE lyrics_id = @id;";

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
