using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface ISong
    {
        Guid song_id { get; set; }

        string name { get; set; }

        Guid? album_id { get; set; }

        Guid? genre_id { get; set; }

        DateTime creation_time { get; set; }
    }
}
