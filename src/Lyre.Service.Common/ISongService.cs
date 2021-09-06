using Lyre.Common;
using Lyre.Model;
using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Service.Common
{
    public interface ISongService
    {
        Task<ISong> GetSong(Guid songGuid);

        Task<ISongComposite> GetSongComposite(Guid songGuid);

        Task<List<ISong>> GetAllSongs(QueryStringManager qsManager);

        Task<int> PostSong(ISong song);

        Task<int> PutSong(Guid songGuid, ISong value);

        Task<int> DeleteSongByID(Guid songGuid);

        ISong NewSong();

        ISong NewSong(Guid SongID, string Name, Guid AlbumID, Guid? GenreID = null);
    }
}
