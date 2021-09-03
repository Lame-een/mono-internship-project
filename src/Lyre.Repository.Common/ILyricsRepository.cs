using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Repository.Common
{
    public interface ILyricsRepository
    {
        Task<int> PostLyricsAsync(ILyrics newLyrics);
        Task<ILyrics> GetLyricsByIDAsync(Guid id);
        Task<int> PutLyricsAsync(ILyrics lyrics);
        Task<int> DeleteLyricsByIDAsync(Guid id);
    }
}
