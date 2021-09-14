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
        public const int FieldNumber = 3;
        public Guid ArtistID { get; set; }
        public string Name { get; set; }
        public DateTime? CreationTime { get; set; }

        public Artist() { }
        public Artist(Guid id, string name, DateTime creationTime)
        {
            ArtistID = id;
            Name = name;
            CreationTime = creationTime;
        }

        public Artist(object[] obj)
        {
            if (obj.Length != FieldNumber) throw new ArgumentException("Passed object array is not of valid length");

            ArtistID = (Guid)obj[0];
            Name = (string)obj[1];
            CreationTime = (DateTime?)obj[2];
        }
    }
}
