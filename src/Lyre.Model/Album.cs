using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model
{
    public class Album: IAlbum
    {
        public const int FieldNumber = 7;
        public Guid AlbumID { get; set; }

        public string Name { get; set; }

        public int? NumberOfTracks { get; set; }

        public int? Year { get; set; }

        public string Cover { get; set; }

        public Guid ArtistID { get; set; }

        public DateTime? CreationTime { get; set; }

        public Album(Guid albumID, string name, string cover, Guid artistID, int? numberOfTracks = null, int? year = null)
        {
            AlbumID = albumID;
            Name = name;
            NumberOfTracks = numberOfTracks;
            Year = year;
            Cover = cover;
            ArtistID = artistID;
            CreationTime = DateTime.Now;
        }

        public Album() 
        {
            AlbumID = Guid.NewGuid();
            CreationTime = DateTime.Now;
        }

        public Album(object[] obj)
        {
            if (obj.Length != FieldNumber) throw new ArgumentException("Passed object array is not of valid length");

            AlbumID = (Guid)obj[0];
            Name = (string)obj[1];
            NumberOfTracks = (int?)obj[2];
            Year = (int?)obj[3];
            if (obj[4].GetType() == typeof(DBNull))
            {
                Cover = null;
            }
            else
            { 
                Cover = (string)obj[4];
            }
            ArtistID = (Guid)obj[5];
            CreationTime = (DateTime?)(obj[6] == DBNull.Value ? null : obj[6]);
        }
    }
}
