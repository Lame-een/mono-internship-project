using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface IAlbumComposite
    {
        string AlbumName { get; set; }
        Guid SongID { get; set; }
        string SongName { get; set; }
    }
}
