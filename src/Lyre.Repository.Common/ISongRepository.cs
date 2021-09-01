using Lyre.Common;
using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Repository.Common
{
    public interface ISongRepository
    {
        Task<ISong> GetSong(Guid songGuid);

        Task<List<ISong>> GetAllSongs(Pager pager, Sorter sorter, SongFilter filter);

        Task<int> PostSong(ISong S);

        Task<int> PutSong(Guid songGuid, ISong value);

        Task<int> DeleteSongByID(Guid songGuid);
    }
}
