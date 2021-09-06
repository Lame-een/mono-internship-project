using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface IAlbum
    {
        Guid AlbumID { get; set; }

        string Name { get; set; }

        int? NumberOfTracks { get; set; }

        int? Year { get; set; }

        string Cover { get; set; }

        Guid ArtistID { get; set; }

        DateTime? CreationTime { get; set; }
    }
}
