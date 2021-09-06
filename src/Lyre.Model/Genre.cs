using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model
{
    public class Genre : IGenre
    {
        public Guid GenreID { get; set; }
        public string Name { get; set; }

        public Genre()
        {
            GenreID = new Guid();
        }
        public Genre(Guid id, string name)
        {
            GenreID = id;
            Name = name;
        }
    }
}
