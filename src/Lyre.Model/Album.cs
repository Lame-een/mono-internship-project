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
        public Guid album_id { get; set; }

        public string name { get; set; }

        public int? number_of_tracks { get; set; }

        public int? year { get; set; }

        public string cover { get; set; }

        public Guid artist_id { get; set; }

        public DateTime? creation_time { get; set; }

        public Album(Guid Album_id, string Name, string Cover, Guid Artist_id, int? Number_of_tracks = null, int? Year = null)
        {
            album_id = Album_id;
            name = Name;
            number_of_tracks = Number_of_tracks;
            year = Year;
            cover = Cover;
            artist_id = Artist_id;
            creation_time = DateTime.Now;
        }

        public Album() 
        {
            album_id = Guid.NewGuid();
            creation_time = DateTime.Now;
        }
    }
}
