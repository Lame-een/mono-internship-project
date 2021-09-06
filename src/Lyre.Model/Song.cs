using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model
{
    public class Song: ISong
    {
        public const int FieldNumber = 5;

        public Guid SongID { get; set; }

        public string Name { get; set; }

        public Guid AlbumID { get; set; }

        public Guid? GenreID { get; set; }

        public DateTime? CreationTime { get; set; }

        public Song(Guid songID, string name, Guid albumID, Guid? genreID = null)
        {
            SongID = songID;
            Name = name;
            AlbumID = albumID;
            GenreID = genreID;
            CreationTime = DateTime.Now;
        }

        public Song() 
        {
                SongID = Guid.NewGuid();
                CreationTime = DateTime.Now;
        }

        public Song(object[] obj)
        {
            if (obj.Length != FieldNumber) throw new ArgumentException("Passed object array is not of valid length");

            SongID = (Guid)obj[0];
            Name = (string)obj[1];
            AlbumID = (Guid)obj[2];
            GenreID = (Guid?)obj[3];
            CreationTime = (DateTime?)(obj[4] == DBNull.Value ? null : obj[4]);
        }
    }
}
