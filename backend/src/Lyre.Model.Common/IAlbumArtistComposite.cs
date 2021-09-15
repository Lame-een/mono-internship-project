using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface IAlbumArtistComposite
    {
        Guid AlbumID { get; set; }
        string AlbumName { get; set; }
        Guid ArtistID { get; set; }
        string ArtistName { get; set; }
    }
}
