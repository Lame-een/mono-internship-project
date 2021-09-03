using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model
{
    public class Lyrics : ILyrics
    {
        public Guid LyricsID { get; set; }
        public string Text { get; set; }
        public Guid UserID { get; set; }
        public Guid SongID { get; set; }
        public DateTime CreationTime { get; set; }
        public char Verified { get; set; }

        public Lyrics() { }
        public Lyrics(string text, Guid userID, Guid songID, char verified = 'n')
        {
            Text = text;
            UserID = userID;
            SongID = songID;
            Verified = verified;
        }
        public Lyrics(Guid id, string text, Guid userID, Guid songID, DateTime creationTime, char verified = 'n')
        {
            LyricsID = id;
            Text = text;
            UserID = userID;
            SongID = songID;
            CreationTime = creationTime;
            Verified = verified;
        }
    }
}
