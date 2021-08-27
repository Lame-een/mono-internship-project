using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface ISong
    {
        int song_id { get; set; }

        string name { get; set; }

        int album_id { get; set; }

        int genre_id { get; set; }

        DateTime creation_time { get; set; }
    }
}
