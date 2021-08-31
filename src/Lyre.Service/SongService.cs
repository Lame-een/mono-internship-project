using Lyre.Model;
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
    public class SongService: ISongService
    {
        public SongService(ISongRepository repository)
        {
            Repository = repository;
        }
        protected ISongRepository Repository { get; private set; }
        public async Task<ISong> GetSong(Guid songGuid)
        {
            return await Repository.GetSong(songGuid);
        }

        public async Task<List<ISong>> GetAllSongs()
        {
            return await Repository.GetAllSongs();
        }

        public async Task<int> PostSong(ISong song)
        {
            return await Repository.PostSong(song);
        }
        public async Task<int> PutSong(Guid songGuid, ISong value)
        {
            return await Repository.PutSong(songGuid, value);
        }
        public async Task<int> DeleteSong(Guid songGuid)
        {
            return await Repository.DeleteSong(songGuid);
        }


        public ISong NewSong()
        {
            return new Song();
        }

        public ISong NewSong(Guid song_id, string name, Guid? album_id = null, Guid? genre_id = null)
        {
            return new Song(song_id, name, album_id, genre_id);
        }
    }
}
