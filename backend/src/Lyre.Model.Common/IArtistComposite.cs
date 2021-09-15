using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface IArtistComposite
    {
        string ArtistName { get; set; }
        string SongName { get; set; }
        Guid SongID { get; set; }
        string AlbumName { get; set; }
        Guid AlbumID { get; set; }
    }
}
