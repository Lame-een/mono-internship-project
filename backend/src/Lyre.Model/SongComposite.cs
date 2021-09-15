using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyre.Model.Common;

namespace Lyre.Model
{
    public class SongComposite : ISongComposite
    {
        public string SongName { get; set; }
        public Guid SongID { get; set; }

        public string AlbumName { get; set; }
        public Guid AlbumID { get; set; }

        public string ArtistName { get; set; }
        public Guid ArtistID { get; set; }

        public string GenreName { get; set; }
        public Guid? LyricsID { get; set; }

        public const int FieldNumber = 8;

        public SongComposite(Guid songID, string songName, string albumName, string artistName, string genreName, Guid? lyricsID)
        {
            SongID = songID;
            SongName = songName;
            AlbumName = albumName;
            ArtistName = artistName;
            GenreName = genreName;
            LyricsID = lyricsID;
        }
        public SongComposite() { }
        public SongComposite(object[] obj)
        {
            if (obj.Length < FieldNumber) throw new ArgumentException("Passed object array is not of valid length");

            SongName = (string)obj[0];
            SongID = (Guid)obj[1];
            AlbumName = (string)obj[2];
            AlbumID = (Guid)obj[3];
            ArtistName = (string)obj[4];
            ArtistID = (Guid)obj[5];
            GenreName = (string)obj[6];
            if (obj[7].GetType() == typeof(DBNull))
            {
                LyricsID = null;
            }
            else
            {
                LyricsID = (Guid?)obj[7];
            }

        }
    }
}
