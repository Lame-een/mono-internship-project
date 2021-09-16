using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model
{
    public class AlbumComposite : IAlbumComposite
    {
        public string AlbumName { get; set; }
        public Guid SongID { get; set; }
        public string SongName { get; set; }
        public string ArtistName { get; set; }

        public Guid ArtistID { get; set; }

        public const int FieldNumber = 5;

        public AlbumComposite(string albumName, Guid songID, string songName, string artistName, Guid artistID)
        {
            AlbumName = albumName;
            SongID = songID;
            SongName = songName;
            ArtistName = artistName;
            ArtistID = artistID;
        }
        public AlbumComposite() { }
        public AlbumComposite(object[] obj)
        {
            if (obj.Length < FieldNumber) throw new ArgumentException("Passed object array is not of valid length");

            AlbumName = (string)obj[0];
            SongID = (Guid)obj[1];
            SongName = (string)obj[2];
            ArtistName = (string)obj[3];
            ArtistID = (Guid)obj[4];
        }
    }
}
