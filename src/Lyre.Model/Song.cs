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
        public Guid song_id { get; set; }

        public string name { get; set; }

        public Guid? album_id { get; set; }

        public Guid? genre_id { get; set; }

        public DateTime creation_time { get; set; }

        public Song(Guid Song_id, string Name, Guid? Album_id = null, Guid? Genre_id = null)
        {
            song_id = Song_id;
            name = Name;
            album_id = Album_id;
            genre_id = Genre_id;
            creation_time = DateTime.Now;
        }

        public Song() 
        {
                song_id = Guid.NewGuid();
                creation_time = DateTime.Now;
        }
    }
}
