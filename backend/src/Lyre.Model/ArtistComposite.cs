using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model
{
    public class ArtistComposite: IArtistComposite
    {
        public string ArtistName { get; set; }
        public string SongName { get; set; }
        public Guid SongID { get; set; }
        public string AlbumName { get; set; }
        public Guid AlbumID { get; set; }

        public const int FieldNumber = 5;

        public ArtistComposite() { }

        public ArtistComposite(string artistName, string songName, Guid songID, string albumName, Guid albumID)
        {
            ArtistName = artistName;
            SongName = songName;
            SongID = songID;
            AlbumName = albumName;
            AlbumID = albumID;
        }
        public ArtistComposite(object[] obj)
        {
            if (obj.Length < FieldNumber) throw new ArgumentException("Passed object array is not of valid length");

            ArtistName = (string)obj[0];
            SongName = (string)obj[1];
            SongID = (Guid)obj[2];
            AlbumName = (string)obj[3];
            AlbumID = (Guid)obj[4];
        }
    }
}
