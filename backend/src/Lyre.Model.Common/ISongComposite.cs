using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface ISongComposite
    {
        Guid SongID { get; set; }
        string SongName { get; set; }

        string AlbumName { get; set; }

        string ArtistName { get; set; }

        string GenreName { get; set; }
        Guid? LyricsID { get; set; }
    }
}
