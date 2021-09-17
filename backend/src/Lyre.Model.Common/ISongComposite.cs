using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface ISongComposite
    {
        string SongName { get; set; }
        Guid SongID { get; set; }

        string AlbumName { get; set; }
        Guid AlbumID { get; set; }

        string ArtistName { get; set; }
        Guid ArtistID { get; set; }

        string GenreName { get; set; }
        Guid? LyricsID { get; set; }

        string Cover { get; set; }
    }
}
