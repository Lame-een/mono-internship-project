using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface ISong
    {
        Guid SongID { get; set; }
        string Name { get; set; }
        Guid AlbumID { get; set; }
        Guid? GenreID { get; set; }

        DateTime? CreationTime { get; set; }
    }
}
