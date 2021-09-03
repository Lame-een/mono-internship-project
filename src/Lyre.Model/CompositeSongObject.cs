using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyre.Model.Common;

namespace Lyre.Model
{
    public class CompositeSongObject: ICompositeSongObject
    {
        public string song_name { get; set; }

        public string album_name { get; set; }

        public string artist_name { get; set; }

        public string genre_name { get; set; }

        public const int FieldNumber = 4;

        public CompositeSongObject(string Song_name, string Album_name, string Genre_name, string Artist_id)
        {
            song_name = Song_name;
            album_name = Album_name;
            artist_name = Artist_id;
            genre_name = Genre_name;
        }

        public CompositeSongObject(object[] obj)
        {
            if (obj.Length < FieldNumber) throw new ArgumentException("Passed object array is not of valid length");

            song_name = (string)obj[0];
            album_name = (string)obj[1];
            artist_name = (string)obj[2];
            genre_name = (string)obj[3];
        }
    }
}
