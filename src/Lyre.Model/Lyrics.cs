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
        public const int FieldNumber = 6;
        public Guid LyricsID { get; set; }
        public string Text { get; set; }
        public Guid UserID { get; set; }
        public Guid? SongID { get; set; }
        public DateTime? CreationTime { get; set; }
        public char Verified { get; set; }

        public Lyrics() { }
        public Lyrics(string text, Guid userID, Guid songID, char verified = 'n')
        {
            Text = text;
            UserID = userID;
            SongID = songID;
            CreationTime = DateTime.Now;
            Verified = verified;
        }
        public Lyrics(Guid id, string text, Guid userID, Guid songID, char verified = 'n')
        {
            LyricsID = id;
            Text = text;
            UserID = userID;
            SongID = songID;
            CreationTime = DateTime.Now;
            Verified = verified;
        }

        public Lyrics(object[] obj)
        {
            if (obj.Length != FieldNumber) throw new ArgumentException("Passed object array is not of valid length");

            LyricsID = (Guid)obj[0];
            Text = (string)obj[1];
            UserID = (Guid)obj[2];
            SongID = (Guid)obj[3];
            CreationTime = (DateTime)(obj[4] == DBNull.Value ? null : obj[4]);
            Verified = ((string)obj[5])[0];

            if((Verified != 'Y') && (Verified != 'N'))
            {
                throw new Exception("Invalid assignment value for 'Verified'");
            }
        }
    }
}
