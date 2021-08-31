using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface IGenre
    {
        Guid ID { get; set; }
        string Name { get; set; }
    }
}
