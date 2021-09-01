using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model
{
    public class Genre: IGenre
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public Genre() { }
        public Genre(Guid id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
