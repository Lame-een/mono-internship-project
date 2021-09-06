using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public interface ILyrics
    {
        Guid LyricsID { get; set; }
        string Text { get; set; }
        Guid UserID { get; set; }
        Guid SongID { get; set; }
        DateTime CreationTime { get; set; }
        char Verified { get; set; }  // Y or N
    }
}
