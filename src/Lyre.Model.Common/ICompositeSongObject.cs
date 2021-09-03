using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface ICompositeSongObject
    {
        string song_name { get; set; }

        string album_name { get; set; }

        string artist_name { get; set; }

        string genre_name { get; set; }
    }
}
