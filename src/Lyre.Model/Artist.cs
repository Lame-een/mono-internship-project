using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model
{
    public class Artist: IArtist
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }

        public Artist() { }
        public Artist(Guid id, string name, DateTime creationTime)
        {
            ID = id;
            Name = name;
            CreationTime = creationTime;
        }
    }
}
