using Lyre.Model.Common;
using Lyre.Repository.Common;
using Lyre.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Service
{
    class LyricsService: ILyricsService
    {
        public ILyricsRepository LyricsRepo { get; set; }

        public LyricsService(ILyricsRepository lyricsRepo)
        {
            LyricsRepo = lyricsRepo;
        }

        public async Task<int> PostLyricsAsync(ILyrics newLyrics)
        {
            newLyrics.ID = Guid.NewGuid();
            newLyrics.CreationTime = DateTime.Now;
            return await LyricsRepo.PostLyricsAsync(newLyrics);
        }
        public async Task<ILyrics> GetLyricsByIDAsync(Guid id)
        {
            return await LyricsRepo.GetLyricsByIDAsync(id);
        }
        public async Task<int> PutLyricsAsync(ILyrics lyrics)
        {
            return await LyricsRepo.PutLyricsAsync(lyrics);
        }
        public async Task<int> DeleteLyricsByIDAsync(Guid id)
        {
            return await LyricsRepo.DeleteLyricsByIDAsync(id);
        }
    }
}
