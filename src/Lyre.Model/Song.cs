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
        public int song_id { get; set; }

        public string name { get; set; }

        public int album_id { get; set; }

        public int genre_id { get; set; }

        public DateTime creation_time { get; set; }
    }
}
