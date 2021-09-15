using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model
{
    public class AlbumArtistComposite: IAlbumArtistComposite
    {
        public Guid AlbumID { get; set; }
        public string AlbumName { get; set; }
        public Guid ArtistID { get; set; }
        public string ArtistName { get; set; }

        public const int FieldNumber = 4;

        public AlbumArtistComposite() { }

        public AlbumArtistComposite(Guid albumID, string albumName, Guid artistID, string artistName)
        {
            AlbumID = albumID;
            AlbumName = albumName;
            ArtistID = artistID;
            ArtistName = artistName;
        }

        public AlbumArtistComposite(object[] obj)
        {
            if (obj.Length < FieldNumber) throw new ArgumentException("Passed object array is not of valid length");

            AlbumID = (Guid)obj[0];
            AlbumName = (string)obj[1];
            ArtistID = (Guid)obj[2];
            ArtistName = (string)obj[3];
        }
    }
}
