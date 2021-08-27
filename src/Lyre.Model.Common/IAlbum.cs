using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface IAlbum
    {
        int album_id { get; set; }

        string name { get; set; }

        int number_of_tracks { get; set; }

        int year { get; set; }

        string cover { get; set; }

        int artist_id { get; set; }

        DateTime creation_time { get; set; }
    }
}
