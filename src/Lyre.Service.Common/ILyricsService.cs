using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Service.Common
{
    public interface ILyricsService
    {
        Task<int> PostLyricsAsync(ILyrics newLyrics);
        Task<List<ILyrics>> GetLyricsBySongIDAsync(Guid id);
        Task<ILyrics> GetLyricsByIDAsync(Guid id);
        Task<int> PutLyricsAsync(ILyrics lyrics);
        Task<int> DeleteLyricsByIDAsync(Guid id);
    }
}
