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
        public int album_id { get; set; }

        public string name { get; set; }

        public int number_of_tracks { get; set; }

        public int year { get; set; }

        public string cover { get; set; }

        public int artist_id { get; set; }

        public DateTime creation_time { get; set; }
    }
}
