using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface IArtist
    {
        Guid ArtistID { get; set; }
        string Name { get; set; }
        DateTime? CreationTime { get; set; }
    }
}
