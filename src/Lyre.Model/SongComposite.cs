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
        public Guid SongID { get; set; }
        public string SongName { get; set; }

        public string AlbumName { get; set; }

        public string ArtistName { get; set; }

        public string GenreName { get; set; }
        public Guid? LyricsID { get; set; }

        public const int FieldNumber = 6;

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

            SongID = (Guid)obj[0];
            SongName = (string)obj[1];
            AlbumName = (string)obj[2];
            ArtistName = (string)obj[3];
            GenreName = (string)obj[4];
            LyricsID = (Guid?)obj[5];
        }
    }
}
